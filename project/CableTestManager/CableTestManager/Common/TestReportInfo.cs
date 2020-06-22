using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CableTestManager.Entity;
using CommonUtils.PDF;
using CableTestManager.CUserManager;
using System.Data;
using CableTestManager.Business.Implements;
using CableTestManager.Common;
using System.Windows.Forms;
using CommonUtils.Logger;

namespace CableTestManager.Common
{
    public class TestReportInfo
    {
        private static string curReportAbsFile;
        private static bool ExportTestReport(string testSerial, string pdfFilePath)
        {
            if (String.IsNullOrEmpty(testSerial) || testSerial == "")
                return false;
            var hisBasicInfo = TestHisBasicInfo.QueryProTestHisBasicInfo(testSerial);
            ExportPDF(pdfFilePath, hisBasicInfo, testSerial);
            return true;
        }

        public static bool ExportReport(string reportDir, string testSerial)
        {
            LogHelper.Log.Info("开始生成报表...");
            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }
            curReportAbsFile = reportDir + "线束测试报告_" + testSerial + ".pdf";
            if (TestReportInfo.ExportTestReport(testSerial, curReportAbsFile))
            {
                if (MessageBox.Show("测试报告已生成，是否打开测试报告？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (File.Exists(curReportAbsFile))
                    {
                        System.Diagnostics.Process.Start(curReportAbsFile);
                    }
                }
                return true;
            }
            return false;
        }

        public static void PrintReport(string reportDir, string testSerial)
        {
            if (File.Exists(curReportAbsFile))
            {
                PDFPrint.UseDefaultPrinter(curReportAbsFile);
            }
            else
            {
                if (!ExportReport(reportDir, testSerial))
                    return;
                if (File.Exists(curReportAbsFile))
                {
                    PDFPrint.UseDefaultPrinter(curReportAbsFile);
                }
            }
        }

        private static void ExportPDF(string pdfFilePath, THistoryDataBasic hisInfo, string testSerial)
        {
            var detailData = QueryTestHisDetail(testSerial);
            using (Stream fs = new FileStream(pdfFilePath, FileMode.Create))
            {
                PDFOperation pdf = new PDFOperation();
                pdf.Open(fs);
                pdf.SetBaseFont(@"C:\Windows\Fonts\SIMHEI.TTF");
                //pdf.AddParagraph(sb.ToString(), 15, 1, 20, 0, 0);
                pdf.AddParagraph("测试报告\r\n", 20);
                pdf.AddLine(71);
                pdf.AddParagraph($"线束名称：{hisInfo.TestCableName}     测试结果：{CalFinalTestResult(hisInfo.ProjectName, hisInfo.TestCableName, testSerial)}", 15);
                pdf.AddParagraph($"环境湿度：{hisInfo.EnvironmentAmbientHumidity}%        测试温度：{hisInfo.EnvironmentTemperature}℃        测试人员：{hisInfo.TestOperator}\r\n", 15);
                pdf.AddParagraph($"测试日期：{hisInfo.TestStartDate} - {hisInfo.TestEndDate}\r\n", 15);
                pdf.AddLine(144);
                pdf.AddParagraph($"测试参数\r\n", 20);
                pdf.AddLine(171);
                pdf.AddParagraph($"导通测试阈值：{hisInfo.ConductThreshold}Ω        短路测试阈值：{hisInfo.ShortCircuitThreshold}Ω", 15);
                pdf.AddParagraph($"绝缘测试阈值：{hisInfo.InsulateThreshold}MΩ        绝缘保持时间：{hisInfo.InsulateHoldTime}S", 15);
                pdf.AddParagraph($"绝缘电压：{hisInfo.InsulateVoltage}V", 15);
                pdf.AddLine(241);
                pdf.AddParagraph($"异常明细\r\n\n", 20);
                pdf.AddParagraph("线束测试异常明细", QueryCableTestExceptTable(detailData), 15);
                //pdf.AddParagraph("\r\n", 15);
                pdf.AddParagraph("测试数据\r\n\r", 20);
                pdf.AddParagraph("线束测试合格明细", QueryCableTestPassTable(detailData), 15);
                pdf.Close();
            }
        }

