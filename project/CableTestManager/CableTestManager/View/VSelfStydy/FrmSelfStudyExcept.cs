using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.Model;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Business.Implements;

namespace CableTestManager.View.VSelfStydy
{
    public partial class FrmSelfStudyExcept : Form
    {
        private List<SelfStudyParams> studyParamExceptList;
        private List<SelfStudyParams> studyParamValidList;
        private List<SelfStudyParams> studyParamMulRelateList;
        private DataTable dataSourceSelfStudy;
        private bool IsFirstExBeyandStyle, IsFirstExOpenCirStyle, IsFirstMulStyle;

        public FrmSelfStudyExcept(List<SelfStudyParams> studyParamExceptList, List<SelfStudyParams> studyParamValidList, List<SelfStudyParams> studyParamMulRelateList)
        {
            InitializeComponent();
            this.studyParamExceptList = studyParamExceptList;
            this.studyParamValidList = studyParamValidList;
            this.studyParamMulRelateList = studyParamMulRelateList;
        }

        private void FrmSelfStudyExcept_Load(object sender, EventArgs e)
        {
            InitDatatable();
            CalRequireDataSource();
            this.btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitDatatable()
        {
            this.dataSourceSelfStudy = new DataTable();
            this.dataSourceSelfStudy.Columns.Add("序号");
            this.dataSourceSelfStudy.Columns.Add("起点接点");
            this.dataSourceSelfStudy.Columns.Add("终点接点");
            this.dataSourceSelfStudy.Columns.Add("测量值(Ω)");
            this.dataSourceSelfStudy.Columns.Add("测量结果");
            this.radGridView1.DataSource = this.dataSourceSelfStudy;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1, false, true, 5);
        }

        private async void CalRequireDataSource()
        {
            //显示三部分数据，以不同颜色区分
            //第一部分显示一对多的数据
            //第二部分显示阻值过大而未开路的数据与显示开路的数据
            await Task.Run(()=>
            {
                lock (this)
                {
                    foreach (var studyParams in this.studyParamValidList)
                    {
                        //根据已经测试的导通数据查询结果
                        var exObjList = this.studyParamExceptList.FindAll(point => point.DevStartPoint == studyParams.DevStartPoint);
                        if (exObjList.Count > 0)
                        {
                            //查询出已经测试导通的数据，过滤掉，留下未测试过的点的关系
                            foreach (var obj in exObjList)
                            {
                                this.studyParamExceptList.Remove(obj);
                            }
                        }
                        exObjList = this.studyParamExceptList.FindAll(P => P.DevEndPoint == studyParams.DevEndPoint);
                        if (exObjList.Count > 0)
                        {
                            foreach (var obj in exObjList)
                            {
                                this.studyParamExceptList.Remove(obj);//去掉另一端的
                            }
                        }
                        exObjList = this.studyParamExceptList.FindAll(P => P.DevEndPoint == studyParams.DevStartPoint);
                        if (exObjList.Count > 0)
                        {
                            foreach (var obj in exObjList)
                            {
                                this.studyParamExceptList.Remove(obj);//去掉另一端的
                            }
                        }
                        exObjList = this.studyParamExceptList.FindAll(P => P.DevStartPoint == studyParams.DevEndPoint);
                        if (exObjList.Count > 0)
                        {
                            foreach (var obj in exObjList)
                            {
                                this.studyParamExceptList.Remove(obj);//去掉另一端的
                            }
                        }
                    }
                    int iRow = 1;
                    this.radGridView1.BeginEdit();
                    foreach (var mulObj in this.studyParamMulRelateList)
                    {
                        var oldObj = this.studyParamValidList.Find(point => point.DevStartPoint == mulObj.DevStartPoint);
                        if (oldObj != null)
                        {
                            AddMulData(oldObj, iRow);
                        }
                        oldObj = this.studyParamValidList.Find(p => p.DevEndPoint == mulObj.DevEndPoint);
                        if (oldObj != null)
                        {
                            AddMulData(oldObj, iRow);
                        }
                        AddMulData(mulObj, iRow);
                    }
                    iRow = this.dataSourceSelfStudy.Rows.Count + 1;
                    foreach (var exObj in this.studyParamExceptList)
                    {
                        var pointOrderA = GetOrderPointByDevPoint(exObj.DevStartPoint, 0, exObj).StartPointOrder;
                        var pointOrderB = GetOrderPointByDevPoint(exObj.DevEndPoint, 1, exObj).EndPointOrder;
                        DataRow dr = this.dataSourceSelfStudy.NewRow();
                        dr[0] = iRow;
                        dr[1] = pointOrderA;
                        dr[2] = pointOrderB;
                        dr[3] = exObj.TestResultVal;
                        dr[4] = exObj.TestReulst;
                        this.dataSourceSelfStudy.Rows.Add(dr);
                        SetGridStyleByTestValue(exObj.TestReulst);
                        iRow++;
                    }
                    this.radGridView1.DataSource = this.dataSourceSelfStudy;

                    this.radGridView1.EndEdit();
                }
            });
        }

