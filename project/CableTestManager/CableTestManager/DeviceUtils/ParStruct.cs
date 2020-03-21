using System;

namespace CableTestManager.DeviceUtils
{
	public class ParStruct
	{
		public string projectName;
		public string cableNameStr;
		public double onLineTime;
		public int testDelay;
		public int dtTestModel;
		public int jyTestModel;
		public int nyTestModel;
		public double dtValue;
		public double dtVolt;
		public double dtCurr;
		public double jyValue;
		public double voltDC;
		public double jyHoldTime;
		public double dcRiseTime;
		public double nyValue;
		public double voltAC;
		public double nyHoldTime;
		public ParStruct(string testProjectNameStr, string bcCableStr, double iOnLineTime, int iTestDelay, int iDTTestModel, int iJYTestModel, int iNYTestModel, double dDT_Threshold, double dDT_DTVoltage, double dDT_DTCurrent, double dJY_Threshold, double dJY_JYHoldTime, double dJY_DCHighVolt, double dJY_DCRiseTime, double dNY_Threshold, double dNY_nyHoldTime, double dNY_ACHighVolt)
		{
			this.projectName = testProjectNameStr;
			this.cableNameStr = bcCableStr;
			this.onLineTime = iOnLineTime;
			this.testDelay = iTestDelay;
			this.dtTestModel = iDTTestModel;
			this.jyTestModel = iJYTestModel;
			this.nyTestModel = iNYTestModel;
			this.dtValue = dDT_Threshold;
			this.dtVolt = dDT_DTVoltage;
			this.dtCurr = dDT_DTCurrent;
			this.jyValue = dJY_Threshold;
			this.jyHoldTime = dJY_JYHoldTime;
			this.voltDC = dJY_DCHighVolt;
			this.dcRiseTime = dJY_DCRiseTime;
			this.nyValue = dNY_Threshold;
			this.nyHoldTime = dNY_nyHoldTime;
			this.voltAC = dNY_ACHighVolt;
		}
		public ParStruct()
		{
			this.dtVolt = 2.5;
			this.dtCurr = 2000.0;
		}
	}
}
