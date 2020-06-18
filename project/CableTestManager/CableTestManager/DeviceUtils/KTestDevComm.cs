//using CppImplementationDetails;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CableTestManager.DeviceUtils
{
	public class KTestDevComm //: System.IDisposable
	{
		public static int CAN_COMM_READY = 1;
		public int iEMSetTestDataIndex;
		public int mnState;
		public int mnCommState;
		public int mFrmId;
		public byte[] mPostBuf;
		public byte[] mpRecvBuf;
		public int mnRecvBufSize;
		public int mnRecvDataLen;
		public bool mbKeepRun;
		public bool mhRecvThreadFlag;
		public int mnDownCmdCount;
		public int mnRepCmdCount;
		public int mnTotalRepCmdCount;
		public bool mbUpLoadFinish;
		public KParseRepCmd mParseCmd;
		public TestCmdMap[] mTestCmdMapBuf;
		public System.Collections.Generic.List<TestCmdMap> mUpdataCmdArray;
		public CanCmdEx[] mUpCmdBuf;
		public int mUpCmdCount;
		public uint mdwDeviceType;
		public uint mdwDeviceInd;
		public uint mdwCANInd;
		public uint mdwCanNum;
		public uint mdwSendType;
		public uint cannum;
		//public unsafe _VCI_INIT_CONFIG* init_config;
		public uint code;
		public uint mask;
		public byte timing0;
		public byte timing1;
		public byte filtertype;
		public byte mode;
		public uint callocNum;
		public uint callocSize;
		//		public unsafe KTestDevComm()
		//		{
		//			this.mParseCmd = new KParseRepCmd();
		//			this.mPostBuf = new byte[8];
		//			this.mTestCmdMapBuf = new TestCmdMap[65536];
		//			this.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>(65536);
		//			this.mUpCmdBuf = new CanCmdEx[65536];
		//			this.iEMSetTestDataIndex = 0;
		//			this.cannum = 1u;
		//			this.mnState = 0;
		//			this.mnCommState = 0;
		//			this.mnRecvBufSize = 1048576;
		//			this.mpRecvBuf = new byte[1048576];
		//			this.mnRecvDataLen = 0;
		//			this.mhRecvThreadFlag = false;
		//			this.mbKeepRun = false;
		//			this.mUpCmdCount = 0;
		//			this.mnDownCmdCount = 0;
		//			this.mnRepCmdCount = 0;
		//			this.mnTotalRepCmdCount = 0;
		//			this.mbUpLoadFinish = false;
		//			this.callocNum = 1u;
		//			this.callocSize = 16u;
		//			try
		//			{
		//				this.init_config = Module.calloc(1u, 16u);
		//			}
		//			catch (System.Exception ex_DB)
		//			{
		//				try
		//				{
		//					this.init_config = <Module>.malloc(16u);
		//				}
		//				catch (System.Exception ex2_ED)
		//				{
		//					try
		//					{
		//						_VCI_INIT_CONFIG* this2 = <Module>.@new(16u);
		//						_VCI_INIT_CONFIG* ptr;
		//						if (this2 != null)
		//						{
		//							initblk(this2, 0, 16);
		//							ptr = this2;
		//						}
		//						else
		//						{
		//							ptr = null;
		//						}
		//						this.init_config = ptr;
		//					}
		//					catch (System.Exception ex3_114)
		//					{
		//					}
		//				}
		//			}
		//		}
		//		private void ~KTestDevComm()
		//		{
		//			this.mbKeepRun = false;
		//			System.Threading.Thread.Sleep(100);
		//			if (null != this.mpRecvBuf)
		//			{
		//				this.mpRecvBuf = null;
		//			}
		//			this.CloseCAN();
		//		}
		//		public void ExceptionRecordFunc(string exStr)
		//		{
		//			System.IO.StreamWriter sw = null;
		//			System.ValueType dt = System.DateTime.Now;
		//			string exfn = Application.StartupPath + "\\ExceptionLog_" + System.Convert.ToString(((System.DateTime)dt).Year) + ".txt";
		//			try
		//			{
		//				sw = new System.IO.StreamWriter(exfn, true, System.Text.Encoding.Default);
		//				System.DateTime value = ((System.DateTime)dt).ToLocalTime();
		//				sw.WriteLine(System.Convert.ToString(value) + " : " + exStr);
		//				sw.Close();
		//				sw = null;
		//			}
		//			catch (System.Exception ex_7B)
		//			{
		//				if (sw != null)
		//				{
		//					sw.Close();
		//				}
		//			}
		//		}
		//		public void CanDebugRecordFunc(string exStr)
		//		{
		//			System.IO.StreamWriter sw = null;
		//			string exfn = Application.StartupPath + "\\canDebugRecord.txt";
		//			System.ValueType dt = System.DateTime.Now;
		//			try
		//			{
		//				sw = new System.IO.StreamWriter(exfn, true, System.Text.Encoding.Default);
		//				System.DateTime exStr2 = ((System.DateTime)dt).ToLocalTime();
		//				sw.WriteLine(System.Convert.ToString(exStr2) + " : " + exStr);
		//				sw.Close();
		//				sw = null;
		//			}
		//			catch (System.Exception ex_5C)
		//			{
		//				if (sw != null)
		//				{
		//					sw.Close();
		//				}
		//			}
		//		}

		public bool CloseCAN()
		{
			bool bCloseOk = false;
			try
			{
				//if (KTestDevComm.CAN_COMM_READY == this.mnCommState && 0 != < Module >.VCI_CloseDevice(this.mdwDeviceType, this.mdwDeviceInd))
				//{
				//	bCloseOk = true;
				//}
				this.mnCommState = 0;
				this.mbKeepRun = false;
			}
			catch (System.Exception ex)
			{
				//this.ExceptionRecordFunc(ex.StackTrace);
				bCloseOk = false;
			}
			return bCloseOk;
		}
		//		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		//		public bool StartRecvData()
		//		{
		//			bool result;
		//			try
		//			{
		//				byte this2;
		//				if (!this.mhRecvThreadFlag)
		//				{
		//					this.mbKeepRun = true;
		//					this.mhRecvThreadFlag = true;
		//					new System.Threading.Thread(new System.Threading.ThreadStart(this.RecvThreadCanFunc)).Start();
		//					this2 = 1;
		//					return this2 != 0;
		//				}
		//				this2 = 0;
		//				return this2 != 0;
		//			}
		//			catch (System.Exception ex)
		//			{
		//				this.ExceptionRecordFunc(ex.StackTrace);
		//				result = false;
		//			}
		//			return result;
		//		}
		//		public unsafe void RecvThreadCanFunc()
		//		{
		//			try
		//			{
		//				_VCI_ERR_INFO* ptr = <Module>.@new(8u);
		//				_VCI_ERR_INFO* arg_1B_0;
		//				if (ptr != null)
		//				{
		//					initblk(ptr, 0, 8);
		//					arg_1B_0 = ptr;
		//				}
		//				else
		//				{
		//					arg_1B_0 = null;
		//				}
		//				_VCI_ERR_INFO* errinfo = arg_1B_0;
		//				while (this.mbKeepRun)
		//				{
		//					if (KTestDevComm.CAN_COMM_READY == this.mnCommState)
		//					{
		//						$ArrayType$$$BY0GE@U_VCI_CAN_OBJ@@ canRecvData;
		//						int nRecvLen = <Module>.VCI_Receive(this.mdwDeviceType, this.mdwDeviceInd, this.mdwCanNum, (_VCI_CAN_OBJ*)(&canRecvData), 50, 50);
		//						if (nRecvLen <= 0)
		//						{
		//							<Module>.VCI_ReadErrInfo(this.mdwDeviceType, this.mdwDeviceInd, this.mdwCanNum, errinfo);
		//						}
		//						else
		//						{
		//							byte[] tempDataArray = new byte[8];
		//							for (int i = 0; i < nRecvLen; i++)
		//							{
		//								for (int kk = 0; kk < 8; kk++)
		//								{
		//									tempDataArray[kk] = *(i * 24 + kk + (ref canRecvData + 13));
		//								}
		//								int num = i * 24;
		//								this.mParseCmd.ParseRepCmd(*(num + ref canRecvData), tempDataArray, (int)(*(num + (ref canRecvData + 12))), this.mUpdataCmdArray);
		//								if (this.mUpdataCmdArray.Count == this.mnDownCmdCount)
		//								{
		//									this.mbUpLoadFinish = true;
		//								}
		//							}
		//						}
		//					}
		//				}
		//				this.mhRecvThreadFlag = false;
		//			}
		//			catch (System.Exception ex)
		//			{
		//				this.ExceptionRecordFunc(ex.StackTrace);
		//			}
		//		}
		//		public int SendCmd(byte[] pCtrlCmd, int nLen)
		//		{
		//			int pCtrlCmd2;
		//			try
		//			{
		//				if (KTestDevComm.CAN_COMM_READY == this.mnCommState && null != pCtrlCmd && 0 < nLen)
		//				{
		//					this.OnSend(0, pCtrlCmd, nLen);
		//					System.Threading.Thread.Sleep(10);
		//				}
		//				return 0;
		//			}
		//			catch (System.Exception ex)
		//			{
		//				this.ExceptionRecordFunc(ex.StackTrace);
		//				pCtrlCmd2 = 1;
		//			}
		//			return pCtrlCmd2;
		//		}

		//		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		//		public bool ParseRepCmd(int nFrmID, byte[] pCmdBuf, int nCmdLen)
		//		{
		//			bool result;
		//			try
		//			{
		//				byte nFrmID2;
		//				if (null != pCmdBuf)
		//				{
		//					int num = this.mUpCmdCount;
		//					if (num < 65536)
		//					{
		//						this.mUpCmdBuf[num].mnFrmId = nFrmID;
		//						for (int i = 0; i < pCmdBuf.Length; i++)
		//						{
		//							this.mUpCmdBuf[this.mUpCmdCount].mCmdBuf[i] = pCmdBuf[i];
		//						}
		//						this.mUpCmdCount++;
		//					}
		//					this.mFrmId = nFrmID;
		//					int num2 = nCmdLen + this.mnRecvDataLen;
		//					this.mnRecvDataLen = num2;
		//					if (this.mnRecvBufSize - 10 < num2)
		//					{
		//						this.mnRecvBufSize = 0;
		//					}
		//					if (0 < this.mnDownCmdCount)
		//					{
		//						int nCmdLen2 = this.mnRepCmdCount;
		//						if (nCmdLen2 < 65536)
		//						{
		//							double nRepValue = (double)((((int)pCmdBuf[0] * 256 + (int)pCmdBuf[1]) * 256 + (int)pCmdBuf[2]) * 256 + (int)pCmdBuf[3]);
		//							this.mTestCmdMapBuf[nCmdLen2].mdTestResult += nRepValue * 0.5;
		//							int pCmdBuf2 = this.mnTotalRepCmdCount;
		//							if (1 == pCmdBuf2 % 2)
		//							{
		//								this.mnRepCmdCount++;
		//							}
		//							this.mnTotalRepCmdCount = pCmdBuf2 + 1;
		//							if (this.mnRepCmdCount == this.mnDownCmdCount)
		//							{
		//								this.mbUpLoadFinish = true;
		//								this.mnTotalRepCmdCount = 0;
		//							}
		//						}
		//					}
		//					nFrmID2 = 1;
		//					return nFrmID2 != 0;
		//				}
		//				nFrmID2 = 0;
		//				return nFrmID2 != 0;
		//			}
		//			catch (System.Exception ex)
		//			{
		//				this.ExceptionRecordFunc(ex.StackTrace);
		//				result = false;
		//			}
		//			return result;
		//		}
		public void ClearTestCmdBuf()
		{
			try
			{
				this.iEMSetTestDataIndex = 0;
				this.mnDownCmdCount = 0;
				this.mnRepCmdCount = 0;
				this.mnTotalRepCmdCount = 0;
				this.mbUpLoadFinish = false;
				this.mTestCmdMapBuf = new TestCmdMap[65536];
				System.Collections.Generic.List<TestCmdMap> this2 = this.mUpdataCmdArray;
				if (this2 != null)
				{
					this2.Clear();
				}
				this.mUpdataCmdArray = new System.Collections.Generic.List<TestCmdMap>();
			}
			catch (System.Exception ex)
			{
				//this.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		//		public void ShowTestCmdDebugInfo()
		//		{
		//			string strMsgText = null;
		//			try
		//			{
		//				if (this.mbUpLoadFinish)
		//				{
		//					for (int i = 0; i < this.mnDownCmdCount; i++)
		//					{
		//						string.Format("主机：%d,  针号：%d , 从机:%d , 针号:%d , 阻值： %.1f \r\n", new object[]
		//						{
		//							this.mTestCmdMapBuf[i].mMainDevID,
		//							this.mTestCmdMapBuf[i].mMainDevPinNum,
		//							this.mTestCmdMapBuf[i].mSecDevID,
		//							this.mTestCmdMapBuf[i].mSecDevPinNum,
		//							this.mTestCmdMapBuf[i].mdTestResult
		//						});
		//						this.CanDebugRecordFunc(strMsgText);
		//					}
		//				}
		//			}
		//			catch (System.Exception ex)
		//			{
		//				this.ExceptionRecordFunc(ex.StackTrace);
		//			}
		//		}
		//		protected virtual void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		//		{
		//			if (flag)
		//			{
		//				this.mbKeepRun = false;
		//				System.Threading.Thread.Sleep(100);
		//				if (null != this.mpRecvBuf)
		//				{
		//					this.mpRecvBuf = null;
		//				}
		//				this.CloseCAN();
		//			}
		//			else
		//			{
		//				base.Finalize();
		//			}
		//		}
		//		public sealed override void Dispose()
		//		{
		//			this.Dispose(true);
		//			System.GC.SuppressFinalize(this);
		//		}
	}
}
