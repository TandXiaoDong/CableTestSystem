using System;
namespace CableTestManager
{
	public class SDLPinConnectInfo
	{
		public int mPIID;
		public int mTID;
		public string mACID;
		public string mBCID;
		public int iAMeasMethod;
		public int iBMeasMethod;
		public string mALJQName;
		public string mBLJQName;
		public string mnALJQPinNum;
		public string mnBLJQPinNum;
		public int mnMainDevNum;
		public int mnSecDevNum;
		public ushort mnMainPinNum;
		public ushort mnSecPinNum;
		public ushort mnMainPinNum2;
		public ushort mnSecPinNum2;
		public double mdResultValue;
		public double mnResistance;
		public int mnAPinIsGround;
		public int mnBPinIsGround;
		public int iDTTestFlag;
		public int iDLTestFlag;
		public int iJYTestFlag;
		public int iDDJYTestFlag;
		public int iNYTestFlag;
		public string mnTestReusltState;
		public double mnMainCompResistance;
		public double mnSecCompResistance;
		public double mnMainInternalResistance;
		public double mnSecInternalResistance;
		public string strDTTestValue;
		public string strDTTestResult;
		public string strJYTestValue;
		public string strJYTestResult;
		public string strNYTestValue;
		public string strNYTestResult;
		public string strDDJYTestValue;
		public string strDDjyTestResult;
		public bool bMainPinTHFlag;
		public bool bSecPinTHFlag;
	}
}
