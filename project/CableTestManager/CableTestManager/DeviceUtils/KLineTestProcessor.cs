using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CableTestManager.DeviceUtils
{
	public class KLineTestProcessor
	{
		public static string PLUGPIN_UNDEFINED_STR = "未定义";
		public static int INT_DTTHRESHOLD_JD = 3;
		public static int INT_JYTHRESHOLD_JD = 2;
		public static int INT_JYTESTTIME_JD = 1;
		public static int INT_JYVOLTAGE_JD = 1;
		public static int INT_NYTHRESHOLD_JD = 2;
		public static int INT_NYTESTTIME_JD = 1;
		public static int INT_NYVOLTAGE_JD = 1;
		public ParStruct Par;
		public int iTestPreValue;
		public bool bIsTimeOut;
		public bool bIsConnSuccFlag;
		public int iTwoFourWireChoice;
		public int[] SelfFirst;
		public int[] SelfSecond;
		public int SELF_MAX_COUNT;
		public int iReportTemplateFormat;
		public int iJNTestedCount;
		public int iMaxCommonProjectNum;
		public bool bEmulationMode;
		public bool bUseRelayBoard;
		public string[] strAZArray;
		public string dbPathStr;
		public string mddbPathStr;
		public bool bOpenProjectFlag;
		public bool bAllStudyFlag;
		public int iJYTestDataShowStyle;
		public int iNYTestDataShowStyle;
		public bool bIsAdminFlag;
		public string loginUserID;
		public string loginUserPsw;
		public string loginUserName;
		public int iGroupTestDGVColCount;
		public KGroupTestParaInfo groupTestParaInfo;
		public int dev1;
		public int dev2;
		public int port1;
		public int port2;
		public int testtype;
		public int testcount;
		public int testtime;
		public int testvolt;
		public int currcount;
		public double dtoffset;
		public double mtimetick;
		public double ddtvolt;
		public double ddtcurr;
		public System.Collections.Generic.List<string> strPort1Array;
		public System.Collections.Generic.List<int> iPort1Array;
		public int gCurTestModal;
		public bool bDZBuChangFlag;
		public System.Collections.Generic.List<int> oneToMultList;
		public System.Collections.Generic.List<System.Collections.Generic.List<int>> oneToMultListList;
		public System.Collections.Generic.List<int> oneToMultIndex;
		public System.Collections.Generic.List<System.Collections.Generic.List<int>> oneToMultIndexList;
		public System.Collections.Generic.List<System.Collections.Generic.List<int>> gPinConnRelaInfoIndexList;
		public System.Collections.Generic.List<SDLPinConnectInfo> gPinConnInfoTempArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gPinConnInfoJYTempArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gPinConnInfoNYTempArray;
		public System.Collections.Generic.List<TestCmdMap> gTestCmdArray;
		public System.Collections.Generic.List<TestCmdMap> gFixResultArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gErgodicPinConnectInfoArray;
		public System.Collections.Generic.List<PinConnRelationStruct> gPinConnRelaInfoArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoSelfArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoSelf2Array;
		public System.Collections.Generic.List<int> gDLPinConnectInfoChoiceIndexList;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoChoiceArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoDLArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoDLTempArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoDLResultArray;
		public System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnectInfoDDJYArray;
		public System.Collections.Generic.List<int> mTestDevInfoArray;
		public System.Collections.Generic.List<TestCmdMap> mTestConnectInfoArray;
		public System.Collections.Generic.List<TestCmdMap> mCurTestCmdMapArray;
		public int jycount;
		public int mSendTestType;
		public int mDownCmdCount;
		public CanCmdEx[] mDownCmdBuf;
		public System.Collections.Generic.List<string> mRepCmdDescArray;
		public System.Collections.Generic.List<string> mFastTestJQNameList;
		public TestJNPinClass vecInt1;
		public System.Collections.Generic.List<TestJNPinClass> vecInt2;
		public System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>> vecInt3;
		public System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>> vecInt4;
		public System.Collections.Generic.List<JYNYTestStruct> mJYTestValueArray;
		public System.Collections.Generic.List<JYNYTestStruct> mNYTestValueArray;
		public System.Collections.Generic.List<string> ddjyTHeadNameList;
		public int nyCmdId;
		public bool mbKeepRun;
		public bool mhCurThreadFlag;
		public bool mhCurThreadFlagJY;
		public bool mhCurThreadFlagDDJY;
		public bool mhCurThreadFlagNY;
		public int[] iPlugPinStartArray;
		public int[] iPlugPinStopArray;
		public int iSelfStudyThreshold;
		public double dDLThresholdCoefficient;
		public KTestDevComm mpDevComm;
		public bool bResistanceCompFlag;
		public bool bAuxPowerSupplyFlag;
		public int iShowDefineColNum;
		public int iDTJYNYTestColNum;
		public bool bDTTestEnabled;
		public bool bDLTestEnabled;
		public bool bJYTestEnabled;
		public bool bDDJYTestEnabled;
		public bool bNYTestEnabled;
		public bool bSDNYTestEnabled;
		public bool bSDDRTestEnabled;
		public int iJYTestMethod;
		public int iNYTestMethod;
		public int iJYKTFailNum;
		public int iNYKTFailNum;
		public int iUIDisplayMode;
		public static int CHAR_MAX_LEN = 256;
		public bool bDTVoltCurrentShowFlag;
		public bool bJYHighLowModeShowFlag;
		public bool bUseEnglishAlphabetsIOQFlag;
		public KLineTestProcessor()
		{
			this.dbPathStr = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" + "201820192020" + ";Data Source=" + Application.StartupPath + "\\ctsdb.mdb";
			this.mddbPathStr = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=" + "201820192020" + ";Data Source=" + Application.StartupPath + "\\ctsmddb.mdb";
			this.bOpenProjectFlag = false;
			this.bAllStudyFlag = false;
			this.mpDevComm = new KTestDevComm();
			this.groupTestParaInfo = new KGroupTestParaInfo();
			this.iGroupTestDGVColCount = 4;
			this.bIsAdminFlag = false;
			string text = "";
			this.loginUserID = text;
			this.loginUserPsw = text;
			this.loginUserName = text;
			this.iJYTestDataShowStyle = 0;
			this.iNYTestDataShowStyle = 0;
			this.iJYTestMethod = 1;
			this.iNYTestMethod = 1;
			this.bDTTestEnabled = true;
			this.bDLTestEnabled = true;
			this.bJYTestEnabled = true;
			this.bDDJYTestEnabled = true;
			this.bNYTestEnabled = true;
			this.bSDNYTestEnabled = false;
			this.bSDDRTestEnabled = false;
			this.iShowDefineColNum = 5;
			this.iDTJYNYTestColNum = 4;
			this.SELF_MAX_COUNT = 1024;
			this.iMaxCommonProjectNum = 200;
			this.dDLThresholdCoefficient = 10.0;
			this.mbKeepRun = false;
			this.bDZBuChangFlag = true;
			this.mhCurThreadFlag = false;
			this.mhCurThreadFlagJY = false;
			this.mhCurThreadFlagDDJY = false;
			this.mhCurThreadFlagNY = false;
			this.iUIDisplayMode = 0;
			this.iTestPreValue = 0;
			this.mDownCmdCount = 0;
			this.iSelfStudyThreshold = 0;
			this.bEmulationMode = false;
			this.bUseRelayBoard = false;
			this.bDTVoltCurrentShowFlag = false;
			this.bJYHighLowModeShowFlag = false;
			this.bUseEnglishAlphabetsIOQFlag = false;
			this.oneToMultList = new System.Collections.Generic.List<int>();
			this.oneToMultListList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
			this.oneToMultIndex = new System.Collections.Generic.List<int>();
			this.oneToMultIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
			this.gDLPinConnectInfoChoiceIndexList = new System.Collections.Generic.List<int>();
			this.gDLPinConnectInfoChoiceArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
			this.gPinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gPinConnInfoJYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gPinConnInfoNYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gPinConnRelaInfoArray = new System.Collections.Generic.List<PinConnRelationStruct>();
			this.gDLPinConnectInfoArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gDLPinConnectInfoSelfArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gDLPinConnectInfoSelf2Array = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gDLPinConnectInfoDLArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.gDLPinConnectInfoDLTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			this.mJYTestValueArray = new System.Collections.Generic.List<JYNYTestStruct>();
			this.mNYTestValueArray = new System.Collections.Generic.List<JYNYTestStruct>();
			this.ddjyTHeadNameList = new System.Collections.Generic.List<string>();
			this.mFastTestJQNameList = new System.Collections.Generic.List<string>();
			this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
			this.vecInt1 = new TestJNPinClass();
			this.iPort1Array = new System.Collections.Generic.List<int>();
			this.strPort1Array = new System.Collections.Generic.List<string>();
			string[] this2 = new string[26];
			this.strAZArray = this2;
			this2[0] = "A";
			this2[1] = "B";
			this2[2] = "C";
			this2[3] = "D";
			this2[4] = "E";
			this2[5] = "F";
			this2[6] = "G";
			this2[7] = "H";
			this2[8] = "I";
			this2[9] = "J";
			this2[10] = "K";
			this2[11] = "L";
			this2[12] = "M";
			this2[13] = "N";
			this2[14] = "O";
			this2[15] = "P";
			this2[16] = "Q";
			this2[17] = "R";
			this2[18] = "S";
			this2[19] = "T";
			this2[20] = "U";
			this2[21] = "V";
			this2[22] = "W";
			this2[23] = "X";
			this2[24] = "Y";
			this2[25] = "Z";
		}
		public static void ExceptionRecordFunc(string exStr)
		{
			System.IO.StreamWriter sw = null;
			try
			{
				System.ValueType dt = System.DateTime.Now;
				sw = new System.IO.StreamWriter(Application.StartupPath + "\\ExceptionLog_" + System.Convert.ToString(((System.DateTime)dt).Year) + ".txt", true, System.Text.Encoding.Default);
				System.DateTime value = ((System.DateTime)dt).ToLocalTime();
				sw.WriteLine(System.Convert.ToString(value) + " : " + exStr);
				sw.Close();
				sw = null;
			}
			catch (System.Exception ex_79)
			{
				if (sw != null)
				{
					sw.Close();
				}
			}
		}
		public static string DecodeDisposeFunc(string sourceStr)
		{
			byte[] tempArray = null;
			string rStr = "";
			try
			{
				int iCount = 0;
				int iIndex = 0;
				tempArray = new byte[KLineTestProcessor.CHAR_MAX_LEN];
				for (int i = 0; i < KLineTestProcessor.CHAR_MAX_LEN; i++)
				{
					tempArray[i] = 0;
				}
				while (true)
				{
					try
					{
						string tempStr = sourceStr.Substring(iCount, 3);
						if (tempStr.Length < 3)
						{
							break;
						}
						short siTemp = System.Convert.ToInt16(tempStr);
						sbyte chTemp = (sbyte)siTemp;
						tempArray[iIndex] = 0;//chTemp;
						iIndex++;
					}
					catch (System.Exception ex_6D)
					{
						break;
					}
					iCount += 3;
				}
				rStr = System.Text.Encoding.Default.GetString(tempArray, 0, iIndex);
			}
			catch (System.Exception ex_8B)
			{
			}
			return rStr;
		}
		public unsafe static string EncrypDisposeFunc(string sourceStr)
		{
			string rStr = "";
			try
			{
				System.IntPtr value = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(sourceStr);
				sbyte* srcCharArray = (sbyte*)((void*)value);
				sbyte* ptr = srcCharArray;
				while (*(sbyte*)ptr != 0)
				{
					ptr += 1 / sizeof(sbyte);
				}
				int srcLen = 0;//ptr - (srcCharArray / sizeof(sbyte));
				for (int i = 0; i < srcLen; i++)
				{
					int iTemp = (int)(*(sbyte*)(i / sizeof(sbyte) + srcCharArray));
					string cStr = System.Convert.ToString(iTemp);
					while (3 > cStr.Length)
					{
						cStr = "0" + cStr;
					}
					rStr += cStr;
					if (*(sbyte*)(i / sizeof(sbyte) + srcCharArray) == 0)
					{
						break;
					}
				}
			}
			catch (System.Exception ex_79)
			{
			}
			return rStr;
		}
		public void InitRequiredParaFunc()
		{
			try
			{
				int this2 = this.SELF_MAX_COUNT;
				this.SelfFirst = new int[this2];
				this.SelfSecond = new int[this2];
				this.mDownCmdBuf = new CanCmdEx[this2];
				if (this.bDTTestEnabled)
				{
					this.iGroupTestDGVColCount++;
					this.iShowDefineColNum++;
					this.iDTJYNYTestColNum += 2;
				}
				bool flag = this.bJYTestEnabled;
				if (flag)
				{
					this.iShowDefineColNum++;
					this.iDTJYNYTestColNum += 2;
				}
				if (this.bNYTestEnabled)
				{
					this.iGroupTestDGVColCount += 3;
					this.iShowDefineColNum++;
					this.iDTJYNYTestColNum += 2;
				}
				if (this.bDLTestEnabled)
				{
					this.iShowDefineColNum++;
				}
				bool flag2 = this.bDDJYTestEnabled;
				if (flag2)
				{
					this.iShowDefineColNum++;
				}
				if (flag || flag2)
				{
					this.iGroupTestDGVColCount += 3;
				}
			}
			catch (System.Exception arg_F9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_F9_0.StackTrace);
			}
		}
		//public void ImportDevComm(KTestDevComm pDevComm)
		//{
		//	this.mpDevComm = pDevComm;
		//}
		public int MakeFrmID(int nCmdID, int masterid, int slaveid)
		{
			int nFrmID = 0;
			int nCmdID2;
			try
			{
				nFrmID = ((nCmdID + 256) * 1024 + masterid) * 64 + slaveid;
				return nFrmID;
			}
			catch (System.Exception arg_29_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_29_0.StackTrace);
				nCmdID2 = nFrmID;
			}
			return nCmdID2;
		}
		public int MakeFrmID(int nCmdID)
		{
			int nFrmID = 0;
			int nCmdID2;
			try
			{
				nFrmID = nCmdID * 65536 + 16777281;
				return nFrmID;
			}
			catch (System.Exception arg_22_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_22_0.StackTrace);
				nCmdID2 = nFrmID;
			}
			return nCmdID2;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartBatchTest(System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnInfoArray)
		{
			bool bStartThreadOk = false;
			this.gPinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			int i = 0;
			if (0 < gDLPinConnInfoArray.Count)
			{
				do
				{
					this.gPinConnInfoTempArray.Add(gDLPinConnInfoArray[i]);
					i++;
				}
				while (i < gDLPinConnInfoArray.Count);
			}
			this.mpDevComm.ClearTestCmdBuf();
			if (!this.mhCurThreadFlag && null != this.mpDevComm)
			{
				if (this.bEmulationMode)
				{
					this.mpDevComm.mnDownCmdCount = gDLPinConnInfoArray.Count;
				}
				else
				{
					ParStruct gDLPinConnInfoArray2 = this.Par;
					this.SendDTVlotAndCurrentCmd(gDLPinConnInfoArray2.dtVolt * 100.0, gDLPinConnInfoArray2.dtCurr);
					System.Threading.Thread.Sleep(100);
					this.SendTestCmd(this.mSendTestType, 50, 0f, gDLPinConnInfoArray, true);
					this.SendTestStartCmd();
				}
				this.mbKeepRun = true;
				this.mhCurThreadFlag = true;
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadBatchTestRepMonitor_Old)).Start();
				bStartThreadOk = true;
			}
			return bStartThreadOk;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartYJBatchTest(System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnInfoArray)
		{
			bool bStartThreadOk = false;
			this.gPinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			int i = 0;
			if (0 < gDLPinConnInfoArray.Count)
			{
				do
				{
					this.gPinConnInfoTempArray.Add(gDLPinConnInfoArray[i]);
					i++;
				}
				while (i < gDLPinConnInfoArray.Count);
			}
			this.mpDevComm.ClearTestCmdBuf();
			if (!this.mhCurThreadFlag && null != this.mpDevComm)
			{
				if (this.bEmulationMode)
				{
					this.mpDevComm.mnDownCmdCount = gDLPinConnInfoArray.Count;
				}
				else
				{
					ParStruct gDLPinConnInfoArray2 = this.Par;
					this.SendDTVlotAndCurrentCmd(gDLPinConnInfoArray2.dtVolt * 100.0, gDLPinConnInfoArray2.dtCurr);
					System.Threading.Thread.Sleep(100);
					this.SendTestCmd(this.mSendTestType, 50, 0f, gDLPinConnInfoArray, true);
					this.SendTestStartCmdYJ(1);
				}
				this.mbKeepRun = true;
				this.mhCurThreadFlag = true;
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadBatchTestRepMonitor_Old)).Start();
				bStartThreadOk = true;
			}
			return bStartThreadOk;
		}
		public void ThreadBatchTestRepMonitor_Old()
		{
			//try
			//{
			//	this.bIsTimeOut = false;
			//	if ((<Module>.??_B?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q52 & 1u) == 0u)
			//	{
			//		<Module>.??_B?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q52 |= 1u;
			//		try
			//		{
			//			<Module>.?WAIT_MAX_TIME@?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q4HA = 200;
			//		}
			//		catch
			//		{
			//			<Module>.??_B?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q52 &= 4294967294u;
			//			throw;
			//		}
			//	}
			//	int nWaitTime = 0;
			//	int upcount = 0;
			//	int ipre = 0;
			//	while (true)
			//	{
			//		KTestDevComm kTestDevComm = this.mpDevComm;
			//		if (this.mpDevComm.mUpdataCmdArray.Count <= kTestDevComm.mnDownCmdCount)
			//		{
			//			if (upcount != kTestDevComm.mUpdataCmdArray.Count)
			//			{
			//				nWaitTime = 0;
			//				upcount = this.mpDevComm.mUpdataCmdArray.Count;
			//			}
			//			int mnDownCmdCount = this.mpDevComm.mnDownCmdCount;
			//			if (mnDownCmdCount != 0)
			//			{
			//				ipre = System.Convert.ToInt32((double)upcount * 100.0 / (double)mnDownCmdCount);
			//			}
			//			if (ipre >= 100)
			//			{
			//				ipre = 100;
			//			}
			//			this.iTestPreValue = ipre;
			//			if (ipre == 100)
			//			{
			//				goto IL_FD;
			//			}
			//			if (3000 <= nWaitTime)
			//			{
			//				break;
			//			}
			//			System.Threading.Thread.Sleep(<Module>.?WAIT_MAX_TIME@?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q4HA);
			//			nWaitTime = <Module>.?WAIT_MAX_TIME@?2??ThreadBatchTestRepMonitor_Old@KLineTestProcessor@CableTestManager@@Q$AAMXXZ@$$Q4HA + nWaitTime;
			//		}
			//		if (!this.mbKeepRun || !this.mpDevComm.mbKeepRun)
			//		{
			//			goto IL_FD;
			//		}
			//	}
			//	this.bIsTimeOut = true;
			//	IL_FD:
			//	this.iTestPreValue = 100;
			//	this.mhCurThreadFlag = false;
			//	this.mbKeepRun = false;
			//}
			//catch (System.Exception arg_115_0)
			//{
			//	KLineTestProcessor.ExceptionRecordFunc(arg_115_0.StackTrace);
			//}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartBatchTest_New(System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnInfoArray)
		{
			bool bStartThreadOk = false;
			this.mpDevComm.ClearTestCmdBuf();
			if (!this.mhCurThreadFlag && null != this.mpDevComm)
			{
				if (this.bEmulationMode)
				{
					this.mpDevComm.mnDownCmdCount = gDLPinConnInfoArray.Count;
				}
				else
				{
					int iNumCount = 0;
					this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
					this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
					int i = 0;
					if (0 < gDLPinConnInfoArray.Count)
					{
						do
						{
							iNumCount++;
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)gDLPinConnInfoArray[i].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)gDLPinConnInfoArray[i].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
							if (iNumCount == 300)
							{
								this.vecInt3.Add(this.vecInt2);
								this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
								iNumCount = 0;
							}
							i++;
						}
						while (i < gDLPinConnInfoArray.Count);
						if (iNumCount == 300)
						{
							goto IL_105;
						}
					}
					this.vecInt3.Add(this.vecInt2);
				}
				IL_105:
				this.mbKeepRun = true;
				this.mhCurThreadFlag = true;
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadBatchTestRepMonitor_New)).Start();
				bStartThreadOk = true;
			}
			return bStartThreadOk;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartYJBatchTest_New(System.Collections.Generic.List<SDLPinConnectInfo> gDLPinConnInfoArray)
		{
			bool bStartThreadOk = false;
			this.mpDevComm.ClearTestCmdBuf();
			if (!this.mhCurThreadFlag && null != this.mpDevComm)
			{
				if (this.bEmulationMode)
				{
					this.mpDevComm.mnDownCmdCount = gDLPinConnInfoArray.Count;
				}
				else
				{
					int iNumCount = 0;
					this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
					this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
					int i = 0;
					if (0 < gDLPinConnInfoArray.Count)
					{
						do
						{
							iNumCount++;
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)gDLPinConnInfoArray[i].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)gDLPinConnInfoArray[i].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
							if (iNumCount == 300)
							{
								this.vecInt3.Add(this.vecInt2);
								this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
								iNumCount = 0;
							}
							i++;
						}
						while (i < gDLPinConnInfoArray.Count);
						if (iNumCount == 300)
						{
							goto IL_105;
						}
					}
					this.vecInt3.Add(this.vecInt2);
				}
				IL_105:
				this.mbKeepRun = true;
				this.mhCurThreadFlag = true;
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadBatchTestRepMonitor_New_YJ)).Start();
				bStartThreadOk = true;
			}
			return bStartThreadOk;
		}
		public void ThreadBatchTestRepMonitor_New()
		{
			try
			{
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 100;
				int iTTestCount = 0;
				for (int itc = 0; itc < this.vecInt3.Count; itc++)
				{
					iTTestCount = this.vecInt3[itc].Count + iTTestCount;
				}
				this.mpDevComm.mnDownCmdCount = iTTestCount;
				this.mpDevComm.mbUpLoadFinish = false;
				for (int ivi3 = 0; ivi3 < this.vecInt3.Count; ivi3++)
				{
					int iCurrTestCount = this.vecInt3[ivi3].Count;
					if (!this.bEmulationMode)
					{
						if (ivi3 > 0)
						{
							this.SendStopCmd();
							System.Threading.Thread.Sleep(400);
						}
						ParStruct par = this.Par;
						this.SendDTVlotAndCurrentCmd(par.dtVolt * 100.0, par.dtCurr);
						System.Threading.Thread.Sleep(50);
						this.SendTestCmd_GT_DT(5, ivi3);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
					}
					int nWaitTime = 0;
					int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
					double dPreValue;
					int iPreValue;
					while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
					{
						if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
						{
							upcount = this.mpDevComm.mUpdataCmdArray.Count;
							nWaitTime = 0;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 <= nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = 99;
						}
						this.iTestPreValue = iPreValue;
					}
					this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
					dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
					iPreValue = System.Convert.ToInt32(dPreValue);
					if (iPreValue >= 100)
					{
						iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
					}
					this.iTestPreValue = iPreValue;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlag = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_25C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25C_0.StackTrace);
			}
		}
		public void ThreadBatchTestRepMonitor_New_YJ()
		{
			try
			{
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 100;
				int iTTestCount = 0;
				for (int itc = 0; itc < this.vecInt3.Count; itc++)
				{
					iTTestCount = this.vecInt3[itc].Count + iTTestCount;
				}
				this.mpDevComm.mnDownCmdCount = iTTestCount;
				this.mpDevComm.mbUpLoadFinish = false;
				for (int ivi3 = 0; ivi3 < this.vecInt3.Count; ivi3++)
				{
					int iCurrTestCount = this.vecInt3[ivi3].Count;
					if (!this.bEmulationMode)
					{
						if (ivi3 > 0)
						{
							this.SendStopCmd();
							System.Threading.Thread.Sleep(400);
						}
						ParStruct par = this.Par;
						this.SendDTVlotAndCurrentCmd(par.dtVolt * 100.0, par.dtCurr);
						System.Threading.Thread.Sleep(50);
						this.SendTestCmd_GT_DT(5, ivi3);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmdYJ(1);
					}
					int nWaitTime = 0;
					int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
					double dPreValue;
					int iPreValue;
					while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
					{
						if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
						{
							upcount = this.mpDevComm.mUpdataCmdArray.Count;
							nWaitTime = 0;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 <= nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = 99;
						}
						this.iTestPreValue = iPreValue;
					}
					this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
					dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
					iPreValue = System.Convert.ToInt32(dPreValue);
					if (iPreValue >= 100)
					{
						iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
					}
					this.iTestPreValue = iPreValue;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlag = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_25D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25D_0.StackTrace);
			}
		}
		public void SendTestCmd(int nCmdType, int index)
		{
			try
			{
				if (this.mbKeepRun)
				{
					this.mDownCmdCount = 0;
					this.mDownCmdBuf = new CanCmdEx[this.vecInt3[index].Count];
					for (int i = 0; i < this.mDownCmdBuf.Length; i++)
					{
						this.mDownCmdBuf[i] = new CanCmdEx();
					}
					for (int j = 0; j < this.vecInt3[index].Count; j++)
					{
						int pin = this.vecInt3[index][j].mMainDevPinNum1;
						int pin2 = this.vecInt3[index][j].mMainDevPinNum2;
						if (pin != pin2)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf = new byte[8];
							this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(nCmdType);
							ushort uint16Temp = System.Convert.ToUInt16(pin);
							byte[] byteTemp = System.BitConverter.GetBytes(uint16Temp);
							int iIndex = 0;
							for (int k = 0; k < byteTemp.Length; k++)
							{
								this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[k];
								iIndex++;
							}
							uint16Temp = System.Convert.ToUInt16(pin2);
							byteTemp = System.BitConverter.GetBytes(uint16Temp);
							for (int l = 0; l < byteTemp.Length; l++)
							{
								this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[l];
								iIndex++;
							}
							this.mDownCmdCount++;
						}
					}
					if (null != this.mpDevComm)
					{
						for (int m = 0; m < this.mDownCmdCount; m++)
						{
							CanCmdEx canCmdEx = this.mDownCmdBuf[m];
							this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
							System.Threading.Thread.Sleep(1);
						}
					}
					System.Threading.Thread.Sleep(100);
				}
			}
			catch (System.Exception arg_1D3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D3_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SendTestCmd(int nCmdType, int nParam, float fParam, System.Collections.Generic.List<SDLPinConnectInfo> dlConnectInfoArray, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bStartNow)
		{
			if (dlConnectInfoArray.Count > 0)
			{
				this.mDownCmdBuf = new CanCmdEx[dlConnectInfoArray.Count];
				int jjj = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					do
					{
						this.mDownCmdBuf[jjj] = new CanCmdEx();
						jjj++;
					}
					while (jjj < dlConnectInfoArray.Count);
				}
			}
			this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			this.mDownCmdCount = 0;
			switch (nCmdType)
			{
			case 5:
			{
				int i = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					while (i < 65536)
					{
						if (dlConnectInfoArray[i].iAMeasMethod == 0 && dlConnectInfoArray[i].iBMeasMethod == 0)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(5, dlConnectInfoArray[i].mnMainDevNum, dlConnectInfoArray[i].mnSecDevNum);
							int iBufIndex = 0;
							ushort mTemp = System.Convert.ToUInt16(dlConnectInfoArray[i].mnMainPinNum);
							byte[] byteArray = System.BitConverter.GetBytes(mTemp);
							int j = 0;
							if (0 < byteArray.Length)
							{
								do
								{
									this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iBufIndex] = byteArray[j];
									iBufIndex++;
									j++;
								}
								while (j < byteArray.Length);
							}
							ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i].mnSecPinNum);
							byte[] byteSArray = System.BitConverter.GetBytes(sTemp);
							int k = 0;
							if (0 < byteSArray.Length)
							{
								do
								{
									this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iBufIndex] = byteSArray[k];
									iBufIndex++;
									k++;
								}
								while (k < byteSArray.Length);
							}
							this.mDownCmdCount++;
						}
						i++;
						if (i >= dlConnectInfoArray.Count)
						{
							break;
						}
					}
				}
				int l = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					while (l < 65536)
					{
						if (dlConnectInfoArray[l].iAMeasMethod == 1 || dlConnectInfoArray[l].iBMeasMethod == 1)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(6, dlConnectInfoArray[l].mnMainDevNum, dlConnectInfoArray[l].mnSecDevNum);
							int iBufIndex = 0;
							ushort mTemp = System.Convert.ToUInt16(dlConnectInfoArray[l].mnMainPinNum);
							byte[] byteArray = System.BitConverter.GetBytes(mTemp);
							int m = 0;
							if (0 < byteArray.Length)
							{
								do
								{
									this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iBufIndex] = byteArray[m];
									iBufIndex++;
									m++;
								}
								while (m < byteArray.Length);
							}
							ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[l].mnSecPinNum);
							byte[] byteSArray = System.BitConverter.GetBytes(sTemp);
							int n = 0;
							if (0 < byteSArray.Length)
							{
								do
								{
									this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iBufIndex] = byteSArray[n];
									iBufIndex++;
									n++;
								}
								while (n < byteSArray.Length);
							}
							this.mDownCmdCount++;
						}
						l++;
						if (l >= dlConnectInfoArray.Count)
						{
							break;
						}
					}
				}
				break;
			}
			case 6:
			{
				int i2 = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					do
					{
						this.mDownCmdBuf[i2].mnFrmId = this.MakeFrmID(6, dlConnectInfoArray[i2].mnMainDevNum, dlConnectInfoArray[i2].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i2].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k2 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i2].mCmdBuf[iBufIndex] = byteArray[k2];
								iBufIndex++;
								k2++;
							}
							while (k2 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i2].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k3 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i2].mCmdBuf[iBufIndex] = byteArray[k3];
								iBufIndex++;
								k3++;
							}
							while (k3 < byteArray.Length);
						}
						this.mDownCmdCount++;
						i2++;
					}
					while (i2 < dlConnectInfoArray.Count);
				}
				break;
			}
			case 7:
			{
				int i3 = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					while (i3 < 65536)
					{
						this.mDownCmdBuf[i3].mnFrmId = this.MakeFrmID(7, dlConnectInfoArray[i3].mnMainDevNum, dlConnectInfoArray[i3].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i3].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k4 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i3].mCmdBuf[iBufIndex] = byteArray[k4];
								iBufIndex++;
								k4++;
							}
							while (k4 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i3].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k5 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i3].mCmdBuf[iBufIndex] = byteArray[k5];
								iBufIndex++;
								k5++;
							}
							while (k5 < byteArray.Length);
						}
						this.mDownCmdCount++;
						i3++;
						if (i3 >= dlConnectInfoArray.Count)
						{
							break;
						}
					}
				}
				break;
			}
			case 8:
			{
				int i4 = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					while (i4 < 65536)
					{
						this.mDownCmdBuf[i4].mnFrmId = this.MakeFrmID(8, dlConnectInfoArray[i4].mnMainDevNum, dlConnectInfoArray[i4].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i4].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k6 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i4].mCmdBuf[iBufIndex] = byteArray[k6];
								iBufIndex++;
								k6++;
							}
							while (k6 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i4].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k7 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i4].mCmdBuf[iBufIndex] = byteArray[k7];
								iBufIndex++;
								k7++;
							}
							while (k7 < byteArray.Length);
						}
						this.mDownCmdCount++;
						i4++;
						if (i4 >= dlConnectInfoArray.Count)
						{
							break;
						}
					}
				}
				break;
			}
			case 9:
			{
				int i5 = 0;
				if (0 < dlConnectInfoArray.Count)
				{
					while (i5 < 65536)
					{
						this.mDownCmdBuf[i5].mnFrmId = this.MakeFrmID(9, dlConnectInfoArray[i5].mnMainDevNum, dlConnectInfoArray[i5].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i5].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k8 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i5].mCmdBuf[iBufIndex] = byteArray[k8];
								iBufIndex++;
								k8++;
							}
							while (k8 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i5].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k9 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i5].mCmdBuf[iBufIndex] = byteArray[k9];
								iBufIndex++;
								k9++;
							}
							while (k9 < byteArray.Length);
						}
						this.mDownCmdCount++;
						i5++;
						if (i5 >= dlConnectInfoArray.Count)
						{
							break;
						}
					}
				}
				break;
			}
			}
			this.mpDevComm.mnDownCmdCount = this.mDownCmdCount;
			if (bStartNow && null != this.mpDevComm)
			{
				int i6 = 0;
				if (0 < this.mDownCmdCount)
				{
					do
					{
						CanCmdEx canCmdEx = this.mDownCmdBuf[i6];
						this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
						System.Threading.Thread.Sleep(1);
						i6++;
					}
					while (i6 < this.mDownCmdCount);
				}
			}
			System.Threading.Thread.Sleep(100);
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SendTestCmd_CC(int nCmdType, int nParam, float fParam, System.Collections.Generic.List<SDLPinConnectInfo> dlConnectInfoArray, int iCCcount, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bStartNow)
		{
			if (iCCcount > 0)
			{
				this.mDownCmdBuf = new CanCmdEx[iCCcount];
				int jjj = 0;
				if (0 < iCCcount)
				{
					do
					{
						this.mDownCmdBuf[jjj] = new CanCmdEx();
						jjj++;
					}
					while (jjj < iCCcount);
				}
			}
			int iDCCount = 0;
			switch (nCmdType)
			{
			case 5:
			{
				int i = 0;
				if (0 < iCCcount)
				{
					while (i < dlConnectInfoArray.Count)
					{
						if (dlConnectInfoArray[i].iAMeasMethod == 0 && dlConnectInfoArray[i].iBMeasMethod == 0)
						{
							this.mDownCmdBuf[iDCCount].mnFrmId = this.MakeFrmID(5, dlConnectInfoArray[i].mnMainDevNum, dlConnectInfoArray[i].mnSecDevNum);
							int iBufIndex = 0;
							ushort mTemp = System.Convert.ToUInt16(dlConnectInfoArray[i].mnMainPinNum);
							byte[] byteArray = System.BitConverter.GetBytes(mTemp);
							int j = 0;
							if (0 < byteArray.Length)
							{
								do
								{
									this.mDownCmdBuf[iDCCount].mCmdBuf[iBufIndex] = byteArray[j];
									iBufIndex++;
									j++;
								}
								while (j < byteArray.Length);
							}
							ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i].mnSecPinNum);
							byte[] byteSArray = System.BitConverter.GetBytes(sTemp);
							int k = 0;
							if (0 < byteSArray.Length)
							{
								do
								{
									this.mDownCmdBuf[iDCCount].mCmdBuf[iBufIndex] = byteSArray[k];
									iBufIndex++;
									k++;
								}
								while (k < byteSArray.Length);
							}
							iDCCount++;
						}
						i++;
						if (i >= iCCcount)
						{
							break;
						}
					}
				}
				int l = 0;
				if (0 < iCCcount)
				{
					while (l < dlConnectInfoArray.Count)
					{
						if (dlConnectInfoArray[l].iAMeasMethod == 1 || dlConnectInfoArray[l].iBMeasMethod == 1)
						{
							this.mDownCmdBuf[iDCCount].mnFrmId = this.MakeFrmID(6, dlConnectInfoArray[l].mnMainDevNum, dlConnectInfoArray[l].mnSecDevNum);
							int iBufIndex = 0;
							ushort mTemp = System.Convert.ToUInt16(dlConnectInfoArray[l].mnMainPinNum);
							byte[] byteArray = System.BitConverter.GetBytes(mTemp);
							int m = 0;
							if (0 < byteArray.Length)
							{
								do
								{
									this.mDownCmdBuf[iDCCount].mCmdBuf[iBufIndex] = byteArray[m];
									iBufIndex++;
									m++;
								}
								while (m < byteArray.Length);
							}
							ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[l].mnSecPinNum);
							byte[] byteSArray = System.BitConverter.GetBytes(sTemp);
							int n = 0;
							if (0 < byteSArray.Length)
							{
								do
								{
									this.mDownCmdBuf[iDCCount].mCmdBuf[iBufIndex] = byteSArray[n];
									iBufIndex++;
									n++;
								}
								while (n < byteSArray.Length);
							}
							iDCCount++;
						}
						l++;
						if (l >= iCCcount)
						{
							break;
						}
					}
				}
				break;
			}
			case 6:
			{
				int i2 = 0;
				if (0 < iCCcount)
				{
					iDCCount = iCCcount;
					do
					{
						this.mDownCmdBuf[i2].mnFrmId = this.MakeFrmID(6, dlConnectInfoArray[i2].mnMainDevNum, dlConnectInfoArray[i2].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i2].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k2 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i2].mCmdBuf[iBufIndex] = byteArray[k2];
								iBufIndex++;
								k2++;
							}
							while (k2 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i2].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k3 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i2].mCmdBuf[iBufIndex] = byteArray[k3];
								iBufIndex++;
								k3++;
							}
							while (k3 < byteArray.Length);
						}
						i2++;
					}
					while (i2 < iCCcount);
				}
				break;
			}
			case 7:
			{
				int i3 = 0;
				if (0 < iCCcount)
				{
					while (i3 < dlConnectInfoArray.Count)
					{
						this.mDownCmdBuf[i3].mnFrmId = this.MakeFrmID(7, dlConnectInfoArray[i3].mnMainDevNum, dlConnectInfoArray[i3].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i3].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k4 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i3].mCmdBuf[iBufIndex] = byteArray[k4];
								iBufIndex++;
								k4++;
							}
							while (k4 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i3].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k5 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i3].mCmdBuf[iBufIndex] = byteArray[k5];
								iBufIndex++;
								k5++;
							}
							while (k5 < byteArray.Length);
						}
						iDCCount++;
						i3++;
						if (i3 >= iCCcount)
						{
							break;
						}
					}
				}
				break;
			}
			case 8:
			{
				int i4 = 0;
				if (0 < iCCcount)
				{
					while (i4 < dlConnectInfoArray.Count)
					{
						this.mDownCmdBuf[i4].mnFrmId = this.MakeFrmID(8, dlConnectInfoArray[i4].mnMainDevNum, dlConnectInfoArray[i4].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i4].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k6 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i4].mCmdBuf[iBufIndex] = byteArray[k6];
								iBufIndex++;
								k6++;
							}
							while (k6 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i4].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k7 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i4].mCmdBuf[iBufIndex] = byteArray[k7];
								iBufIndex++;
								k7++;
							}
							while (k7 < byteArray.Length);
						}
						iDCCount++;
						i4++;
						if (i4 >= iCCcount)
						{
							break;
						}
					}
				}
				break;
			}
			case 9:
			{
				int i5 = 0;
				if (0 < iCCcount)
				{
					while (i5 < dlConnectInfoArray.Count)
					{
						this.mDownCmdBuf[i5].mnFrmId = this.MakeFrmID(9, dlConnectInfoArray[i5].mnMainDevNum, dlConnectInfoArray[i5].mnSecDevNum);
						int iBufIndex = 0;
						ushort sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i5].mnMainPinNum);
						byte[] byteArray = System.BitConverter.GetBytes(sTemp);
						int k8 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i5].mCmdBuf[iBufIndex] = byteArray[k8];
								iBufIndex++;
								k8++;
							}
							while (k8 < byteArray.Length);
						}
						sTemp = System.Convert.ToUInt16(dlConnectInfoArray[i5].mnSecPinNum);
						byteArray = System.BitConverter.GetBytes(sTemp);
						int k9 = 0;
						if (0 < byteArray.Length)
						{
							do
							{
								this.mDownCmdBuf[i5].mCmdBuf[iBufIndex] = byteArray[k9];
								iBufIndex++;
								k9++;
							}
							while (k9 < byteArray.Length);
						}
						iDCCount++;
						i5++;
						if (i5 >= iCCcount)
						{
							break;
						}
					}
				}
				break;
			}
			}
			if (bStartNow && null != this.mpDevComm)
			{
				int i6 = 0;
				if (0 < iDCCount)
				{
					do
					{
						CanCmdEx canCmdEx = this.mDownCmdBuf[i6];
						this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
						System.Threading.Thread.Sleep(1);
						i6++;
					}
					while (i6 < iDCCount);
				}
			}
			System.Threading.Thread.Sleep(100);
			return false;
		}
		public void swapFunc(byte rcValue1, byte rcValue2)
		{
		}
		public void SendTestStartCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.Par.testDelay);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(14);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_45_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_45_0.StackTrace);
			}
		}
		public void SendTestStartCmdYJ(byte byteYJFlag)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.Par.testDelay);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				canCmdBuf[6] = byteYJFlag;
				int framid = this.MakeFrmID(14);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_49_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
			}
		}
		public void SendTestStartCmdNew(byte byteKMNum)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.Par.testDelay);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				canCmdBuf[4] = byteKMNum;
				int framid = this.MakeFrmID(14);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_49_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
			}
		}
		public void SendTestStartCmdTZ()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.Par.testDelay);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				canCmdBuf[6] = 1;
				int framid = this.MakeFrmID(14);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_49_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
			}
		}
		public void SendStopCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(34);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				this.mpDevComm.ClearTestCmdBuf();
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_35_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_35_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public unsafe bool MakeConnectTestCmd(int nMainDevID, int nMainPinCount, int* pMainPins, int nSecDevID, int nSecPinCount, int* pSecPins, int nGroupType)
		{
			if (null != pMainPins && null != pSecPins)
			{
				System.Collections.Generic.List<TestCmdMap> pSecPins2 = this.mCurTestCmdMapArray;
				if (pSecPins2 != null)
				{
					pSecPins2.Clear();
				}
				TestCmdMap cmdMap = new TestCmdMap();
				cmdMap.mMainDevID = nMainDevID;
				cmdMap.mSecDevID = nSecDevID;
				cmdMap.mdTestResult = 0.0;
				if (1 == nGroupType)
				{
					int nSecPinCount2;
					if (nMainPinCount > nSecPinCount)
					{
						nSecPinCount2 = nSecPinCount;
					}
					else
					{
						nSecPinCount2 = nMainPinCount;
					}
					if (0 < nSecPinCount2)
					{
						int* pMainPins2 = pSecPins;
						int nGroupType2 = 0; // pMainPins - pSecPins / 4;
						int nSecDevID2 = nSecPinCount2;
						do
						{
							cmdMap.mMainDevPinNum = 0;// (nGroupType2 / 4)[pMainPins2];
							cmdMap.mSecDevPinNum = *pMainPins2;
							this.mCurTestCmdMapArray.Add(cmdMap);
							pMainPins2++;
							nSecDevID2--;
						}
						while (nSecDevID2 != 0);
					}
				}
				else if (2 == nGroupType)
				{
					int i = 0;
					if (0 < nSecPinCount)
					{
						do
						{
							cmdMap.mSecDevPinNum = 0;// i[pSecPins];
							int j = 0;
							if (0 < nMainPinCount)
							{
								do
								{
									cmdMap.mMainDevPinNum = 0;// j[pMainPins];
									this.mCurTestCmdMapArray.Add(cmdMap);
									j++;
								}
								while (j < nMainPinCount);
							}
							i++;
						}
						while (i < nSecPinCount);
					}
				}
			}
			return false;
		}
		public void ThreadJYMonitor()
		{
			try
			{
				this.iJYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(7);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagJY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmd();
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double JYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYTestTime);
								double JYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYVoltage);
								this.SendNYTimeCmd(JYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndDCVlotCmd(JYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(7, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmd();
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_63D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_63D_0.StackTrace);
			}
		}
		public void ThreadJYCTMonitor()
		{
			try
			{
				this.iJYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(7);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagJY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmd();
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double JYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYTestTime);
								double JYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYVoltage);
								this.SendNYTimeCmd(JYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndDCVlotCmd(JYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(7, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmd();
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_63D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_63D_0.StackTrace);
			}
		}
		public void ThreadJYKCMonitor()
		{
			try
			{
				this.iJYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(7);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagJY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmdNew(1);
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double JYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYTestTime);
								double JYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestJYParaStructList[ivi4].JYVoltage);
								this.SendNYTimeCmd(JYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndDCVlotCmd(JYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(7, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmdNew(1);
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_63F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_63F_0.StackTrace);
			}
		}
		public void ThreadDDJYMonitor()
		{
			try
			{
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray.Clear();
				if (this.bEmulationMode)
				{
					while (this.mbKeepRun && this.iTestPreValue != 100)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					int i = 0;
					while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun)
					{
						this.mpDevComm.mnDownCmdCount = 1;
						this.mpDevComm.mbUpLoadFinish = false;
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestFreeCmd(19, i, 1);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
						int nWaitTime = 0;
						while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 < nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
						}
						int num = i + 1;
						int upcount = num;
						int pre = 1;
						if (this.vecInt3.Count > 0)
						{
							pre = System.Convert.ToInt32((double)upcount * 100.0 / (double)this.vecInt3.Count);
							if (pre >= 100)
							{
								pre = 99;
							}
						}
						this.iTestPreValue = pre;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						i = num;
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagDDJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_18F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18F_0.StackTrace);
			}
		}
		public void ThreadJYMonitor_OLD()
		{
			try
			{
				this.iJYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun && this.iJYKTFailNum <= 0)
				{
					this.mpDevComm.mnDownCmdCount = 1;
					this.mpDevComm.mbUpLoadFinish = false;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(7, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
					}
					this.iJNTestedCount++;
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 <= nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					int num = i + 1;
					int upcount = num;
					int pre = 1;
					if (this.vecInt3.Count > 0)
					{
						pre = System.Convert.ToInt32((double)upcount * 100.0 / (double)this.vecInt3.Count);
						if (pre >= 100)
						{
							pre = 100;
						}
					}
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_195_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_195_0.StackTrace);
			}
		}
		public void ThreadJYKCMonitor_OLD()
		{
			try
			{
				this.iJYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun && this.iJYKTFailNum <= 0)
				{
					this.mpDevComm.mnDownCmdCount = 1;
					this.mpDevComm.mbUpLoadFinish = false;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(7, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmdNew(1);
					}
					this.iJNTestedCount++;
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 <= nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					int num = i + 1;
					int upcount = num;
					int pre = 1;
					if (this.vecInt3.Count > 0)
					{
						pre = System.Convert.ToInt32((double)upcount * 100.0 / (double)this.vecInt3.Count);
						if (pre >= 100)
						{
							pre = 100;
						}
					}
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_196_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_196_0.StackTrace);
			}
		}
		public void ThreadDDJYMonitor_OLD()
		{
			try
			{
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray.Clear();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun)
				{
					this.mpDevComm.mnDownCmdCount = 1;
					this.mpDevComm.mbUpLoadFinish = false;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.jyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(7, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
					}
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 < nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					int num = i + 1;
					int upcount = num;
					int pre = 1;
					if (this.vecInt3.Count > 0)
					{
						pre = System.Convert.ToInt32((double)upcount * 100.0 / (double)this.vecInt3.Count);
						if (pre >= 100)
						{
							pre = 100;
						}
					}
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagDDJY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_16D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_16D_0.StackTrace);
			}
		}
		public void JYNYFilterOneToMultRelationFunc(int iIndex, System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			try
			{
				this.oneToMultList.Clear();
				this.oneToMultListList.Clear();
				this.oneToMultList = new System.Collections.Generic.List<int>();
				this.oneToMultListList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
				try
				{
					int i = 0;
					IL_3A:
					while (i < pinConnectInfoArray.Count)
					{
						ushort mnMainPinNum = pinConnectInfoArray[i].mnMainPinNum;
						ushort mnSecPinNum = pinConnectInfoArray[i].mnSecPinNum;
						bool bExistFlag = false;
						int jj = 0;
						while (jj < this.oneToMultListList.Count)
						{
							for (int kk = 0; kk < this.oneToMultListList[jj].Count; kk++)
							{
								if (this.oneToMultListList[jj][kk] == (int)mnMainPinNum || this.oneToMultListList[jj][kk] == (int)mnSecPinNum)
								{
									goto IL_20F;
								}
							}
							if (!bExistFlag)
							{
								jj++;
								continue;
							}
							IL_20F:
							i++;
							goto IL_3A;
						}
						bool bFirstFlag = false;
						for (int j = i + 1; j < pinConnectInfoArray.Count; j++)
						{
							ushort mnMainPinNum2;
							ushort mnSecPinNum2;
							if (bFirstFlag)
							{
								while (j < pinConnectInfoArray.Count)
								{
									mnMainPinNum2 = pinConnectInfoArray[j].mnMainPinNum;
									mnSecPinNum2 = pinConnectInfoArray[j].mnSecPinNum;
									for (int k = 0; k < this.oneToMultList.Count; k++)
									{
										if (this.oneToMultList[k] == (int)mnMainPinNum2 || this.oneToMultList[k] == (int)mnSecPinNum2)
										{
											this.oneToMultList.Add((int)mnMainPinNum2);
											this.oneToMultList.Add((int)mnSecPinNum2);
											break;
										}
									}
									j++;
								}
								break;
							}
							mnMainPinNum2 = pinConnectInfoArray[j].mnMainPinNum;
							mnSecPinNum2 = pinConnectInfoArray[j].mnSecPinNum;
							if (mnMainPinNum == mnMainPinNum2 || mnSecPinNum == mnMainPinNum2 || mnMainPinNum == mnSecPinNum2 || mnSecPinNum == mnSecPinNum2)
							{
								bFirstFlag = true;
								System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
								this.oneToMultList = list;
								list.Add((int)mnMainPinNum);
								this.oneToMultList.Add((int)mnSecPinNum);
								this.oneToMultList.Add((int)mnMainPinNum2);
								this.oneToMultList.Add((int)mnSecPinNum2);
							}
						}
						if (bFirstFlag)
						{
							this.oneToMultListList.Add(this.oneToMultList);
							//goto IL_20F;
						}
						//goto IL_20F;
					}
				}
				catch (System.Exception arg_21C_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_21C_0.StackTrace);
				}
				bool[] bArrayIndex = new bool[pinConnectInfoArray.Count];
				for (int bb = 0; bb < bArrayIndex.Length; bb++)
				{
					bArrayIndex[bb] = false;
				}
				for (int l = 0; l < pinConnectInfoArray.Count; l++)
				{
					bool bExistFlag = false;
					ushort mnMainPinNum = pinConnectInfoArray[l].mnMainPinNum;
					ushort mnSecPinNum = pinConnectInfoArray[l].mnSecPinNum;
					for (int m = 0; m < this.oneToMultListList.Count; m++)
					{
						bool bFindMainFlag = false;
						bool bFindSecFlag = false;
						for (int nn = 0; nn < this.oneToMultListList[m].Count; nn++)
						{
							if ((int)mnMainPinNum == this.oneToMultListList[m][nn])
							{
								bFindMainFlag = true;
							}
							if ((int)mnSecPinNum == this.oneToMultListList[m][nn])
							{
								bFindSecFlag = true;
							}
							if (bFindMainFlag && bFindSecFlag)
							{
								IL_305:
								bArrayIndex[l] = true;
								goto IL_30B;
							}
						}
						if (bExistFlag)
						{
							//goto IL_305;
						}
					}
					IL_30B:;
				}
				int n = 0;
				IL_319:
				while (n < pinConnectInfoArray.Count)
				{
					bool bExistFlag = false;
					ushort mnMainPinNum = pinConnectInfoArray[n].mnMainPinNum;
					ushort mnSecPinNum = pinConnectInfoArray[n].mnSecPinNum;
					for (int n2 = 0; n2 < this.oneToMultListList.Count; n2++)
					{
						if ((int)mnMainPinNum == this.oneToMultListList[n2][0] && (int)mnSecPinNum == this.oneToMultListList[n2][1])
						{
							IL_391:
							bArrayIndex[n] = false;
							IL_397:
							n++;
							goto IL_319;
						}
					}
					if (bExistFlag)
					{
						//goto IL_391;
					}
					//goto IL_397;
				}
				System.Collections.Generic.List<SDLPinConnectInfo> gTemoArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				for (int gg = 0; gg < bArrayIndex.Length; gg++)
				{
					if (!bArrayIndex[gg])
					{
						gTemoArray.Add(pinConnectInfoArray[gg]);
					}
				}
				if (iIndex == 0)
				{
					this.gPinConnInfoJYTempArray.Clear();
					this.gPinConnInfoJYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
					for (int yy = 0; yy < gTemoArray.Count; yy++)
					{
						this.gPinConnInfoJYTempArray.Add(gTemoArray[yy]);
					}
				}
				else if (iIndex == 1)
				{
					this.gPinConnInfoNYTempArray.Clear();
					this.gPinConnInfoNYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
					for (int yy2 = 0; yy2 < gTemoArray.Count; yy2++)
					{
						this.gPinConnInfoNYTempArray.Add(gTemoArray[yy2]);
					}
				}
			}
			catch (System.Exception arg_45A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_45A_0.StackTrace);
			}
		}
		public void JYNYFilterMultToMultRelationFunc(int iIndex, System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			try
			{
				this.oneToMultList.Clear();
				this.oneToMultListList.Clear();
				this.oneToMultList = new System.Collections.Generic.List<int>();
				this.oneToMultListList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
				this.oneToMultIndex = new System.Collections.Generic.List<int>();
				this.oneToMultIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
				try
				{
					int i = 0;
					IL_57:
					while (i < pinConnectInfoArray.Count)
					{
						bool bIsExistFlag = false;
						ushort mnMainPinNum = pinConnectInfoArray[i].mnMainPinNum;
						ushort mnSecPinNum = pinConnectInfoArray[i].mnSecPinNum;
						int jj = 0;
						while (jj < this.oneToMultListList.Count)
						{
							bool bExistFlag = false;
							bool bExist2Flag = false;
							for (int kk = 0; kk < this.oneToMultListList[jj].Count; kk++)
							{
								if (this.oneToMultListList[jj][kk] == (int)mnMainPinNum)
								{
									bExistFlag = true;
								}
								if (this.oneToMultListList[jj][kk] == (int)mnSecPinNum)
								{
									bExist2Flag = true;
								}
								if (bExistFlag && bExist2Flag)
								{
									goto IL_2D2;
								}
							}
							if (!bIsExistFlag)
							{
								jj++;
								continue;
							}
							IL_2D2:
							i++;
							goto IL_57;
						}
						bool bFirstFlag = false;
						for (int j = i + 1; j < pinConnectInfoArray.Count; j++)
						{
							ushort mnMainPinNum2;
							ushort mnSecPinNum2;
							if (bFirstFlag)
							{
								while (j < pinConnectInfoArray.Count)
								{
									mnMainPinNum2 = pinConnectInfoArray[j].mnMainPinNum;
									mnSecPinNum2 = pinConnectInfoArray[j].mnSecPinNum;
									bool bExistFlag = false;
									bool bExist2Flag = false;
									for (int k = 0; k < this.oneToMultList.Count; k++)
									{
										if (this.oneToMultList[k] == (int)mnMainPinNum2)
										{
											bExistFlag = true;
										}
										if (this.oneToMultList[k] == (int)mnSecPinNum2)
										{
											bExist2Flag = true;
										}
										if (bExistFlag && bExist2Flag)
										{
											break;
										}
									}
									if (bExistFlag)
									{
										if (!bExist2Flag)
										{
											this.oneToMultList.Add((int)mnSecPinNum2);
											this.oneToMultIndex.Add(j);
										}
									}
									else if (bExist2Flag)
									{
										this.oneToMultList.Add((int)mnMainPinNum2);
										this.oneToMultIndex.Add(j);
									}
									j++;
								}
								break;
							}
							mnMainPinNum2 = pinConnectInfoArray[j].mnMainPinNum;
							mnSecPinNum2 = pinConnectInfoArray[j].mnSecPinNum;
							if (mnMainPinNum == mnMainPinNum2 || mnSecPinNum == mnMainPinNum2 || mnMainPinNum == mnSecPinNum2 || mnSecPinNum == mnSecPinNum2)
							{
								bFirstFlag = true;
								System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
								this.oneToMultIndex = list;
								list.Add(i);
								this.oneToMultIndex.Add(j);
								System.Collections.Generic.List<int> list2 = new System.Collections.Generic.List<int>();
								this.oneToMultList = list2;
								list2.Add((int)mnMainPinNum);
								this.oneToMultList.Add((int)mnSecPinNum);
								if (mnMainPinNum != mnMainPinNum2 && mnSecPinNum != mnMainPinNum2)
								{
									if (mnMainPinNum == mnSecPinNum2 || mnSecPinNum == mnSecPinNum2)
									{
										this.oneToMultList.Add((int)mnMainPinNum2);
									}
								}
								else
								{
									this.oneToMultList.Add((int)mnSecPinNum2);
								}
							}
						}
						if (bFirstFlag)
						{
							this.oneToMultListList.Add(this.oneToMultList);
							this.oneToMultIndexList.Add(this.oneToMultIndex);
							//goto IL_2D2;
						}
						//goto IL_2D2;
					}
				}
				catch (System.Exception arg_2DF_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2DF_0.StackTrace);
				}
				for (int jj2 = 0; jj2 < this.oneToMultListList.Count; jj2++)
				{
					for (int kk2 = 1; kk2 < this.oneToMultListList[jj2].Count; kk2++)
					{
						ushort mnMainPinNum3 = (ushort)this.oneToMultListList[jj2][0];
						int index = kk2 - 1;
						pinConnectInfoArray[this.oneToMultIndexList[jj2][index]].mnMainPinNum = mnMainPinNum3;
						ushort mnSecPinNum3 = (ushort)this.oneToMultListList[jj2][kk2];
						pinConnectInfoArray[this.oneToMultIndexList[jj2][index]].mnSecPinNum = mnSecPinNum3;
					}
				}
				this.JYNYSortOneToMultRelationFunc(iIndex, pinConnectInfoArray);
			}
			catch (System.Exception arg_3A6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A6_0.StackTrace);
			}
		}
		public void JYNYSortOneToMultRelationFunc(int iIndex, System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			try
			{
				System.Collections.Generic.List<ushort> iPinList = new System.Collections.Generic.List<ushort>();
				System.Collections.Generic.List<int> iListTemp = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<SDLPinConnectInfo> sdlpciList = new System.Collections.Generic.List<SDLPinConnectInfo>();
				System.Collections.Generic.List<int> iArray = new System.Collections.Generic.List<int>();
				if (iIndex == 0)
				{
					this.gPinConnInfoJYTempArray.Clear();
					this.gPinConnInfoJYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				}
				else if (iIndex == 1)
				{
					this.gPinConnInfoNYTempArray.Clear();
					this.gPinConnInfoNYTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				}
				try
				{
					int i = 0;
					IL_56:
					while (i < pinConnectInfoArray.Count)
					{
						bool bExistFlag = false;
						for (int ii = 0; ii < iListTemp.Count; ii++)
						{
							if (iListTemp[ii] == i)
							{
								IL_90:
								IL_117:
								i++;
								goto IL_56;
							}
						}
						if (bExistFlag)
						{
							//goto IL_90;
						}
						sdlpciList.Add(pinConnectInfoArray[i]);
						ushort mnMainPinNum = pinConnectInfoArray[i].mnMainPinNum;
						for (int j = i + 1; j < pinConnectInfoArray.Count; j++)
						{
							ushort mnMainPinNum2 = pinConnectInfoArray[j].mnMainPinNum;
							ushort mnMainPinNum3 = pinConnectInfoArray[j].mnSecPinNum;
							if (mnMainPinNum == mnMainPinNum2)
							{
								iListTemp.Add(j);
								sdlpciList.Add(pinConnectInfoArray[j]);
							}
							else if (mnMainPinNum == mnMainPinNum3)
							{
								iListTemp.Add(j);
								sdlpciList.Add(pinConnectInfoArray[j]);
							}
						}
						//goto IL_117;
					}
				}
				catch (System.Exception arg_122_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_122_0.StackTrace);
				}
				for (int nn = 0; nn < sdlpciList.Count; nn++)
				{
					iPinList.Add(sdlpciList[nn].mnMainPinNum);
				}
				iPinList.Sort();
				for (int kk = 0; kk < iPinList.Count; kk++)
				{
					int mm = 0;
					IL_171:
					while (mm < sdlpciList.Count)
					{
						bool bExistFlag = false;
						for (int nn2 = 0; nn2 < iArray.Count; nn2++)
						{
							if (iArray[nn2] == mm)
							{
								IL_1AB:
								IL_200:
								mm++;
								goto IL_171;
							}
						}
						if (bExistFlag)
						{
							//goto IL_1AB;
						}
						SDLPinConnectInfo var_13_1B9_cp_0 = sdlpciList[mm];
						if (iPinList[kk] != var_13_1B9_cp_0.mnMainPinNum)
						{
							//goto IL_200;
						}
						iArray.Add(mm);
						if (iIndex == 0)
						{
							this.gPinConnInfoJYTempArray.Add(sdlpciList[mm]);
							break;
						}
						if (iIndex == 1)
						{
							this.gPinConnInfoNYTempArray.Add(sdlpciList[mm]);
							break;
						}
						break;
					}
				}
				iPinList.Clear();
				iArray.Clear();
				sdlpciList.Clear();
				iListTemp.Clear();
			}
			catch (System.Exception arg_231_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_231_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartJYTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			if (this.iUIDisplayMode == 1)
			{
				return this.StartJYTestForData_OLD(pinConnectInfoArray);
			}
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(0, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoJYTempArray.Count; i++)
							{
								if (this.gPinConnInfoJYTempArray[i].iJYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestJYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
							{
								if (this.gPinConnInfoJYTempArray[j].iJYTestFlag == 1)
								{
									bool bIsExistFlag = false;
									string JYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[j].JYTestTime;
									string JYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[j].JYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestJYParaStructList.Count; k++)
									{
										string JYTestTime2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											goto IL_22B;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestJYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[j]);
									}
								}
								IL_22B:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestJYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string JYTestTime = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYTestTime;
								string JYVoltage = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYVoltage;
								for (int kk = 0; kk < this.groupTestParaInfo.GroupTestParaStructArray.Count; kk++)
								{
									if (this.gPinConnInfoJYTempArray[kk].iJYTestFlag == 1)
									{
										string JYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											gPCRIIndexList.Add(kk);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_324_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_324_0.StackTrace);
					}
					this.mbKeepRun = true;
					this.mhCurThreadFlagJY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJYMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_359_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_359_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartJYChoiceTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			if (this.iUIDisplayMode == 1)
			{
				return this.StartJYTestForData_OLD(pinConnectInfoArray);
			}
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(0, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoJYTempArray.Count; i++)
							{
								if (this.gPinConnInfoJYTempArray[i].iJYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestJYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							int iIndex = 0;
							for (int ij = 0; ij < this.gPinConnInfoJYTempArray.Count; ij++)
							{
								if (this.gPinConnInfoJYTempArray[ij].iJYTestFlag == 1)
								{
									for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
									{
										string PlugName = this.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1;
										string PinName = this.groupTestParaInfo.GroupTestParaStructArray[j].PinName1;
										string PlugName2 = this.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2;
										string PinName2 = this.groupTestParaInfo.GroupTestParaStructArray[j].PinName2;
										if (this.gPinConnInfoJYTempArray[ij].mALJQName == PlugName && this.gPinConnInfoJYTempArray[ij].mBLJQName == PlugName2 && this.gPinConnInfoJYTempArray[ij].mnALJQPinNum == PinName && this.gPinConnInfoJYTempArray[ij].mnBLJQPinNum == PinName2)
										{
											iIndex = j;
											break;
										}
									}
									bool bIsExistFlag = false;
									string JYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].JYTestTime;
									string JYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].JYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestJYParaStructList.Count; k++)
									{
										string JYTestTime2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											goto IL_334;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestJYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[iIndex]);
									}
								}
								IL_334:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestJYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string JYTestTime = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYTestTime;
								string JYVoltage = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYVoltage;
								for (int ij2 = 0; ij2 < this.gPinConnInfoJYTempArray.Count; ij2++)
								{
									if (this.gPinConnInfoJYTempArray[ij2].iJYTestFlag == 1)
									{
										for (int m = 0; m < this.groupTestParaInfo.GroupTestParaStructArray.Count; m++)
										{
											string PlugName = this.groupTestParaInfo.GroupTestParaStructArray[m].PlugName1;
											string PinName = this.groupTestParaInfo.GroupTestParaStructArray[m].PinName1;
											string PlugName2 = this.groupTestParaInfo.GroupTestParaStructArray[m].PlugName2;
											string PinName2 = this.groupTestParaInfo.GroupTestParaStructArray[m].PinName2;
											if (this.gPinConnInfoJYTempArray[ij2].mALJQName == PlugName && this.gPinConnInfoJYTempArray[ij2].mBLJQName == PlugName2 && this.gPinConnInfoJYTempArray[ij2].mnALJQPinNum == PinName && this.gPinConnInfoJYTempArray[ij2].mnBLJQPinNum == PinName2)
											{
												iIndex = m;
												break;
											}
										}
										string JYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											gPCRIIndexList.Add(ij2);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_527_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_527_0.StackTrace);
					}
					this.mbKeepRun = true;
					this.mhCurThreadFlagJY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJYCTMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_55C_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_55C_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartJYFastTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			if (this.iUIDisplayMode == 1)
			{
				return this.StartJYFastTestForData_OLD(pinConnectInfoArray);
			}
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(0, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoJYTempArray.Count; i++)
							{
								if (this.gPinConnInfoJYTempArray[i].iJYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoJYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoJYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestJYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
							{
								if (this.gPinConnInfoJYTempArray[j].iJYTestFlag == 1)
								{
									bool bIsExistFlag = false;
									string JYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[j].JYTestTime;
									string JYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[j].JYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestJYParaStructList.Count; k++)
									{
										string JYTestTime2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestJYParaStructList[k].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											goto IL_22B;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestJYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[j]);
									}
								}
								IL_22B:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestJYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string JYTestTime = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYTestTime;
								string JYVoltage = this.groupTestParaInfo.GroupTestJYParaStructList[l].JYVoltage;
								for (int kk = 0; kk < this.groupTestParaInfo.GroupTestParaStructArray.Count; kk++)
								{
									if (this.gPinConnInfoJYTempArray[kk].iJYTestFlag == 1)
									{
										string JYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].JYTestTime;
										string JYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].JYVoltage;
										if (JYTestTime == JYTestTime2 && JYVoltage == JYVoltage2)
										{
											gPCRIIndexList.Add(kk);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_324_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_324_0.StackTrace);
					}
					this.mbKeepRun = true;
					this.mhCurThreadFlagJY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJYKCMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_359_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_359_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(1, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoNYTempArray.Count; i++)
							{
								if (this.gPinConnInfoNYTempArray[i].iNYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestNYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
							{
								if (this.gPinConnInfoNYTempArray[j].iNYTestFlag == 1)
								{
									bool bIsExistFlag = false;
									string NYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[j].NYTestTime;
									string NYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[j].NYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestNYParaStructList.Count; k++)
									{
										string NYTestTime2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											goto IL_21A;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestNYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[j]);
									}
								}
								IL_21A:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestNYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string NYTestTime = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYTestTime;
								string NYVoltage = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYVoltage;
								for (int kk = 0; kk < this.groupTestParaInfo.GroupTestParaStructArray.Count; kk++)
								{
									if (this.gPinConnInfoNYTempArray[kk].iNYTestFlag == 1)
									{
										string NYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											gPCRIIndexList.Add(kk);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_313_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_313_0.StackTrace);
					}
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_34F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_34F_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYChoiceTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(1, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoNYTempArray.Count; i++)
							{
								if (this.gPinConnInfoNYTempArray[i].iNYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestNYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							int iIndex = 0;
							for (int ij = 0; ij < this.gPinConnInfoNYTempArray.Count; ij++)
							{
								if (this.gPinConnInfoNYTempArray[ij].iNYTestFlag == 1)
								{
									for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
									{
										string PlugName = this.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1;
										string PinName = this.groupTestParaInfo.GroupTestParaStructArray[j].PinName1;
										string PlugName2 = this.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2;
										string PinName2 = this.groupTestParaInfo.GroupTestParaStructArray[j].PinName2;
										if (this.gPinConnInfoNYTempArray[ij].mALJQName == PlugName && this.gPinConnInfoNYTempArray[ij].mBLJQName == PlugName2 && this.gPinConnInfoNYTempArray[ij].mnALJQPinNum == PinName && this.gPinConnInfoNYTempArray[ij].mnBLJQPinNum == PinName2)
										{
											iIndex = j;
											break;
										}
									}
									bool bIsExistFlag = false;
									string NYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].NYTestTime;
									string NYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].NYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestNYParaStructList.Count; k++)
									{
										string NYTestTime2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											goto IL_323;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestNYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[iIndex]);
									}
								}
								IL_323:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestNYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string NYTestTime = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYTestTime;
								string NYVoltage = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYVoltage;
								for (int ij2 = 0; ij2 < this.gPinConnInfoNYTempArray.Count; ij2++)
								{
									if (this.gPinConnInfoNYTempArray[ij2].iNYTestFlag == 1)
									{
										for (int m = 0; m < this.groupTestParaInfo.GroupTestParaStructArray.Count; m++)
										{
											string PlugName = this.groupTestParaInfo.GroupTestParaStructArray[m].PlugName1;
											string PinName = this.groupTestParaInfo.GroupTestParaStructArray[m].PinName1;
											string PlugName2 = this.groupTestParaInfo.GroupTestParaStructArray[m].PlugName2;
											string PinName2 = this.groupTestParaInfo.GroupTestParaStructArray[m].PinName2;
											if (this.gPinConnInfoNYTempArray[ij2].mALJQName == PlugName && this.gPinConnInfoNYTempArray[ij2].mBLJQName == PlugName2 && this.gPinConnInfoNYTempArray[ij2].mnALJQPinNum == PinName && this.gPinConnInfoNYTempArray[ij2].mnBLJQPinNum == PinName2)
											{
												iIndex = m;
												break;
											}
										}
										string NYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[iIndex].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											gPCRIIndexList.Add(ij2);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_516_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_516_0.StackTrace);
					}
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYCTMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_552_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_552_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYFastTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				this.JYNYFilterMultToMultRelationFunc(1, pinConnectInfoArray);
				try
				{
					try
					{
						if (!this.groupTestParaInfo.bGroupTestFlag)
						{
							for (int i = 0; i < this.gPinConnInfoNYTempArray.Count; i++)
							{
								if (this.gPinConnInfoNYTempArray[i].iNYTestFlag == 1)
								{
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									this.vecInt1 = new TestJNPinClass();
									this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[i].mnMainPinNum;
									this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[i].mnSecPinNum;
									this.vecInt2.Add(this.vecInt1);
									this.vecInt3.Add(this.vecInt2);
								}
							}
						}
						else
						{
							this.gPinConnRelaInfoIndexList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
							this.groupTestParaInfo.GroupTestNYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
							for (int j = 0; j < this.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
							{
								if (this.gPinConnInfoNYTempArray[j].iNYTestFlag == 1)
								{
									bool bIsExistFlag = false;
									string NYTestTime = this.groupTestParaInfo.GroupTestParaStructArray[j].NYTestTime;
									string NYVoltage = this.groupTestParaInfo.GroupTestParaStructArray[j].NYVoltage;
									for (int k = 0; k < this.groupTestParaInfo.GroupTestNYParaStructList.Count; k++)
									{
										string NYTestTime2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestNYParaStructList[k].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											goto IL_21A;
										}
									}
									if (!bIsExistFlag)
									{
										this.groupTestParaInfo.GroupTestNYParaStructList.Add(this.groupTestParaInfo.GroupTestParaStructArray[j]);
									}
								}
								IL_21A:;
							}
							for (int l = 0; l < this.groupTestParaInfo.GroupTestNYParaStructList.Count; l++)
							{
								System.Collections.Generic.List<int> gPCRIIndexList = new System.Collections.Generic.List<int>();
								string NYTestTime = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYTestTime;
								string NYVoltage = this.groupTestParaInfo.GroupTestNYParaStructList[l].NYVoltage;
								for (int kk = 0; kk < this.groupTestParaInfo.GroupTestParaStructArray.Count; kk++)
								{
									if (this.gPinConnInfoNYTempArray[kk].iNYTestFlag == 1)
									{
										string NYTestTime2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].NYTestTime;
										string NYVoltage2 = this.groupTestParaInfo.GroupTestParaStructArray[kk].NYVoltage;
										if (NYTestTime == NYTestTime2 && NYVoltage == NYVoltage2)
										{
											gPCRIIndexList.Add(kk);
										}
									}
								}
								if (gPCRIIndexList.Count > 0)
								{
									this.gPinConnRelaInfoIndexList.Add(gPCRIIndexList);
								}
							}
						}
					}
					catch (System.Exception arg_313_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_313_0.StackTrace);
					}
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYKCMonitor)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_34F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_34F_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartJYTestForData_OLD(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			bool bStartThreadOk = false;
			bool bOneToMultiFlag = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int ijk = 0;
				if (0 < pinConnectInfoArray.Count)
				{
					do
					{
						pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
						ijk++;
					}
					while (ijk < pinConnectInfoArray.Count);
				}
				try
				{
					try
					{
						for (int ia = 0; ia < pinConnInfoTempArray.Count; ia++)
						{
							for (int ib = pinConnInfoTempArray.Count - 1; ib > ia; ib--)
							{
								SDLPinConnectInfo var_23_97_cp_0 = pinConnInfoTempArray[ib];
								if (pinConnInfoTempArray[ia].mnMainPinNum == var_23_97_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_22_B8_cp_0 = pinConnInfoTempArray[ib];
									if (pinConnInfoTempArray[ia].mnSecPinNum == var_22_B8_cp_0.mnMainPinNum)
									{
										System.Collections.Generic.List<SDLPinConnectInfo> expr_CD = pinConnInfoTempArray;
										expr_CD.Remove(expr_CD[ib]);
										break;
									}
								}
							}
						}
						for (int i = 0; i < pinConnInfoTempArray.Count; i++)
						{
							if (pinConnInfoTempArray[i].iJYTestFlag == 1)
							{
								bool bIsExistFlag = false;
								for (int mk = 0; mk < this.vecInt3.Count; mk++)
								{
									if (this.vecInt3[mk][0].mMainDevPinNum1 == (int)pinConnInfoTempArray[i].mnMainPinNum)
									{
										goto IL_41B;
									}
								}
								if (!bIsExistFlag)
								{
									for (int j = 0; j < this.mJYTestValueArray.Count; j++)
									{
										if (this.mJYTestValueArray[j].mPinName == pinConnInfoTempArray[i].mALJQName && this.mJYTestValueArray[j].mPinNumber == pinConnInfoTempArray[i].mnALJQPinNum)
										{
											bOneToMultiFlag = this.mJYTestValueArray[j].bExistSameFlag;
											break;
										}
									}
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									for (int k = 0; k < pinConnInfoTempArray.Count; k++)
									{
										if (k != i)
										{
											if (pinConnInfoTempArray[k].iJYTestFlag == 1)
											{
												if (pinConnInfoTempArray[k].mnAPinIsGround != 1 && pinConnInfoTempArray[k].mnBPinIsGround != 1)
												{
													SDLPinConnectInfo var_21_247_cp_0 = pinConnInfoTempArray[k];
													if (pinConnInfoTempArray[i].mnMainPinNum != var_21_247_cp_0.mnMainPinNum)
													{
														bIsExistFlag = false;
														if (!bOneToMultiFlag)
														{
															goto IL_2AE;
														}
														for (int l = 0; l < this.vecInt2.Count; l++)
														{
															TestJNPinClass var_20_28A_cp_0 = this.vecInt2[l];
															if ((int)pinConnInfoTempArray[k].mnMainPinNum == var_20_28A_cp_0.mMainDevPinNum2)
															{
																goto IL_2F8;
															}
														}
														if (!bIsExistFlag)
														{
															goto IL_2AE;
														}
														IL_2F8:
														goto IL_2FA;
														IL_2AE:
														this.vecInt1 = new TestJNPinClass();
														this.vecInt1.mMainDevPinNum1 = (int)pinConnInfoTempArray[i].mnMainPinNum;
														this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[k].mnMainPinNum;
														this.vecInt2.Add(this.vecInt1);
													}
												}
											}
										}
										IL_2FA:;
									}
									for (int i2 = 0; i2 < this.vecInt2.Count; i2++)
									{
										int iMainPinNum = this.vecInt2[i2].mMainDevPinNum1;
										int iMainPinNum2 = this.vecInt2[i2].mMainDevPinNum2;
										int num = iMainPinNum % 2;
										if (1 == num && iMainPinNum2 == iMainPinNum + 1)
										{
											for (int j2 = 0; j2 < pinConnInfoTempArray.Count; j2++)
											{
												if ((int)pinConnInfoTempArray[j2].mnMainPinNum == iMainPinNum2)
												{
													int mnSecPinNum = (int)pinConnInfoTempArray[j2].mnSecPinNum;
													this.vecInt2[i2].mMainDevPinNum2 = mnSecPinNum;
													break;
												}
											}
										}
										else if (0 == num && iMainPinNum2 == iMainPinNum - 1)
										{
											for (int k2 = 0; k2 < pinConnInfoTempArray.Count; k2++)
											{
												if ((int)pinConnInfoTempArray[k2].mnMainPinNum == iMainPinNum2)
												{
													int mnSecPinNum2 = (int)pinConnInfoTempArray[k2].mnSecPinNum;
													this.vecInt2[i2].mMainDevPinNum2 = mnSecPinNum2;
													break;
												}
											}
										}
									}
									if (this.vecInt2.Count > 0)
									{
										this.vecInt3.Add(this.vecInt2);
									}
								}
							}
							IL_41B:;
						}
					}
					catch (System.Exception arg_426_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_426_0.StackTrace);
					}
					pinConnInfoTempArray.Clear();
					this.mbKeepRun = true;
					this.mhCurThreadFlagJY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJYMonitor_OLD)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_461_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_461_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartJYFastTestForData_OLD(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			bool bStartThreadOk = false;
			bool bOneToMultiFlag = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int ijk = 0;
				if (0 < pinConnectInfoArray.Count)
				{
					do
					{
						pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
						ijk++;
					}
					while (ijk < pinConnectInfoArray.Count);
				}
				try
				{
					try
					{
						for (int ia = 0; ia < pinConnInfoTempArray.Count; ia++)
						{
							for (int ib = pinConnInfoTempArray.Count - 1; ib > ia; ib--)
							{
								SDLPinConnectInfo var_23_A3_cp_0 = pinConnInfoTempArray[ib];
								if (pinConnInfoTempArray[ia].mnMainPinNum == var_23_A3_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_22_C4_cp_0 = pinConnInfoTempArray[ib];
									if (pinConnInfoTempArray[ia].mnSecPinNum == var_22_C4_cp_0.mnMainPinNum)
									{
										System.Collections.Generic.List<SDLPinConnectInfo> expr_D9 = pinConnInfoTempArray;
										expr_D9.Remove(expr_D9[ib]);
										break;
									}
								}
							}
						}
						for (int i = 0; i < pinConnInfoTempArray.Count; i++)
						{
							if (pinConnInfoTempArray[i].iJYTestFlag == 1)
							{
								bool bIsExistFlag = false;
								for (int mk = 0; mk < this.vecInt3.Count; mk++)
								{
									if (this.vecInt3[mk][0].mMainDevPinNum1 == (int)pinConnInfoTempArray[i].mnMainPinNum)
									{
										goto IL_427;
									}
								}
								if (!bIsExistFlag)
								{
									for (int j = 0; j < this.mJYTestValueArray.Count; j++)
									{
										if (this.mJYTestValueArray[j].mPinName == pinConnInfoTempArray[i].mALJQName && this.mJYTestValueArray[j].mPinNumber == pinConnInfoTempArray[i].mnALJQPinNum)
										{
											bOneToMultiFlag = this.mJYTestValueArray[j].bExistSameFlag;
											break;
										}
									}
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									for (int k = 0; k < pinConnInfoTempArray.Count; k++)
									{
										if (k != i)
										{
											if (pinConnInfoTempArray[k].iJYTestFlag == 1)
											{
												if (pinConnInfoTempArray[k].mnAPinIsGround != 1 && pinConnInfoTempArray[k].mnBPinIsGround != 1)
												{
													SDLPinConnectInfo var_21_253_cp_0 = pinConnInfoTempArray[k];
													if (pinConnInfoTempArray[i].mnMainPinNum != var_21_253_cp_0.mnMainPinNum)
													{
														bIsExistFlag = false;
														if (!bOneToMultiFlag)
														{
															goto IL_2BA;
														}
														for (int l = 0; l < this.vecInt2.Count; l++)
														{
															TestJNPinClass var_20_296_cp_0 = this.vecInt2[l];
															if ((int)pinConnInfoTempArray[k].mnMainPinNum == var_20_296_cp_0.mMainDevPinNum2)
															{
																goto IL_304;
															}
														}
														if (!bIsExistFlag)
														{
															goto IL_2BA;
														}
														IL_304:
														goto IL_306;
														IL_2BA:
														this.vecInt1 = new TestJNPinClass();
														this.vecInt1.mMainDevPinNum1 = (int)pinConnInfoTempArray[i].mnMainPinNum;
														this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[k].mnMainPinNum;
														this.vecInt2.Add(this.vecInt1);
													}
												}
											}
										}
										IL_306:;
									}
									for (int i2 = 0; i2 < this.vecInt2.Count; i2++)
									{
										int iMainPinNum = this.vecInt2[i2].mMainDevPinNum1;
										int iMainPinNum2 = this.vecInt2[i2].mMainDevPinNum2;
										int num = iMainPinNum % 2;
										if (1 == num && iMainPinNum2 == iMainPinNum + 1)
										{
											for (int j2 = 0; j2 < pinConnInfoTempArray.Count; j2++)
											{
												if ((int)pinConnInfoTempArray[j2].mnMainPinNum == iMainPinNum2)
												{
													int mnSecPinNum = (int)pinConnInfoTempArray[j2].mnSecPinNum;
													this.vecInt2[i2].mMainDevPinNum2 = mnSecPinNum;
													break;
												}
											}
										}
										else if (0 == num && iMainPinNum2 == iMainPinNum - 1)
										{
											for (int k2 = 0; k2 < pinConnInfoTempArray.Count; k2++)
											{
												if ((int)pinConnInfoTempArray[k2].mnMainPinNum == iMainPinNum2)
												{
													int mnSecPinNum2 = (int)pinConnInfoTempArray[k2].mnSecPinNum;
													this.vecInt2[i2].mMainDevPinNum2 = mnSecPinNum2;
													break;
												}
											}
										}
									}
									if (this.vecInt2.Count > 0)
									{
										this.vecInt3.Add(this.vecInt2);
									}
								}
							}
							IL_427:;
						}
					}
					catch (System.Exception arg_432_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_432_0.StackTrace);
					}
					pinConnInfoTempArray.Clear();
					this.mbKeepRun = true;
					this.mhCurThreadFlagJY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJYKCMonitor_OLD)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_46D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_46D_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYTestForData_OLD(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			bool bOneToMultiFlag = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int ijk = 0;
				if (0 < pinConnectInfoArray.Count)
				{
					do
					{
						pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
						ijk++;
					}
					while (ijk < pinConnectInfoArray.Count);
				}
				try
				{
					try
					{
						for (int ia = 0; ia < pinConnInfoTempArray.Count; ia++)
						{
							for (int ib = pinConnInfoTempArray.Count - 1; ib > ia; ib--)
							{
								SDLPinConnectInfo var_15_97_cp_0 = pinConnInfoTempArray[ib];
								if (pinConnInfoTempArray[ia].mnMainPinNum == var_15_97_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_14_B8_cp_0 = pinConnInfoTempArray[ib];
									if (pinConnInfoTempArray[ia].mnSecPinNum == var_14_B8_cp_0.mnMainPinNum)
									{
										System.Collections.Generic.List<SDLPinConnectInfo> expr_CD = pinConnInfoTempArray;
										expr_CD.Remove(expr_CD[ib]);
										break;
									}
								}
							}
						}
						for (int i = 0; i < pinConnInfoTempArray.Count; i++)
						{
							if (pinConnInfoTempArray[i].iNYTestFlag == 1)
							{
								bool bIsExistFlag = false;
								for (int mk = 0; mk < this.vecInt3.Count; mk++)
								{
									if (this.vecInt3[mk][0].mMainDevPinNum1 == (int)pinConnInfoTempArray[i].mnMainPinNum)
									{
										goto IL_339;
									}
								}
								if (!bIsExistFlag)
								{
									for (int j = 0; j < this.mNYTestValueArray.Count; j++)
									{
										if (this.mNYTestValueArray[j].mPinName == pinConnInfoTempArray[i].mALJQName && this.mNYTestValueArray[j].mPinNumber == pinConnInfoTempArray[i].mnALJQPinNum)
										{
											bOneToMultiFlag = this.mNYTestValueArray[j].bExistSameFlag;
											break;
										}
									}
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									for (int k = 0; k < pinConnInfoTempArray.Count; k++)
									{
										if (k != i)
										{
											if (pinConnInfoTempArray[k].iNYTestFlag == 1)
											{
												if (pinConnInfoTempArray[k].mnAPinIsGround != 1 && pinConnInfoTempArray[k].mnBPinIsGround != 1)
												{
													if (pinConnInfoTempArray[i].mnMainPinNum != 0 && pinConnInfoTempArray[k].mnMainPinNum != 0)
													{
														SDLPinConnectInfo var_13_25C_cp_0 = pinConnInfoTempArray[k];
														if (pinConnInfoTempArray[i].mnMainPinNum != var_13_25C_cp_0.mnMainPinNum)
														{
															bIsExistFlag = false;
															if (!bOneToMultiFlag)
															{
																goto IL_2C3;
															}
															for (int l = 0; l < this.vecInt2.Count; l++)
															{
																TestJNPinClass var_12_29F_cp_0 = this.vecInt2[l];
																if ((int)pinConnInfoTempArray[k].mnMainPinNum == var_12_29F_cp_0.mMainDevPinNum2)
																{
																	goto IL_30D;
																}
															}
															if (!bIsExistFlag)
															{
																goto IL_2C3;
															}
															IL_30D:
															goto IL_311;
															IL_2C3:
															this.vecInt1 = new TestJNPinClass();
															this.vecInt1.mMainDevPinNum1 = (int)pinConnInfoTempArray[i].mnMainPinNum;
															this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[k].mnMainPinNum;
															this.vecInt2.Add(this.vecInt1);
														}
													}
												}
											}
										}
										IL_311:;
									}
									if (this.vecInt2.Count > 0)
									{
										this.vecInt3.Add(this.vecInt2);
									}
								}
							}
							IL_339:;
						}
					}
					catch (System.Exception arg_344_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_344_0.StackTrace);
					}
					pinConnInfoTempArray.Clear();
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYMonitor_OLD)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_386_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_386_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYChoiceTestForData_OLD(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			bool bOneToMultiFlag = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int ijk = 0;
				if (0 < pinConnectInfoArray.Count)
				{
					do
					{
						pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
						ijk++;
					}
					while (ijk < pinConnectInfoArray.Count);
				}
				try
				{
					try
					{
						for (int ia = 0; ia < pinConnInfoTempArray.Count; ia++)
						{
							for (int ib = pinConnInfoTempArray.Count - 1; ib > ia; ib--)
							{
								SDLPinConnectInfo var_15_97_cp_0 = pinConnInfoTempArray[ib];
								if (pinConnInfoTempArray[ia].mnMainPinNum == var_15_97_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_14_B8_cp_0 = pinConnInfoTempArray[ib];
									if (pinConnInfoTempArray[ia].mnSecPinNum == var_14_B8_cp_0.mnMainPinNum)
									{
										System.Collections.Generic.List<SDLPinConnectInfo> expr_CD = pinConnInfoTempArray;
										expr_CD.Remove(expr_CD[ib]);
										break;
									}
								}
							}
						}
						for (int i = 0; i < pinConnInfoTempArray.Count; i++)
						{
							if (pinConnInfoTempArray[i].iNYTestFlag == 1)
							{
								bool bIsExistFlag = false;
								for (int mk = 0; mk < this.vecInt3.Count; mk++)
								{
									if (this.vecInt3[mk][0].mMainDevPinNum1 == (int)pinConnInfoTempArray[i].mnMainPinNum)
									{
										goto IL_339;
									}
								}
								if (!bIsExistFlag)
								{
									for (int j = 0; j < this.mNYTestValueArray.Count; j++)
									{
										if (this.mNYTestValueArray[j].mPinName == pinConnInfoTempArray[i].mALJQName && this.mNYTestValueArray[j].mPinNumber == pinConnInfoTempArray[i].mnALJQPinNum)
										{
											bOneToMultiFlag = this.mNYTestValueArray[j].bExistSameFlag;
											break;
										}
									}
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									for (int k = 0; k < pinConnInfoTempArray.Count; k++)
									{
										if (k != i)
										{
											if (pinConnInfoTempArray[k].iNYTestFlag == 1)
											{
												if (pinConnInfoTempArray[k].mnAPinIsGround != 1 && pinConnInfoTempArray[k].mnBPinIsGround != 1)
												{
													if (pinConnInfoTempArray[i].mnMainPinNum != 0 && pinConnInfoTempArray[k].mnMainPinNum != 0)
													{
														SDLPinConnectInfo var_13_25C_cp_0 = pinConnInfoTempArray[k];
														if (pinConnInfoTempArray[i].mnMainPinNum != var_13_25C_cp_0.mnMainPinNum)
														{
															bIsExistFlag = false;
															if (!bOneToMultiFlag)
															{
																goto IL_2C3;
															}
															for (int l = 0; l < this.vecInt2.Count; l++)
															{
																TestJNPinClass var_12_29F_cp_0 = this.vecInt2[l];
																if ((int)pinConnInfoTempArray[k].mnMainPinNum == var_12_29F_cp_0.mMainDevPinNum2)
																{
																	goto IL_30D;
																}
															}
															if (!bIsExistFlag)
															{
																goto IL_2C3;
															}
															IL_30D:
															goto IL_311;
															IL_2C3:
															this.vecInt1 = new TestJNPinClass();
															this.vecInt1.mMainDevPinNum1 = (int)pinConnInfoTempArray[i].mnMainPinNum;
															this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[k].mnMainPinNum;
															this.vecInt2.Add(this.vecInt1);
														}
													}
												}
											}
										}
										IL_311:;
									}
									if (this.vecInt2.Count > 0)
									{
										this.vecInt3.Add(this.vecInt2);
									}
								}
							}
							IL_339:;
						}
					}
					catch (System.Exception arg_344_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_344_0.StackTrace);
					}
					pinConnInfoTempArray.Clear();
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYMonitor_OLD)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_386_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_386_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartNYFastTestForData_OLD(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray, int mNYCmdID)
		{
			bool bStartThreadOk = false;
			bool bOneToMultiFlag = false;
			this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			if (!this.mhCurThreadFlag && this.mpDevComm != null)
			{
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int ijk = 0;
				if (0 < pinConnectInfoArray.Count)
				{
					do
					{
						pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
						ijk++;
					}
					while (ijk < pinConnectInfoArray.Count);
				}
				try
				{
					try
					{
						for (int ia = 0; ia < pinConnInfoTempArray.Count; ia++)
						{
							for (int ib = pinConnInfoTempArray.Count - 1; ib > ia; ib--)
							{
								SDLPinConnectInfo var_15_97_cp_0 = pinConnInfoTempArray[ib];
								if (pinConnInfoTempArray[ia].mnMainPinNum == var_15_97_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_14_B8_cp_0 = pinConnInfoTempArray[ib];
									if (pinConnInfoTempArray[ia].mnSecPinNum == var_14_B8_cp_0.mnMainPinNum)
									{
										System.Collections.Generic.List<SDLPinConnectInfo> expr_CD = pinConnInfoTempArray;
										expr_CD.Remove(expr_CD[ib]);
										break;
									}
								}
							}
						}
						for (int i = 0; i < pinConnInfoTempArray.Count; i++)
						{
							if (pinConnInfoTempArray[i].iNYTestFlag == 1)
							{
								bool bIsExistFlag = false;
								for (int mk = 0; mk < this.vecInt3.Count; mk++)
								{
									if (this.vecInt3[mk][0].mMainDevPinNum1 == (int)pinConnInfoTempArray[i].mnMainPinNum)
									{
										goto IL_339;
									}
								}
								if (!bIsExistFlag)
								{
									for (int j = 0; j < this.mNYTestValueArray.Count; j++)
									{
										if (this.mNYTestValueArray[j].mPinName == pinConnInfoTempArray[i].mALJQName && this.mNYTestValueArray[j].mPinNumber == pinConnInfoTempArray[i].mnALJQPinNum)
										{
											bOneToMultiFlag = this.mNYTestValueArray[j].bExistSameFlag;
											break;
										}
									}
									this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
									for (int k = 0; k < pinConnInfoTempArray.Count; k++)
									{
										if (k != i)
										{
											if (pinConnInfoTempArray[k].iNYTestFlag == 1)
											{
												if (pinConnInfoTempArray[k].mnAPinIsGround != 1 && pinConnInfoTempArray[k].mnBPinIsGround != 1)
												{
													if (pinConnInfoTempArray[i].mnMainPinNum != 0 && pinConnInfoTempArray[k].mnMainPinNum != 0)
													{
														SDLPinConnectInfo var_13_25C_cp_0 = pinConnInfoTempArray[k];
														if (pinConnInfoTempArray[i].mnMainPinNum != var_13_25C_cp_0.mnMainPinNum)
														{
															bIsExistFlag = false;
															if (!bOneToMultiFlag)
															{
																goto IL_2C3;
															}
															for (int l = 0; l < this.vecInt2.Count; l++)
															{
																TestJNPinClass var_12_29F_cp_0 = this.vecInt2[l];
																if ((int)pinConnInfoTempArray[k].mnMainPinNum == var_12_29F_cp_0.mMainDevPinNum2)
																{
																	goto IL_30D;
																}
															}
															if (!bIsExistFlag)
															{
																goto IL_2C3;
															}
															IL_30D:
															goto IL_311;
															IL_2C3:
															this.vecInt1 = new TestJNPinClass();
															this.vecInt1.mMainDevPinNum1 = (int)pinConnInfoTempArray[i].mnMainPinNum;
															this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[k].mnMainPinNum;
															this.vecInt2.Add(this.vecInt1);
														}
													}
												}
											}
										}
										IL_311:;
									}
									if (this.vecInt2.Count > 0)
									{
										this.vecInt3.Add(this.vecInt2);
									}
								}
							}
							IL_339:;
						}
					}
					catch (System.Exception arg_344_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_344_0.StackTrace);
					}
					pinConnInfoTempArray.Clear();
					this.nyCmdId = mNYCmdID;
					this.mbKeepRun = true;
					this.mhCurThreadFlagNY = true;
					new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadJLNYKCMonitor_OLD)).Start();
					bStartThreadOk = true;
				}
				catch (System.Exception arg_386_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_386_0.StackTrace);
				}
				return bStartThreadOk;
			}
			return false;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartDDJYTestForData(System.Collections.Generic.List<SDLPinConnectInfo> pinConnectInfoArray)
		{
			bool bStartThreadOk = false;
			this.mpDevComm.mParseCmd.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			try
			{
				if (this.mhCurThreadFlag || this.mpDevComm == null)
				{
					byte result = 0;
					return result != 0;
				}
				if (pinConnectInfoArray == null)
				{
					byte result = 0;
					return result != 0;
				}
				if (pinConnectInfoArray.Count <= 0)
				{
					byte result = 0;
					return result != 0;
				}
				System.Collections.Generic.List<SDLPinConnectInfo> pinConnInfoTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				for (int ijk = 0; ijk < pinConnectInfoArray.Count; ijk++)
				{
					pinConnInfoTempArray.Add(pinConnectInfoArray[ijk]);
				}
				this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
				this.ddjyTHeadNameList = new System.Collections.Generic.List<string>();
				for (int i = 0; i < pinConnInfoTempArray.Count; i++)
				{
					if (pinConnInfoTempArray[i].iDDJYTestFlag == 1)
					{
						string tempStr = pinConnInfoTempArray[i].mALJQName;
						string temp2Str = pinConnInfoTempArray[i].mBLJQName;
						bool bExistFlag = false;
						int j = 0;
						while (j < this.ddjyTHeadNameList.Count)
						{
							if (tempStr == this.ddjyTHeadNameList[j])
							{
								IL_121:
								bExistFlag = false;
								for (int k = 0; k < this.ddjyTHeadNameList.Count; k++)
								{
									if (temp2Str == this.ddjyTHeadNameList[k])
									{
										goto IL_167;
									}
								}
								if (!bExistFlag)
								{
									this.ddjyTHeadNameList.Add(temp2Str);
									goto IL_167;
								}
								goto IL_167;
							}
							else
							{
								j++;
							}
						}
						if (!bExistFlag)
						{
							this.ddjyTHeadNameList.Add(tempStr);
							//goto IL_121;
						}
						//goto IL_121;
					}
					IL_167:;
				}
				for (int l = 0; l < this.ddjyTHeadNameList.Count; l++)
				{
					this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
					for (int m = 0; m < pinConnInfoTempArray.Count; m++)
					{
						if (pinConnInfoTempArray[m].iDDJYTestFlag == 1)
						{
							string tempStr = pinConnInfoTempArray[m].mALJQName;
							string temp2Str = pinConnInfoTempArray[m].mBLJQName;
							if (tempStr == this.ddjyTHeadNameList[l])
							{
								TestJNPinClass testJNPinClass = new TestJNPinClass();
								this.vecInt1 = testJNPinClass;
								testJNPinClass.mMainDevPinNum1 = this.SELF_MAX_COUNT;
								this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[m].mnMainPinNum;
								this.vecInt2.Add(this.vecInt1);
							}
							if (temp2Str == this.ddjyTHeadNameList[l])
							{
								TestJNPinClass testJNPinClass2 = new TestJNPinClass();
								this.vecInt1 = testJNPinClass2;
								testJNPinClass2.mMainDevPinNum1 = this.SELF_MAX_COUNT;
								this.vecInt1.mMainDevPinNum2 = (int)pinConnInfoTempArray[m].mnSecPinNum;
								this.vecInt2.Add(this.vecInt1);
							}
						}
					}
					this.vecInt3.Add(this.vecInt2);
				}
				pinConnInfoTempArray.Clear();
				this.mbKeepRun = true;
				this.mhCurThreadFlagDDJY = true;
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadDDJYMonitor)).Start();
				bStartThreadOk = true;
			}
			catch (System.Exception arg_2DD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2DD_0.StackTrace);
			}
			return bStartThreadOk;
		}
		public void ThreadJLNYMonitor()
		{
			try
			{
				this.iNYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndACVlotCmd(this.Par.voltAC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(9);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagNY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmd();
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double NYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYTestTime);
								double NYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYVoltage);
								this.SendNYTimeCmd(NYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndACVlotCmd(NYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(9, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmd();
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagNY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_63F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_63F_0.StackTrace);
			}
		}
		public void ThreadJLNYCTMonitor()
		{
			try
			{
				this.iNYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndACVlotCmd(this.Par.voltAC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(9);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagNY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmd();
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double NYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYTestTime);
								double NYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYVoltage);
								this.SendNYTimeCmd(NYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndACVlotCmd(NYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(9, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmd();
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagNY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_63F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_63F_0.StackTrace);
			}
		}
		public void ThreadJLNYKCMonitor()
		{
			try
			{
				this.iNYKTFailNum = 0;
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int upcount = 0;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				if (!this.groupTestParaInfo.bGroupTestFlag)
				{
					int iTTestCount = this.vecInt3.Count;
					iTTestCount = this.vecInt3.Count;
					this.mpDevComm.mnDownCmdCount = this.vecInt3.Count;
					this.mpDevComm.mbUpLoadFinish = false;
					int iCurrTestCount = this.vecInt3.Count;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndACVlotCmd(this.Par.voltAC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd_FGT(9);
						if (!this.mbKeepRun)
						{
							this.iTestPreValue = 100;
							this.mhCurThreadFlagNY = false;
							this.mbKeepRun = false;
							return;
						}
						this.SendTestStartCmdNew(1);
						int nWaitTime = 0;
						int iTestedNum = this.mpDevComm.mUpdataCmdArray.Count;
						double dPreValue;
						int iPreValue;
						while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum < iCurrTestCount)
						{
							if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
							{
								upcount = this.mpDevComm.mUpdataCmdArray.Count;
								nWaitTime = 0;
							}
							this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							nWaitTime = WAIT_MAX_TIME + nWaitTime;
							if (300000 <= nWaitTime)
							{
								this.bIsTimeOut = true;
								break;
							}
							if (this.bIsTimeOut || !this.mbKeepRun)
							{
								break;
							}
							dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
							iPreValue = System.Convert.ToInt32(dPreValue);
							if (iPreValue >= 100)
							{
								iPreValue = 99;
							}
							this.iTestPreValue = iPreValue;
						}
						this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
						dPreValue = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount;
						iPreValue = System.Convert.ToInt32(dPreValue);
						if (iPreValue >= 100)
						{
							iPreValue = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount) ? 99 : 100);
						}
						this.iTestPreValue = iPreValue;
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					}
				}
				else
				{
					this.vecInt4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>>();
					for (int ii = 0; ii < this.gPinConnRelaInfoIndexList.Count; ii++)
					{
						this.vecInt3 = new System.Collections.Generic.List<System.Collections.Generic.List<TestJNPinClass>>();
						this.vecInt2 = new System.Collections.Generic.List<TestJNPinClass>();
						for (int jj = 0; jj < this.gPinConnRelaInfoIndexList[ii].Count; jj++)
						{
							int iCIndex = this.gPinConnRelaInfoIndexList[ii][jj];
							this.vecInt1 = new TestJNPinClass();
							this.vecInt1.mMainDevPinNum1 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnMainPinNum;
							this.vecInt1.mMainDevPinNum2 = (int)this.gPinConnInfoNYTempArray[iCIndex].mnSecPinNum;
							this.vecInt2.Add(this.vecInt1);
						}
						if (this.vecInt2.Count > 0)
						{
							this.vecInt3.Add(this.vecInt2);
							this.vecInt4.Add(this.vecInt3);
						}
					}
					int iTTestCount2 = 0;
					for (int itc = 0; itc < this.vecInt4.Count; itc++)
					{
						iTTestCount2 = this.vecInt4[itc][0].Count + iTTestCount2;
					}
					this.mpDevComm.mnDownCmdCount = iTTestCount2;
					this.mpDevComm.mbUpLoadFinish = false;
					if (this.bEmulationMode)
					{
						while (this.mbKeepRun && this.iTestPreValue != 100)
						{
							System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						}
					}
					else
					{
						for (int ivi4 = 0; ivi4 < this.vecInt4.Count; ivi4++)
						{
							if (this.vecInt4[ivi4][0].Count > 0)
							{
								int iCurrTestCount2 = this.vecInt4[ivi4][0].Count;
								double NYTestTime = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYTestTime);
								double NYVoltage = System.Convert.ToDouble(this.groupTestParaInfo.GroupTestNYParaStructList[ivi4].NYVoltage);
								this.SendNYTimeCmd(NYTestTime);
								System.Threading.Thread.Sleep(100);
								this.SendWithstAndACVlotCmd(NYVoltage);
								System.Threading.Thread.Sleep(100);
								this.SendTestCmd_GT(9, ivi4);
								if (!this.mbKeepRun)
								{
									break;
								}
								this.SendTestStartCmdNew(1);
								int nWaitTime = 0;
								int iTestedNum2 = this.mpDevComm.mUpdataCmdArray.Count;
								double dPreValue2;
								int iPreValue2;
								while (this.mpDevComm.mUpdataCmdArray.Count - iTestedNum2 < iCurrTestCount2)
								{
									if (upcount != this.mpDevComm.mUpdataCmdArray.Count)
									{
										upcount = this.mpDevComm.mUpdataCmdArray.Count;
										nWaitTime = 0;
									}
									this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
									System.Threading.Thread.Sleep(WAIT_MAX_TIME);
									nWaitTime = WAIT_MAX_TIME + nWaitTime;
									if (300000 <= nWaitTime)
									{
										this.bIsTimeOut = true;
										break;
									}
									if (this.bIsTimeOut || !this.mbKeepRun)
									{
										break;
									}
									dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
									iPreValue2 = System.Convert.ToInt32(dPreValue2);
									if (iPreValue2 >= 100)
									{
										iPreValue2 = 99;
									}
									this.iTestPreValue = iPreValue2;
								}
								this.iJNTestedCount = this.mpDevComm.mUpdataCmdArray.Count;
								dPreValue2 = (double)this.mpDevComm.mUpdataCmdArray.Count * 100.0 / (double)iTTestCount2;
								iPreValue2 = System.Convert.ToInt32(dPreValue2);
								if (iPreValue2 >= 100)
								{
									iPreValue2 = ((this.mpDevComm.mUpdataCmdArray.Count < iTTestCount2) ? 99 : 100);
								}
								this.iTestPreValue = iPreValue2;
								System.Threading.Thread.Sleep(WAIT_MAX_TIME);
							}
						}
					}
				}
				this.iTestPreValue = 100;
				this.mhCurThreadFlagNY = false;
				this.mbKeepRun = false;
			}
			catch (System.Exception arg_64E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64E_0.StackTrace);
			}
		}
		public void ThreadZLNYMonitor_OLD()
		{
			try
			{
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun)
				{
					int nytestcount = 0;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndDCVlotCmd(this.Par.voltDC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(8, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
					}
					this.iJNTestedCount++;
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 < nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					double nyvaluetest = this.mpDevComm.mUpdataCmdArray[0].mdTestResult;
					nytestcount++;
					int num = i + 1;
					double p = System.Convert.ToDouble(num) / System.Convert.ToDouble(this.vecInt3.Count) * 100.0;
					int pre = System.Convert.ToInt32(p);
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mbKeepRun = false;
				this.mhCurThreadFlagNY = false;
			}
			catch (System.Exception arg_18F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18F_0.StackTrace);
			}
		}
		public void ThreadJLNYMonitor_OLD()
		{
			try
			{
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun)
				{
					int nytestcount = 0;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndACVlotCmd(this.Par.voltAC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(9, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmd();
					}
					this.iJNTestedCount++;
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 < nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					if (this.mpDevComm.mUpdataCmdArray.Count > 0)
					{
						double nyvaluetest = this.mpDevComm.mUpdataCmdArray[0].mdTestResult;
					}
					nytestcount++;
					int num = i + 1;
					double p = System.Convert.ToDouble(num) / System.Convert.ToDouble(this.vecInt3.Count) * 100.0;
					int pre = System.Convert.ToInt32(p);
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mbKeepRun = false;
				this.mhCurThreadFlagNY = false;
			}
			catch (System.Exception arg_1B0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B0_0.StackTrace);
			}
		}
		public void ThreadJLNYKCMonitor_OLD()
		{
			try
			{
				this.iJNTestedCount = 0;
				this.iTestPreValue = 0;
				this.bIsTimeOut = false;
				int WAIT_MAX_TIME = 200;
				this.mpDevComm.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
				int i = 0;
				while (i < this.vecInt3.Count && !this.bIsTimeOut && this.mbKeepRun)
				{
					int nytestcount = 0;
					if (!this.bEmulationMode)
					{
						this.SendNYTimeCmd(this.Par.nyHoldTime);
						System.Threading.Thread.Sleep(100);
						this.SendWithstAndACVlotCmd(this.Par.voltAC);
						System.Threading.Thread.Sleep(100);
						this.SendTestCmd(9, i);
						if (!this.mbKeepRun)
						{
							break;
						}
						this.SendTestStartCmdNew(1);
					}
					this.iJNTestedCount++;
					int nWaitTime = 0;
					while (this.mpDevComm.mUpdataCmdArray.Count - 1 != i)
					{
						System.Threading.Thread.Sleep(WAIT_MAX_TIME);
						nWaitTime = WAIT_MAX_TIME + nWaitTime;
						if (300000 < nWaitTime)
						{
							this.bIsTimeOut = true;
							break;
						}
						if (this.bIsTimeOut || !this.mbKeepRun)
						{
							break;
						}
					}
					if (this.mpDevComm.mUpdataCmdArray.Count > 0)
					{
						double nyvaluetest = this.mpDevComm.mUpdataCmdArray[0].mdTestResult;
					}
					nytestcount++;
					int num = i + 1;
					double p = System.Convert.ToDouble(num) / System.Convert.ToDouble(this.vecInt3.Count) * 100.0;
					int pre = System.Convert.ToInt32(p);
					this.iTestPreValue = pre;
					System.Threading.Thread.Sleep(WAIT_MAX_TIME);
					i = num;
				}
				this.iTestPreValue = 100;
				this.mbKeepRun = false;
				this.mhCurThreadFlagNY = false;
			}
			catch (System.Exception arg_1B1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B1_0.StackTrace);
			}
		}
		public void SendTestFreeCmd(int nCmdType, int index, byte freeByte)
		{
			try
			{
				if (this.mbKeepRun)
				{
					this.mDownCmdCount = 0;
					this.mDownCmdBuf = new CanCmdEx[this.vecInt3[index].Count];
					for (int i = 0; i < this.mDownCmdBuf.Length; i++)
					{
						this.mDownCmdBuf[i] = new CanCmdEx();
					}
					for (int j = 0; j < this.vecInt3[index].Count; j++)
					{
						int pin = this.vecInt3[index][j].mMainDevPinNum1;
						int pin2 = this.vecInt3[index][j].mMainDevPinNum2;
						if (pin != pin2)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf = new byte[8];
							this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(nCmdType);
							ushort uint16Temp = System.Convert.ToUInt16(pin);
							byte[] byteTemp = System.BitConverter.GetBytes(uint16Temp);
							int iIndex = 0;
							for (int k = 0; k < byteTemp.Length; k++)
							{
								this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[k];
								iIndex++;
							}
							uint16Temp = System.Convert.ToUInt16(pin2);
							byteTemp = System.BitConverter.GetBytes(uint16Temp);
							for (int l = 0; l < byteTemp.Length; l++)
							{
								this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[l];
								iIndex++;
							}
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = freeByte;
							iIndex++;
							this.mDownCmdCount++;
						}
					}
					if (null != this.mpDevComm)
					{
						for (int m = 0; m < this.mDownCmdCount; m++)
						{
							CanCmdEx canCmdEx = this.mDownCmdBuf[m];
							this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
							System.Threading.Thread.Sleep(1);
						}
					}
					System.Threading.Thread.Sleep(100);
				}
			}
			catch (System.Exception arg_1F1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1F1_0.StackTrace);
			}
		}
		public void SendTestCmd_FGT(int nCmdType)
		{
			try
			{
				if (this.mbKeepRun)
				{
					this.mDownCmdCount = 0;
					this.mDownCmdBuf = new CanCmdEx[this.vecInt3.Count];
					for (int i = 0; i < this.mDownCmdBuf.Length; i++)
					{
						this.mDownCmdBuf[i] = new CanCmdEx();
					}
					for (int j = 0; j < this.vecInt3.Count; j++)
					{
						int pin = this.vecInt3[j][0].mMainDevPinNum1;
						int pin2 = this.vecInt3[j][0].mMainDevPinNum2;
						this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf = new byte[8];
						this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(nCmdType);
						ushort uint16Temp = System.Convert.ToUInt16(pin);
						byte[] byteTemp = System.BitConverter.GetBytes(uint16Temp);
						int iIndex = 0;
						for (int k = 0; k < byteTemp.Length; k++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[k];
							iIndex++;
						}
						uint16Temp = System.Convert.ToUInt16(pin2);
						byteTemp = System.BitConverter.GetBytes(uint16Temp);
						for (int l = 0; l < byteTemp.Length; l++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[l];
							iIndex++;
						}
						this.mDownCmdCount++;
					}
					if (null != this.mpDevComm)
					{
						for (int m = 0; m < this.mDownCmdCount; m++)
						{
							CanCmdEx canCmdEx = this.mDownCmdBuf[m];
							this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
							System.Threading.Thread.Sleep(1);
						}
					}
					System.Threading.Thread.Sleep(100);
				}
			}
			catch (System.Exception arg_1BC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1BC_0.StackTrace);
			}
		}
		public void SendTestCmd_GT(int nCmdType, int index)
		{
			try
			{
				if (this.mbKeepRun)
				{
					this.mDownCmdCount = 0;
					int ifsCount = this.vecInt4[index][0].Count;
					this.mDownCmdBuf = new CanCmdEx[ifsCount];
					for (int i = 0; i < this.mDownCmdBuf.Length; i++)
					{
						this.mDownCmdBuf[i] = new CanCmdEx();
					}
					for (int j = 0; j < this.vecInt4[index][0].Count; j++)
					{
						int pin = this.vecInt4[index][0][j].mMainDevPinNum1;
						int pin2 = this.vecInt4[index][0][j].mMainDevPinNum2;
						this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf = new byte[8];
						this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(nCmdType);
						ushort uint16Temp = System.Convert.ToUInt16(pin);
						byte[] byteTemp = System.BitConverter.GetBytes(uint16Temp);
						int iIndex = 0;
						for (int k = 0; k < byteTemp.Length; k++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[k];
							iIndex++;
						}
						uint16Temp = System.Convert.ToUInt16(pin2);
						byteTemp = System.BitConverter.GetBytes(uint16Temp);
						for (int l = 0; l < byteTemp.Length; l++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[l];
							iIndex++;
						}
						this.mDownCmdCount++;
					}
					if (null != this.mpDevComm)
					{
						for (int m = 0; m < this.mDownCmdCount; m++)
						{
							CanCmdEx canCmdEx = this.mDownCmdBuf[m];
							this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
							System.Threading.Thread.Sleep(1);
						}
					}
					System.Threading.Thread.Sleep(100);
				}
			}
			catch (System.Exception arg_1E4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E4_0.StackTrace);
			}
		}
		public void SendTestCmd_GT_DT(int nCmdType, int index)
		{
			try
			{
				if (this.mbKeepRun)
				{
					this.mDownCmdCount = 0;
					int ifsCount = this.vecInt3[index].Count;
					this.mDownCmdBuf = new CanCmdEx[ifsCount];
					for (int i = 0; i < this.mDownCmdBuf.Length; i++)
					{
						this.mDownCmdBuf[i] = new CanCmdEx();
					}
					for (int j = 0; j < this.vecInt3[index].Count; j++)
					{
						int pin = this.vecInt3[index][j].mMainDevPinNum1;
						int pin2 = this.vecInt3[index][j].mMainDevPinNum2;
						this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf = new byte[8];
						this.mDownCmdBuf[this.mDownCmdCount].mnFrmId = this.MakeFrmID(nCmdType);
						ushort uint16Temp = System.Convert.ToUInt16(pin);
						byte[] byteTemp = System.BitConverter.GetBytes(uint16Temp);
						int iIndex = 0;
						for (int k = 0; k < byteTemp.Length; k++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[k];
							iIndex++;
						}
						uint16Temp = System.Convert.ToUInt16(pin2);
						byteTemp = System.BitConverter.GetBytes(uint16Temp);
						for (int l = 0; l < byteTemp.Length; l++)
						{
							this.mDownCmdBuf[this.mDownCmdCount].mCmdBuf[iIndex] = byteTemp[l];
							iIndex++;
						}
						this.mDownCmdCount++;
					}
					if (null != this.mpDevComm)
					{
						for (int m = 0; m < this.mDownCmdCount; m++)
						{
							CanCmdEx canCmdEx = this.mDownCmdBuf[m];
							this.mpDevComm.OnSend(canCmdEx.mnFrmId, canCmdEx.mCmdBuf, 8);
							System.Threading.Thread.Sleep(1);
						}
					}
					System.Threading.Thread.Sleep(100);
				}
			}
			catch (System.Exception arg_1CC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1CC_0.StackTrace);
			}
		}
		public void SendOnlineTimeCmd(int time, int FZ)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(37);
				byte[] pCmdBuf = System.BitConverter.GetBytes(time);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				pCmdBuf = System.BitConverter.GetBytes(FZ);
				for (int j = 0; j < pCmdBuf.Length; j++)
				{
					canCmdBuf[j + 4] = pCmdBuf[j];
				}
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_59_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_59_0.StackTrace);
			}
		}
		public void SendLCRFreqSetCmd(int iIndex)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				short siTemp = System.Convert.ToInt16(iIndex);
				canCmdBuf[0] = (byte)siTemp;
				int framid = this.MakeFrmID(18);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_2C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2C_0.StackTrace);
			}
		}
		public void SendDTVlotAndCurrentCmd(double dtVolt, double dtCurr)
		{
			try
			{
				short iVolt = (short)System.Convert.ToUInt16(dtVolt);
				short iCurr = (short)System.Convert.ToUInt16(dtCurr);
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(iVolt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				pCmdBuf = System.BitConverter.GetBytes(iCurr);
				for (int j = 0; j < pCmdBuf.Length; j++)
				{
					canCmdBuf[j + 2] = pCmdBuf[j];
				}
				int framid = this.MakeFrmID(16);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_6D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6D_0.StackTrace);
			}
		}
		public void SendWithstAndDCVlotCmd(double volt)
		{
			try
			{
				if (this.Par.jyTestModel == 1)
				{
					int arg_1B_0 = (int)System.Convert.ToUInt32(volt);
					byte[] canCmdBuf = new byte[8];
					byte[] pCmdBuf = System.BitConverter.GetBytes(arg_1B_0);
					for (int i = 0; i < pCmdBuf.Length; i++)
					{
						canCmdBuf[i] = pCmdBuf[i];
					}
					int framid = this.MakeFrmID(12);
					this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				}
				else
				{
					this.SendDTVlotAndCurrentCmd(volt * 100.0, 2.0);
				}
			}
			catch (System.Exception arg_6A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6A_0.StackTrace);
			}
		}
		public void SendWithstAndACVlotCmd(double volt)
		{
			try
			{
				int arg_16_0 = (int)System.Convert.ToUInt32(volt);
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(13);
				byte[] pCmdBuf = System.BitConverter.GetBytes(arg_16_0);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void DYCL_HVDCFunc(double volt)
		{
			try
			{
				int arg_0D_0 = (int)System.Convert.ToUInt32(volt);
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(arg_0D_0);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(12);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void DYCL_HVDC_QUERYFunc()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(27);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public void DYCL_LVDCFunc(double volt, double curr)
		{
			try
			{
				short iVolt = (short)System.Convert.ToUInt16(volt);
				short iCurr = (short)System.Convert.ToUInt16(curr);
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(iVolt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				pCmdBuf = System.BitConverter.GetBytes(iCurr);
				for (int j = 0; j < pCmdBuf.Length; j++)
				{
					canCmdBuf[j + 2] = pCmdBuf[j];
				}
				int framid = this.MakeFrmID(16);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_6D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6D_0.StackTrace);
			}
		}
		public void DYCL_LVDC_QUERYFunc()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(28);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public void DYCL_HVACFunc(double volt)
		{
			try
			{
				int arg_16_0 = (int)System.Convert.ToUInt32(volt);
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(13);
				byte[] pCmdBuf = System.BitConverter.GetBytes(arg_16_0);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void DYCL_HVAC_QUERYFunc()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(29);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public void DTVoltCal(int volt, int pinA, int pinB)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(volt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int nFrmID = this.MakeFrmID(36);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_3B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3B_0.StackTrace);
			}
		}
		public void DCJZFunc(int volt)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(volt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(12);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				int nFrmID = this.MakeFrmID(32);
				canCmdBuf = new byte[8];
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		public void ACJZFunc(int volt)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(volt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(13);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				int nFrmID = this.MakeFrmID(33);
				canCmdBuf = new byte[8];
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		public void JYDZJZFunc(int ivdc)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(ivdc);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(12);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				int nFrmID = this.MakeFrmID(32);
				canCmdBuf = new byte[8];
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		public void NYDLJZFunc(int ivac)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(ivac);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int framid = this.MakeFrmID(13);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
				int nFrmID = this.MakeFrmID(33);
				canCmdBuf = new byte[8];
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		public void DCVoltCal(int volt, int pinA, int pinB)
		{
			byte[] canCmdBuf = new byte[8];
			byte[] pCmdBuf = System.BitConverter.GetBytes(pinB * 65536 + pinA);
			int i = 0;
			if (0 < pCmdBuf.Length)
			{
				do
				{
					canCmdBuf[i] = pCmdBuf[i];
					i++;
				}
				while (i < pCmdBuf.Length);
			}
			int nFrmID = this.MakeFrmID(5);
			this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			System.Threading.Thread.Sleep(10);
			byte[] array = new byte[8];
			byte[] pinA2 = System.BitConverter.GetBytes(volt);
			int j = 0;
			if (0 < pinA2.Length)
			{
				do
				{
					array[j] = pinA2[j];
					j++;
				}
				while (j < pinA2.Length);
			}
			int frmID = this.MakeFrmID(32);
			this.mpDevComm.OnSend(frmID, array, 8);
		}
		public void ACVoltCal(int volt, int pinA, int pinB)
		{
			byte[] canCmdBuf = new byte[8];
			byte[] pCmdBuf = System.BitConverter.GetBytes(pinB * 65536 + pinA);
			int i = 0;
			if (0 < pCmdBuf.Length)
			{
				do
				{
					canCmdBuf[i] = pCmdBuf[i];
					i++;
				}
				while (i < pCmdBuf.Length);
			}
			int nFrmID = this.MakeFrmID(5);
			this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			System.Threading.Thread.Sleep(10);
			byte[] array = new byte[8];
			byte[] pinA2 = System.BitConverter.GetBytes(volt);
			int j = 0;
			if (0 < pinA2.Length)
			{
				do
				{
					array[j] = pinA2[j];
					j++;
				}
				while (j < pinA2.Length);
			}
			int frmID = this.MakeFrmID(33);
			this.mpDevComm.OnSend(frmID, array, 8);
		}
		public void DownProbeAddrCmd(int pinA, int pinB, int FZ)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(41);
				canCmdBuf[0] = (byte)(pinA % 256);
				canCmdBuf[1] = (byte)(pinA / 256);
				canCmdBuf[2] = (byte)(pinB % 256);
				canCmdBuf[3] = (byte)(pinB / 256);
				byte[] tempBytesArray = System.BitConverter.GetBytes(FZ);
				canCmdBuf[4] = tempBytesArray[0];
				canCmdBuf[5] = tempBytesArray[1];
				canCmdBuf[6] = tempBytesArray[2];
				canCmdBuf[7] = tempBytesArray[3];
				if (!this.bEmulationMode)
				{
					this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
				}
			}
			catch (System.Exception arg_70_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
			}
		}
		public void SendSelfStudyCmd(int pinA, int pinB, int FZ)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID;
				if (this.iTwoFourWireChoice == 4)
				{
					nFrmID = this.MakeFrmID(44);
				}
				else
				{
					nFrmID = this.MakeFrmID(38);
				}
				canCmdBuf[0] = (byte)(pinA % 256);
				canCmdBuf[1] = (byte)(pinA / 256);
				canCmdBuf[2] = (byte)(pinB % 256);
				canCmdBuf[3] = (byte)(pinB / 256);
				byte[] tempBytesArray = System.BitConverter.GetBytes(FZ);
				canCmdBuf[4] = tempBytesArray[0];
				canCmdBuf[5] = tempBytesArray[1];
				canCmdBuf[6] = tempBytesArray[2];
				canCmdBuf[7] = tempBytesArray[3];
				if (!this.bEmulationMode)
				{
					this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
				}
			}
			catch (System.Exception arg_84_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_84_0.StackTrace);
			}
		}
		public void SendDTSelfStudyCmd(int pinA, int pinB, int FZ)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(60);
				canCmdBuf[0] = (byte)(pinA % 256);
				canCmdBuf[1] = (byte)(pinA / 256);
				canCmdBuf[2] = (byte)(pinB % 256);
				canCmdBuf[3] = (byte)(pinB / 256);
				byte[] tempBytesArray = System.BitConverter.GetBytes(FZ);
				canCmdBuf[4] = tempBytesArray[0];
				canCmdBuf[5] = tempBytesArray[1];
				canCmdBuf[6] = tempBytesArray[2];
				canCmdBuf[7] = tempBytesArray[3];
				if (!this.bEmulationMode)
				{
					this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
				}
			}
			catch (System.Exception arg_70_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool StartSelfStudyPlugModelTest()
		{
			bool bStartThreadOk = false;
			if (null != this.mpDevComm)
			{
				new System.Threading.Thread(new System.Threading.ThreadStart(this.SetSelfStudyPinCmd)).Start();
				bStartThreadOk = true;
			}
			return bStartThreadOk;
		}
		public void SetSelfStudyPinCmd()
		{
			try
			{
				this.iTestPreValue = 0;
				int[] array = this.iPlugPinStartArray;
				if (array != null)
				{
					int[] array2 = this.iPlugPinStopArray;
					if (array2 != null)
					{
						if (array.Length > 0 && array2.Length > 0)
						{
							int nFrmID = this.MakeFrmID(10);
							int iPerWaitTime = 100;
							bool bCSFlag = false;
							int i = 0;
							byte[] canCmdBuf;
							while (true)
							{
								array = this.iPlugPinStartArray;
								if (i >= array.Length)
								{
									break;
								}
								canCmdBuf = new byte[8];
								canCmdBuf[0] = (byte)(array[i] % 256);
								canCmdBuf[1] = (byte)(this.iPlugPinStartArray[i] / 256);
								canCmdBuf[2] = (byte)(this.iPlugPinStopArray[i] % 256);
								canCmdBuf[3] = (byte)(this.iPlugPinStopArray[i] / 256);
								if (!this.bEmulationMode)
								{
									this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
								}
								int iWaitTime = 0;
								do
								{
									System.Threading.Thread.Sleep(iPerWaitTime);
									iWaitTime = iPerWaitTime + iWaitTime;
									if (iWaitTime >= 2000)
									{
										goto Block_8;
									}
								}
								while (this.mpDevComm.mParseCmd.iSetSelfStudyDataRespCount <= i);
								if (bCSFlag)
								{
									break;
								}
								i++;
							}
							Block_8:
							System.Threading.Thread.Sleep(100);
							canCmdBuf = new byte[8];
							if (this.iTwoFourWireChoice == 4)
							{
								nFrmID = this.MakeFrmID(45);
							}
							else
							{
								nFrmID = this.MakeFrmID(43);
							}
							byte[] tempBytesArray = System.BitConverter.GetBytes(this.iSelfStudyThreshold);
							for (int j = 0; j < tempBytesArray.Length; j++)
							{
								canCmdBuf[j] = tempBytesArray[j];
							}
							if (!this.bEmulationMode)
							{
								this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
							}
							return;
						}
						this.iTestPreValue = 100;
						return;
					}
				}
				this.iTestPreValue = 100;
			}
			catch (System.Exception arg_175_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_175_0.StackTrace);
			}
		}
		public void SendSelfTestCmd(int pinA, int pinB)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int nFrmID = this.MakeFrmID(24);
				canCmdBuf[0] = (byte)(pinA % 256);
				canCmdBuf[1] = (byte)(pinA / 256);
				canCmdBuf[2] = (byte)(pinB % 256);
				canCmdBuf[3] = (byte)(pinB / 256);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_49_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
			}
		}
		public void ExportSELFTest()
		{
			try
			{
				this.gDLPinConnectInfoSelfArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int i = 0;
				while (true)
				{
					KParseRepCmd mParseCmd = this.mpDevComm.mParseCmd;
					if (i >= mParseCmd.selfStudyPinNum)
					{
						break;
					}
					if (mParseCmd.firstPinArray[i] != 0 && mParseCmd.secondPinArray[i] != 0)
					{
						SDLPinConnectInfo dlPintConnectInfo = new SDLPinConnectInfo();
						dlPintConnectInfo.mPIID = 0;
						dlPintConnectInfo.mTID = 0;
						dlPintConnectInfo.mACID = "0";
						dlPintConnectInfo.mBCID = "0";
						dlPintConnectInfo.mALJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnALJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mBLJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnBLJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnMainDevNum = 0;
						dlPintConnectInfo.mnSecDevNum = 0;
						dlPintConnectInfo.mnMainPinNum = (ushort)this.mpDevComm.mParseCmd.firstPinArray[i];
						dlPintConnectInfo.mnSecPinNum = (ushort)this.mpDevComm.mParseCmd.secondPinArray[i];
						dlPintConnectInfo.mnAPinIsGround = 0;
						dlPintConnectInfo.mnBPinIsGround = 0;
						dlPintConnectInfo.mnResistance = 0.0;
						dlPintConnectInfo.mnMainCompResistance = 0.0;
						dlPintConnectInfo.mnSecCompResistance = 0.0;
						this.gDLPinConnectInfoSelfArray.Add(dlPintConnectInfo);
					}
					i++;
				}
				this.LoadAPinBuChangDataSelfStudy();
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void ExportSELFTest2()
		{
			try
			{
				this.gDLPinConnectInfoSelf2Array = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int i = 0;
				while (true)
				{
					KParseRepCmd mParseCmd = this.mpDevComm.mParseCmd;
					if (i >= mParseCmd.selfStudyPinNum)
					{
						break;
					}
					if (mParseCmd.firstPinArray[i] != 0 && mParseCmd.secondPinArray[i] != 0)
					{
						SDLPinConnectInfo dlPintConnectInfo = new SDLPinConnectInfo();
						dlPintConnectInfo.mPIID = 0;
						dlPintConnectInfo.mTID = 0;
						dlPintConnectInfo.mACID = "0";
						dlPintConnectInfo.mBCID = "0";
						dlPintConnectInfo.mALJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnALJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mBLJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnBLJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnMainDevNum = 0;
						dlPintConnectInfo.mnSecDevNum = 0;
						dlPintConnectInfo.mnMainPinNum = (ushort)this.mpDevComm.mParseCmd.firstPinArray[i];
						dlPintConnectInfo.mnSecPinNum = (ushort)this.mpDevComm.mParseCmd.secondPinArray[i];
						dlPintConnectInfo.mnAPinIsGround = 0;
						dlPintConnectInfo.mnBPinIsGround = 0;
						dlPintConnectInfo.mnResistance = 0.0;
						dlPintConnectInfo.mnMainCompResistance = 0.0;
						dlPintConnectInfo.mnSecCompResistance = 0.0;
						this.gDLPinConnectInfoSelf2Array.Add(dlPintConnectInfo);
					}
					i++;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void ExportSELFTestDL()
		{
			try
			{
				this.gDLPinConnectInfoDLArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				int i = 0;
				while (true)
				{
					KParseRepCmd mParseCmd = this.mpDevComm.mParseCmd;
					if (i >= mParseCmd.selfStudyPinNum)
					{
						break;
					}
					if (mParseCmd.firstPinArray[i] != 0 && mParseCmd.secondPinArray[i] != 0)
					{
						SDLPinConnectInfo dlPintConnectInfo = new SDLPinConnectInfo();
						dlPintConnectInfo.mPIID = 0;
						dlPintConnectInfo.mTID = 0;
						dlPintConnectInfo.mACID = "0";
						dlPintConnectInfo.mBCID = "0";
						dlPintConnectInfo.mALJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnALJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mBLJQName = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnBLJQPinNum = KLineTestProcessor.PLUGPIN_UNDEFINED_STR;
						dlPintConnectInfo.mnMainDevNum = 0;
						dlPintConnectInfo.mnSecDevNum = 0;
						dlPintConnectInfo.mnMainPinNum = (ushort)this.mpDevComm.mParseCmd.firstPinArray[i];
						dlPintConnectInfo.mnSecPinNum = (ushort)this.mpDevComm.mParseCmd.secondPinArray[i];
						dlPintConnectInfo.mnAPinIsGround = 0;
						dlPintConnectInfo.mnBPinIsGround = 0;
						dlPintConnectInfo.mnResistance = 0.0;
						dlPintConnectInfo.mnMainCompResistance = 0.0;
						dlPintConnectInfo.mnSecCompResistance = 0.0;
						this.gDLPinConnectInfoDLArray.Add(dlPintConnectInfo);
					}
					i++;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void LoadAPinBuChangData()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.gDLPinConnectInfoArray != null)
				{
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.dbPathStr;
						connection.Open();
						for (int i = 0; i < this.gDLPinConnectInfoArray.Count; i++)
						{
							this.gDLPinConnectInfoArray[i].mnMainCompResistance = 0.0;
							this.gDLPinConnectInfoArray[i].mnSecCompResistance = 0.0;
							string sqlcommand = "select top 1 * from TResistanceCompensation where PinNum=" + this.gDLPinConnectInfoArray[i].mnMainPinNum;
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoArray[i].mnMainCompResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select top 1 * from TResistanceCompensation where PinNum=" + this.gDLPinConnectInfoArray[i].mnSecPinNum;
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoArray[i].mnSecCompResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
						}
						for (int j = 0; j < this.gDLPinConnectInfoArray.Count; j++)
						{
							this.gDLPinConnectInfoArray[j].mnMainInternalResistance = 0.0;
							this.gDLPinConnectInfoArray[j].mnSecInternalResistance = 0.0;
							string sqlcommand = "select top 1 * from TInternalResistanceTable where PinNum=" + this.gDLPinConnectInfoArray[j].mnMainPinNum;
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoArray[j].mnMainInternalResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select top 1 * from TInternalResistanceTable where PinNum=" + this.gDLPinConnectInfoArray[j].mnSecPinNum;
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoArray[j].mnSecInternalResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_27C_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_27C_0.StackTrace);
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
			}
			catch (System.Exception arg_2A0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2A0_0.StackTrace);
			}
		}
		public void LoadAPinBuChangDataSelfStudy()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.gDLPinConnectInfoSelfArray != null)
				{
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.dbPathStr;
						connection.Open();
						for (int i = 0; i < this.gDLPinConnectInfoSelfArray.Count; i++)
						{
							this.gDLPinConnectInfoSelfArray[i].mnMainCompResistance = 0.0;
							this.gDLPinConnectInfoSelfArray[i].mnSecCompResistance = 0.0;
							string sqlcommand = "select top 1 * from TResistanceCompensation where PinNum=" + this.gDLPinConnectInfoSelfArray[i].mnMainPinNum;
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoSelfArray[i].mnMainCompResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select top 1 * from TResistanceCompensation where PinNum=" + this.gDLPinConnectInfoSelfArray[i].mnSecPinNum;
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoSelfArray[i].mnSecCompResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
						}
						for (int j = 0; j < this.gDLPinConnectInfoSelfArray.Count; j++)
						{
							this.gDLPinConnectInfoSelfArray[j].mnMainInternalResistance = 0.0;
							this.gDLPinConnectInfoSelfArray[j].mnSecInternalResistance = 0.0;
							string sqlcommand = "select top 1 * from TInternalResistanceTable where PinNum=" + this.gDLPinConnectInfoSelfArray[j].mnMainPinNum;
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoSelfArray[j].mnMainInternalResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select top 1 * from TInternalResistanceTable where PinNum=" + this.gDLPinConnectInfoSelfArray[j].mnSecPinNum;
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gDLPinConnectInfoSelfArray[j].mnSecInternalResistance = System.Convert.ToDouble(dataReader["CompensationValue"].ToString());
							}
							dataReader.Close();
							dataReader = null;
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_27C_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_27C_0.StackTrace);
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
			}
			catch (System.Exception arg_2A0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2A0_0.StackTrace);
			}
		}
		public void SendNYTimeCmd(double time)
		{
			try
			{
				int nFrmID = this.MakeFrmID(39);
				byte[] canCmdBuf = new byte[8];
				if (time < 1.000001)
				{
					time = 1.0;
				}
				byte[] pCmdBuf = System.BitConverter.GetBytes(System.Convert.ToInt32(time));
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_57_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_57_0.StackTrace);
			}
		}
		public void SetAuxPowerSupply([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bOnOff)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				if (bOnOff)
				{
					canCmdBuf[0] = 1;
				}
				int nFrmID = this.MakeFrmID(48);
				this.mpDevComm.OnSend(nFrmID, canCmdBuf, 8);
			}
			catch (System.Exception arg_28_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_28_0.StackTrace);
			}
		}
		public void SendContinuityCorrectCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(40);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public void SendDeviceExistCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(31);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public void SendQueryDeviceErrorCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(35, 0, 0);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_23_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
			}
		}
		public void SendQueryDeviceIDCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(47, 0, 0);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_23_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
			}
		}
		public void SendDeviceWarningCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int framid = this.MakeFrmID(42);
				this.mpDevComm.OnSend(framid, canCmdBuf, 8);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		public int CalcFrmID(int id, int masterid, int slaveid)
		{
			int nFrmID = 0;
			try
			{
				nFrmID = 0;
				nFrmID = ((id + 256) * 1024 + masterid) * 64 + slaveid;
			}
			catch (System.Exception arg_28_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_28_0.StackTrace);
			}
			return nFrmID;
		}
		public unsafe void GetCmdID(int frmid, int* cmdid, int* masterid, int* slaveid, int* rsvd, int* prio)
		{
			try
			{
				*cmdid = (frmid >> 16 & 255);
				*masterid = (frmid >> 6 & 63);
				*slaveid = (frmid & 63);
				*rsvd = (frmid >> 24 & 7);
				*prio = (frmid >> 27 & 3);
			}
			catch (System.Exception arg_2F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2F_0.StackTrace);
			}
		}
		public void DownLoadTestShip(int type, int p1, int p2)
		{
			try
			{
				byte[] canCmdBuf = new byte[]
				{
					(byte)(p1 % 256),
					(byte)(p1 / 256),
					(byte)(p2 % 256),
					(byte)(p2 / 256),
					255,
					0,
					255,
					0
				};
				int frmid = this.CalcFrmID(type, 0, 0);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_62_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_62_0.StackTrace);
			}
		}
		public void DownLoadTestShip(int type, int d1, int d2, int p1, int p2)
		{
			try
			{
				byte[] canCmdBuf = new byte[]
				{
					(byte)(p1 % 256),
					(byte)(p1 / 256),
					(byte)(p2 % 256),
					(byte)(p2 / 256),
					255,
					0,
					255,
					0
				};
				int frmid = this.CalcFrmID(type, d1, d2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_66_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_66_0.StackTrace);
			}
		}
		public void DownStopCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				int frmid = this.CalcFrmID(34, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_2D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D_0.StackTrace);
			}
		}
		public void DownTestCmd(byte byteTemp)
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(System.Convert.ToInt32(50));
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				canCmdBuf[5] = byteTemp;
				int frmid = this.CalcFrmID(14, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_51_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_51_0.StackTrace);
			}
		}
		public void DownTestCmd()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(System.Convert.ToInt32(50));
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int frmid = this.CalcFrmID(14, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_4D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4D_0.StackTrace);
			}
		}
		public void DownTestCmdTZXZ()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(System.Convert.ToInt32(50));
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				canCmdBuf[6] = 1;
				int frmid = this.CalcFrmID(14, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_51_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_51_0.StackTrace);
			}
		}
		public void DownJYNYTime()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.testtime);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int frmid = this.CalcFrmID(39, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_4C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4C_0.StackTrace);
			}
		}
		public void DownJYNYVolt()
		{
			try
			{
				byte[] canCmdBuf = new byte[8];
				byte[] pCmdBuf = System.BitConverter.GetBytes(this.testvolt);
				for (int i = 0; i < pCmdBuf.Length; i++)
				{
					canCmdBuf[i] = pCmdBuf[i];
				}
				int id = (this.testtype == 7) ? 12 : 13;
				int frmid = this.CalcFrmID(id, this.dev1, this.dev2);
				this.mpDevComm.OnSend(frmid, canCmdBuf, 8);
			}
			catch (System.Exception arg_60_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_60_0.StackTrace);
			}
		}
	}
}
