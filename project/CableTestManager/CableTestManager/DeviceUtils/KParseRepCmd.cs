using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CableTestManager.DeviceUtils
{
	public class KParseRepCmd
	{
		public string dbPathStr;
		public string errorContentStr;
		public string errorDateTimeStr;
		public bool bDeviceErrorFlag;
		public string uploadErrorContentStr;
		public string uploadErrorDateTimeStr;
		public bool bUploadErrorFlag;
		public bool bSetBridgeFreqErrFlag;
		public bool bRecBridgeFreqFKFlag;
		public bool DeviceExist;
		public int DeviceConnectCount;
		public static int RESPDATALEN = 8;
		public bool UpFinish;
		public int mnUpDataCount;
		public int mnUpCmdCount;
		public int mnDownCmdCount;
		public int selfTestExPointCount;
		public int selfTestDataCount;
		public int selfTestOKCount;
		public int selfTestEXCount;
		public int selfTestProgress;
		public int[] selfTestPointArray;
		public int[] selfTestExPointArray;
		public bool bDTJZRFlag;
		public double dDTJZValue;
		public bool bJYDZJZRFlag;
		public double dJYDZJZValue;
		public bool bNYDLJZRFlag;
		public double dNYDLJZValue;
		public bool bHVDC_RFlag;
		public double dHVDC_Value;
		public bool bLVDC_RFlag;
		public double dLVDC_Value;
		public bool bHVAC_RFlag;
		public double dHVAC_Value;
		public int iSetSelfStudyDataRespValue;
		public int iSetSelfStudyDataRespCount;
		public int selfStudyCount;
		public int selfStudyPinNum;
		public int selfStudyProgress;
		public int selfStudyMainPinCount;
		public int[] firstPinArray;
		public int[] secondPinArray;
		public int iCorrectDataCount;
		public int iCorrectProcess;
		public int[] correctFirstPinArray;
		public int[] correctSecondPinArray;
		public double[] correctCompensationArray;
		public byte byteBridgeUnit;
		public System.Collections.Generic.List<TestCmdMap> mUpdataCmdArray;
		public System.Collections.Generic.List<TestCmdMap> mBCDataCmdArray;
		public bool bStopTestRespFlag;
		public KParseRepCmd()
		{
			this.dbPathStr = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" + "201820192020" + ";Data Source=" + Application.StartupPath + "\\ctsdb.mdb";
			string this2 = "";
			this.errorContentStr = this2;
			this.errorDateTimeStr = this2;
			this.uploadErrorContentStr = this2;
			this.uploadErrorDateTimeStr = this2;
			this.bDeviceErrorFlag = false;
			this.bUploadErrorFlag = false;
			this.bSetBridgeFreqErrFlag = false;
			this.bRecBridgeFreqFKFlag = false;
			this.bStopTestRespFlag = false;
			this.DeviceExist = false;
			this.DeviceConnectCount = 0;
			this.UpFinish = false;
			this.mnUpDataCount = 0;
			this.mnUpCmdCount = 0;
			this.mnDownCmdCount = 0;
			this.selfTestExPointCount = 0;
			this.selfTestDataCount = 0;
			this.selfTestOKCount = 0;
			this.selfTestEXCount = 0;
			this.selfTestProgress = 0;
			this.selfTestPointArray = new int[65536];
			this.selfTestExPointArray = new int[65536];
			this.iSetSelfStudyDataRespValue = 0;
			this.iSetSelfStudyDataRespCount = 0;
			this.selfStudyCount = 0;
			this.selfStudyPinNum = 0;
			this.selfStudyProgress = 0;
			this.selfStudyMainPinCount = 0;
			this.firstPinArray = new int[65536];
			this.secondPinArray = new int[65536];
			this.iCorrectDataCount = 0;
			this.iCorrectProcess = 0;
			this.correctFirstPinArray = new int[65536];
			this.correctSecondPinArray = new int[65536];
			this.correctCompensationArray = new double[65536];
			this.byteBridgeUnit = 0;
			this.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			this.mBCDataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
		}
		public void ExceptionRecordFunc(string exStr)
		{
			System.IO.StreamWriter sw = null;
			System.ValueType dt = System.DateTime.Now;
			string exfn = Application.StartupPath + "\\ExceptionLog_" + System.Convert.ToString(((System.DateTime)dt).Year) + ".txt";
			try
			{
				sw = new System.IO.StreamWriter(exfn, true, System.Text.Encoding.Default);
				System.DateTime value = ((System.DateTime)dt).ToLocalTime();
				sw.WriteLine(System.Convert.ToString(value) + " : " + exStr);
				sw.Close();
				sw = null;
			}
			catch (System.Exception ex_7B)
			{
				if (sw != null)
				{
					sw.Close();
				}
			}
		}
		public void EquipmentFaultRecordFunc(int iTypeIndex, string strEFaultTime, string strEFaultContent)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.dbPathStr;
					connection.Open();
					new OleDbCommand("insert into TEquipmentFaultRecord(EFaultTime,EFaultContent) values('" + strEFaultTime + "','" + strEFaultContent + "')", connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception ex)
				{
					this.ExceptionRecordFunc(ex.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception ex2)
			{
				this.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		public void ParseRepCmd(int nFrmID, byte[] pCmdBuf, int nCmdLen, System.Collections.Generic.List<TestCmdMap> marray)
		{
			try
			{
				if (null != pCmdBuf && nCmdLen == KParseRepCmd.RESPDATALEN)
				{
					this.mUpdataCmdArray = marray;
					int mID = nFrmID >> 16 & 255;
					this.DealRepCmd(mID, pCmdBuf);
				}
			}
			catch (System.Exception ex)
			{
				this.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void DealRepCmd(int mFrmID, byte[] pCmdBuf)
		{
			try
			{
				switch (mFrmID)
				{
				case 129:
				case 159:
					this.DeviceExist = true;
					break;
				case 138:
				{
					int temp = (((int)pCmdBuf[3] * 256 + (int)pCmdBuf[2]) * 256 + (int)pCmdBuf[1]) * 256 + (int)pCmdBuf[0];
					this.iSetSelfStudyDataRespValue = temp;
					this.iSetSelfStudyDataRespCount++;
					break;
				}
				case 145:
				{
					byte[] pdbuffer = new byte[4];
					for (int mi = 0; mi < 4; mi++)
					{
						pdbuffer[mi] = pCmdBuf[mi];
					}
					this.bDTJZRFlag = true;
					this.dDTJZValue = System.Math.Round((double)System.BitConverter.ToSingle(pdbuffer, 0), 3);
					break;
				}
				case 149:
				{
					int temp2 = (((int)pCmdBuf[3] * 256 + (int)pCmdBuf[2]) * 256 + (int)pCmdBuf[1]) * 256 + (int)pCmdBuf[0];
					this.bSetBridgeFreqErrFlag = false;
					if (temp2 == 4)
					{
						this.bSetBridgeFreqErrFlag = true;
					}
					else if (temp2 == 1)
					{
						this.bSetBridgeFreqErrFlag = false;
					}
					this.bRecBridgeFreqFKFlag = true;
					break;
				}
				case 151:
				{
					byte b = pCmdBuf[0];
					int temp3 = (((int)pCmdBuf[3] * 256 + (int)pCmdBuf[2]) * 256 + (int)pCmdBuf[1]) * 256 + (int)b;
					if ((b != 0 || pCmdBuf[4] != 0 || pCmdBuf[6] != 0) && (b != 1 || pCmdBuf[4] != 0 || pCmdBuf[6] != 0) && (b != 2 || pCmdBuf[4] != 0 || pCmdBuf[6] != 0))
					{
						int iFirstV = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
						int iSecondV = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
						this.correctFirstPinArray[this.iCorrectDataCount] = iFirstV;
						this.correctSecondPinArray[this.iCorrectDataCount] = iSecondV;
						this.correctCompensationArray[this.iCorrectDataCount] = (double)temp3 / 10000.0;
						int num = this.iCorrectDataCount + 1;
						this.iCorrectDataCount = num;
						this.iCorrectProcess = System.Convert.ToInt32((double)num * 100.0 * 1.52587890625E-05);
					}
					break;
				}
				case 152:
				{
					byte b2 = pCmdBuf[0];
					if (b2 == 255 && 255 == pCmdBuf[1] && 255 == pCmdBuf[2] && 255 == pCmdBuf[3])
					{
						int temp4 = (((int)pCmdBuf[7] * 256 + (int)pCmdBuf[6]) * 256 + (int)pCmdBuf[5]) * 256 + (int)pCmdBuf[4];
						this.selfTestExPointCount = temp4;
						this.selfTestProgress = 100;
					}
					else
					{
						int tempPoint = (((int)pCmdBuf[3] * 256 + (int)pCmdBuf[2]) * 256 + (int)pCmdBuf[1]) * 256 + (int)b2;
						if ((((int)pCmdBuf[7] * 256 + (int)pCmdBuf[6]) * 256 + (int)pCmdBuf[5]) * 256 + (int)pCmdBuf[4] == 1)
						{
							this.selfTestPointArray[this.selfTestOKCount] = tempPoint;
							this.selfTestOKCount++;
						}
						else
						{
							this.selfTestExPointArray[this.selfTestEXCount] = tempPoint;
							this.selfTestEXCount++;
						}
						this.selfTestDataCount++;
					}
					break;
				}
				case 155:
				{
					byte[] pdbuffer2 = new byte[4];
					for (int mi2 = 0; mi2 < 4; mi2++)
					{
						pdbuffer2[mi2] = pCmdBuf[mi2];
					}
					this.bHVDC_RFlag = true;
					double dTemp = (double)System.BitConverter.ToSingle(pdbuffer2, 0);
					dTemp /= 100.0;
					this.dHVDC_Value = System.Math.Round(dTemp, 2);
					break;
				}
				case 156:
				{
					byte[] pdbuffer3 = new byte[4];
					for (int mi3 = 0; mi3 < 4; mi3++)
					{
						pdbuffer3[mi3] = pCmdBuf[mi3];
					}
					this.bLVDC_RFlag = true;
					double dTemp2 = (double)System.BitConverter.ToSingle(pdbuffer3, 0);
					dTemp2 /= 100.0;
					this.dLVDC_Value = System.Math.Round(dTemp2, 2);
					break;
				}
				case 157:
				{
					byte[] pdbuffer4 = new byte[4];
					for (int mi4 = 0; mi4 < 4; mi4++)
					{
						pdbuffer4[mi4] = pCmdBuf[mi4];
					}
					this.bHVAC_RFlag = true;
					double dTemp3 = (double)System.BitConverter.ToSingle(pdbuffer4, 0);
					dTemp3 /= 100.0;
					this.dHVAC_Value = System.Math.Round(dTemp3, 2);
					break;
				}
				case 160:
					if (!this.bJYDZJZRFlag)
					{
						byte[] pdbuffer5 = new byte[4];
						for (int mi5 = 0; mi5 < 4; mi5++)
						{
							pdbuffer5[mi5] = pCmdBuf[mi5];
						}
						this.bJYDZJZRFlag = true;
						double dTemp4 = (double)System.BitConverter.ToSingle(pdbuffer5, 0);
						dTemp4 /= 1000.0;
						this.dJYDZJZValue = System.Math.Round(dTemp4, 3);
					}
					break;
				case 161:
				{
					byte[] pdbuffer6 = new byte[4];
					for (int mi6 = 0; mi6 < 4; mi6++)
					{
						pdbuffer6[mi6] = pCmdBuf[mi6];
					}
					this.bNYDLJZRFlag = true;
					double dTemp5 = (double)System.BitConverter.ToSingle(pdbuffer6, 0);
					dTemp5 /= 1000000.0;
					this.dNYDLJZValue = System.Math.Round(dTemp5, 3);
					break;
				}
				case 162:
				{
					byte[] respCmdArray = new byte[4];
					for (int ii = 0; ii < 4; ii++)
					{
						respCmdArray[ii] = pCmdBuf[ii];
					}
					int iIntValue = System.BitConverter.ToInt32(respCmdArray, 0);
					if (1 != iIntValue)
					{
					}
					this.bStopTestRespFlag = true;
					break;
				}
				case 163:
				{
					byte[] respCmdArray2 = new byte[4];
					for (int ii2 = 0; ii2 < 4; ii2++)
					{
						respCmdArray2[ii2] = pCmdBuf[ii2];
					}
					int iIntValue2 = System.BitConverter.ToInt32(respCmdArray2, 0);
					bool bErrorFlag = false;
					this.errorDateTimeStr = "";
					this.errorContentStr = "";
					if (1 != iIntValue2)
					{
						bErrorFlag = true;
					}
					this.bDeviceErrorFlag = bErrorFlag;
					if (bErrorFlag)
					{
						string strEFaultTime = System.Convert.ToString(((System.DateTime)System.DateTime.Now).ToLocalTime());
						this.errorDateTimeStr = strEFaultTime;
						string strEFaultContent = "安全保护开关未插入!";
						this.errorContentStr = strEFaultContent;
						this.EquipmentFaultRecordFunc(0, strEFaultTime, strEFaultContent);
					}
					break;
				}
				case 199:
				{
					byte[] pdbuffer7 = new byte[4];
					for (int mi7 = 0; mi7 < 4; mi7++)
					{
						pdbuffer7[mi7] = pCmdBuf[mi7];
					}
					double dTemp6 = (double)System.BitConverter.ToSingle(pdbuffer7, 0);
					dTemp6 = System.Math.Round(dTemp6, 3);
					int iFirstV2 = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
					TestCmdMap tcmdMap = new TestCmdMap();
					tcmdMap.mMainDevPinNum = iFirstV2;
					tcmdMap.mdTestResult = dTemp6;
					this.mUpdataCmdArray.Add(tcmdMap);
					break;
				}
				case 200:
				case 201:
				case 202:
				case 203:
				case 204:
				case 211:
					this.DealReceiveData(mFrmID, pCmdBuf);
					break;
				case 210:
				{
					byte[] respCmdArray3 = new byte[4];
					for (int ii3 = 0; ii3 < 4; ii3++)
					{
						respCmdArray3[ii3] = pCmdBuf[ii3];
					}
					int iIntValue3 = System.BitConverter.ToInt32(respCmdArray3, 0);
					bool bErrorFlag2 = false;
					this.errorDateTimeStr = "";
					this.errorContentStr = "";
					switch (iIntValue3)
					{
					case 16:
						this.uploadErrorContentStr = "直流高压电压源故障!";
						bErrorFlag2 = true;
						break;
					case 17:
						this.uploadErrorContentStr = "高压交流电压源故障!";
						bErrorFlag2 = true;
						break;
					case 18:
						this.uploadErrorContentStr = "系统安全开关处于断开状态!";
						bErrorFlag2 = true;
						break;
					case 19:
						this.uploadErrorContentStr = "绝缘短路故障!";
						bErrorFlag2 = true;
						break;
					case 20:
						this.uploadErrorContentStr = "耐压短路故障!";
						bErrorFlag2 = true;
						break;
					default:
						this.uploadErrorContentStr = "无故障!";
						break;
					}
					this.bUploadErrorFlag = bErrorFlag2;
					if (bErrorFlag2)
					{
						System.DateTime value = ((System.DateTime)System.DateTime.Now).ToLocalTime();
						this.uploadErrorDateTimeStr = System.Convert.ToString(value);
						string strEFaultContent2 = this.uploadErrorContentStr + (" 故障码: " + System.Convert.ToString(iIntValue3));
						this.uploadErrorContentStr = strEFaultContent2;
						string strEFaultTime2 = this.uploadErrorDateTimeStr;
						this.errorDateTimeStr = strEFaultTime2;
						this.errorContentStr = strEFaultContent2;
						this.EquipmentFaultRecordFunc(1, strEFaultTime2, strEFaultContent2);
					}
					break;
				}
				case 249:
					this.DeviceConnectCount = System.Convert.ToInt32(pCmdBuf[0]);
					break;
				case 251:
					if (pCmdBuf[0] == 1)
					{
						int iFirstV3 = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
						int iSecondV2 = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
						this.firstPinArray[this.selfStudyPinNum] = iFirstV3;
						this.secondPinArray[this.selfStudyPinNum] = iSecondV2;
						this.selfStudyPinNum++;
					}
					else
					{
						this.selfStudyProgress = 100;
					}
					break;
				case 252:
					if (pCmdBuf[0] == 1)
					{
						int iFirstV4 = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
						int iSecondV3 = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
						this.firstPinArray[this.selfStudyPinNum] = iFirstV4;
						this.secondPinArray[this.selfStudyPinNum] = iSecondV3;
						this.selfStudyPinNum++;
					}
					else
					{
						this.selfStudyProgress = 100;
					}
					break;
				}
			}
			catch (System.Exception ex)
			{
				this.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void DealReceiveData(int mFrmID, byte[] pCmdBuf)
		{
			try
			{
				if (mFrmID != 200)
				{
					if (mFrmID != 201)
					{
						if (mFrmID != 211)
						{
							byte[] pdbuffer = new byte[4];
							for (int mi = 0; mi < 4; mi++)
							{
								pdbuffer[mi] = pCmdBuf[mi];
							}
							float fTempValue = System.BitConverter.ToSingle(pdbuffer, 0);
							double nRepValue = System.Convert.ToDouble(fTempValue);
							int iFirstPoint = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
							int iSecendPoint = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
							TestCmdMap tempcmdinfo = new TestCmdMap();
							tempcmdinfo.mdTestResult = nRepValue;
							tempcmdinfo.mMainDevPinNum = iFirstPoint;
							tempcmdinfo.mSecDevPinNum = iSecendPoint;
							this.mUpdataCmdArray.Add(tempcmdinfo);
						}
						else
						{
							double num = (double)System.Convert.ToSingle((double)System.Convert.ToInt32(pCmdBuf[2]) / 100.0);
							float fTempValue = (float)((double)((float)(System.Convert.ToInt32((int)pCmdBuf[0] * 256) + System.Convert.ToInt32(pCmdBuf[1]))) + num);
							double nRepValue = System.Math.Round((double)fTempValue, 2);
							this.byteBridgeUnit = pCmdBuf[3];
							int iFirstPoint = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
							int iSecendPoint = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
							TestCmdMap tempcmdinfo = new TestCmdMap();
							tempcmdinfo.mdTestResult = nRepValue;
							tempcmdinfo.mMainDevPinNum = iFirstPoint;
							tempcmdinfo.mSecDevPinNum = iSecendPoint;
							this.mUpdataCmdArray.Add(tempcmdinfo);
						}
					}
					else
					{
						byte[] pdbuffer = new byte[4];
						for (int mi2 = 0; mi2 < 4; mi2++)
						{
							pdbuffer[mi2] = pCmdBuf[mi2];
						}
						float fTempValue = System.BitConverter.ToSingle(pdbuffer, 0);
						double nRepValue = System.Math.Round((double)fTempValue, 6);
						int iFirstPoint = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
						int iSecendPoint = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
						TestCmdMap tempcmdinfo = new TestCmdMap();
						tempcmdinfo.mdTestResult = nRepValue;
						tempcmdinfo.mMainDevPinNum = iFirstPoint;
						tempcmdinfo.mSecDevPinNum = iSecendPoint;
						this.mUpdataCmdArray.Add(tempcmdinfo);
					}
				}
				else
				{
					byte[] pdbuffer = new byte[4];
					for (int mi3 = 0; mi3 < 4; mi3++)
					{
						pdbuffer[mi3] = pCmdBuf[mi3];
					}
					float fTempValue = System.BitConverter.ToSingle(pdbuffer, 0);
					double nRepValue = System.Math.Round((double)fTempValue, 6);
					int iFirstPoint = (int)pCmdBuf[5] * 256 + (int)pCmdBuf[4];
					int iSecendPoint = (int)pCmdBuf[7] * 256 + (int)pCmdBuf[6];
					TestCmdMap tempcmdinfo = new TestCmdMap();
					tempcmdinfo.mdTestResult = nRepValue;
					tempcmdinfo.mMainDevPinNum = iFirstPoint;
					tempcmdinfo.mSecDevPinNum = iSecendPoint;
					this.mUpdataCmdArray.Add(tempcmdinfo);
				}
			}
			catch (System.Exception ex)
			{
				this.ExceptionRecordFunc(ex.StackTrace);
			}
		}
	}
}
