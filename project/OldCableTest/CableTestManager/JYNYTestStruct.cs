using System;
namespace CableTestManager
{
	public class JYNYTestStruct
	{
		public string mPinName;
		public string mPinNumber;
		public string mSenPinName;
		public string mSenPinNumber;
		public double mdTestResult;
		public bool bExistSameFlag;
		public JYNYTestStruct()
		{
			string this2 = "";
			this.mPinName = this2;
			this.mPinNumber = this2;
			this.mSenPinName = this2;
			this.mSenPinNumber = this2;
			this.mdTestResult = 0.0;
			this.bExistSameFlag = false;
		}
	}
}