        private void AddMulData(SelfStudyParams mulObj, int iRow)
        {
            var pointOrderA = GetOrderPointByDevPoint(mulObj.DevStartPoint, 0, mulObj).StartPointOrder;
            var pointOrderB = GetOrderPointByDevPoint(mulObj.DevEndPoint, 1, mulObj).EndPointOrder;
            DataRow dr = this.dataSourceSelfStudy.NewRow();
            dr[0] = iRow;
            dr[1] = pointOrderA;
            dr[2] = pointOrderB;
            dr[3] = mulObj.TestResultVal;
            dr[4] = mulObj.TestReulst;
            DataRow[] rowArray = this.dataSourceSelfStudy.Select($"起点接点='{pointOrderA}' and 终点接点='{pointOrderB}'");
            if (rowArray.Length > 0)
            {
                return;
            }
            this.dataSourceSelfStudy.Rows.Add(dr);
            SetGridStyleByTestValue(mulObj.TestReulst);
            iRow++;
        }

        private void SetGridStyleByTestValue(string testResult)
        {
            if (!IsFirstMulStyle)
            {
                if (testResult == "导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridView1, 4, RadGridViewProperties.GridViewRecordEnum.Conduction);
                    this.IsFirstMulStyle = true;
                }
            }
            if (!IsFirstExBeyandStyle)
            {
                if (testResult == "不导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridView1, 4, RadGridViewProperties.GridViewRecordEnum.UnConduction);
                    this.IsFirstExBeyandStyle = true;
                }
            }
            if (!IsFirstExOpenCirStyle)
            {
                if (testResult == "开路")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridView1, 4, RadGridViewProperties.GridViewRecordEnum.OpenCircuit);
                    {
                        this.IsFirstExOpenCirStyle = true;
                    }
                }
            }
        }

        private SelfStudyParams GetOrderPointByDevPoint(string did, int stype, SelfStudyParams studyParams)//stype 0 - start,1-end
        {
            //SelfStudyParams studyParams = new SelfStudyParams();
            InterfaceInfoLibraryManager infoLibraryManager = new InterfaceInfoLibraryManager();
            var data = infoLibraryManager.GetDataSetByFieldsAndWhere("ContactPoint,InterfaceNo", $"where SwitchStandStitchNo='{did}'").Tables[0];
            if (data.Rows.Count < 1)
            {
                studyParams.StartPointOrder = "";
                studyParams.EndPointOrder = "";
                return studyParams;
            }
            var interName = data.Rows[0][1].ToString();
            var pointOrder = data.Rows[0][0].ToString();
            if (stype == 0)
            {
                studyParams.StartInterfaceName = interName;
                studyParams.StartPointOrder = pointOrder;
            }
            else if (stype == 1)
            {
                studyParams.EndInterfaceName = interName;
                studyParams.EndPointOrder = pointOrder;
            }
            return studyParams;
        }
    }
}