        private static DataTable QueryTestHisDetail(string testSerial)
        {
            #region init table
            DataTable dataSource = new DataTable();
            dataSource.Columns.Add("起点接口");
            dataSource.Columns.Add("起点接点");
            dataSource.Columns.Add("终点接口");
            dataSource.Columns.Add("终点接点");
            dataSource.Columns.Add("导通电阻(Ω)");
            dataSource.Columns.Add("导通测试结果");
            dataSource.Columns.Add("短路测试(Ω)");
            dataSource.Columns.Add("短路测试结果");
            dataSource.Columns.Add("绝缘电阻(Ω)");
            dataSource.Columns.Add("绝缘测试结果");
            //dataSource.Columns.Add("耐压电流(Ω)");
            //dataSource.Columns.Add("耐压测试结果");
            #endregion

            THistoryDataDetailManager detailManage = new THistoryDataDetailManager();
            var data = detailManage.GetDataSetByWhere($"where TestSerialNumber = '{testSerial}'").Tables[0];
            if (data.Rows.Count <= 0)
                return dataSource;
            foreach (DataRow dataRow in data.Rows)
            {
                DataRow dr = dataSource.NewRow();
                dr["起点接口"] = dataRow["StartInterface"].ToString();
                dr["起点接点"] = dataRow["StartContactPoint"].ToString();
                dr["终点接口"] = dataRow["EndInterface"].ToString();
                dr["终点接点"] = dataRow["EndContactPoint"].ToString();
                dr["导通电阻(Ω)"] = dataRow["ConductValue"].ToString();
                dr["导通测试结果"] = dataRow["ConductTestResult"].ToString();
                dr["短路测试(Ω)"] = dataRow["ShortCircuitValue"].ToString();
                dr["短路测试结果"] = dataRow["ShortCircuitTestResult"].ToString();
                dr["绝缘电阻(Ω)"] = dataRow["InsulateValue"].ToString();
                dr["绝缘测试结果"] = dataRow["InsulateTestResult"].ToString();
                dataSource.Rows.Add(dr);
            }
            return dataSource;
        }

        private static DataTable QueryCableTestPassTable(DataTable data)
        {
            //导通测试结果//短路测试结果//绝缘测试结果//耐压测试结果
            var where1 = "导通测试结果='合格' and 短路测试结果='合格' and 绝缘测试结果='合格'";
            var where2 = "导通测试结果='合格' and 短路测试结果='合格'";
            var where3 = "导通测试结果='合格'";
            DataRow[] dataRow = data.Select(where1);
            if (dataRow.Length == 0)
            {
                dataRow = data.Select(where2);
                if (dataRow.Length == 0)
                {
                    dataRow = data.Select(where3);
                }
            }
            DataTable datasource = data.Clone();
            foreach (DataRow dr in dataRow)
            {
                datasource.ImportRow(dr);
            }
            return datasource;
        }

        private static DataTable QueryCableTestExceptTable(DataTable data)
        {
            //导通测试结果//短路测试结果//绝缘测试结果//耐压测试结果
            var where = "导通测试结果 = '不合格' OR 短路测试结果 = '不合格' OR 绝缘测试结果 = '不合格'";
            DataRow[] dataRow = data.Select(where);
            DataTable datasource = data.Clone();
            foreach (DataRow dr in dataRow)
            {
                datasource.ImportRow(dr);
            }
            return datasource;
        }

        private static string CalFinalTestResult(string project, string cableName, string testSerial)
        {
            THistoryDataBasicManager historyDataManage = new THistoryDataBasicManager();
            var where = $"where ProjectName = '{project}' and TestCableName = '{cableName}' and TestSerialNumber='{testSerial}'";
            var data = historyDataManage.GetDataSetByWhere(where).Tables[0];
            if (data.Rows.Count <= 0)
                return "未测试";
            var conductResult = data.Rows[0]["ConductTestResult"].ToString();
            var shortCircuitResult = data.Rows[0]["ShortCircuitTestResult"].ToString();
            var insulateResult = data.Rows[0]["InsulateTestResult"].ToString();
            if (conductResult == "合格" && shortCircuitResult == "合格" && insulateResult == "合格")
            {
                return "合格";
            }
            return "不合格";
        }

        public static bool DriverExists(string DriverName)
        {
            return System.IO.Directory.GetLogicalDrives().Contains(DriverName);
        }
    }
}
