using System;

namespace CableTestManager.DeviceUtils
{
	public class TProjectInfoStruct
	{
		public int iID;
		public string ProjectName;
		public int iCommonProject;
		public int iTestModel;
		public int iDTTestModel;
		public int iJYTestModel;
		public int iNYTestModel;
		public double dDT_Threshold;
		public double dDT_DTVoltage;
		public double dDT_DTCurrent;
		public double dJY_Threshold;
		public double dJY_JYHoldTime;
		public double dJY_DCHighVolt;
		public double dJY_DCRiseTime;
		public double dNY_Threshold;
		public double dNY_NYHoldTime;
		public double dNY_ACHighVolt;
		public double other1;
		public double other2;
		public int iGroupTestFlag;
		public string batchMumberStr;
		public string bcCableName;
		public string Creator;
		public string Remark;
		public TProjectInfoStruct()
		{
			this.iID = 0;
			string this2 = "";
			this.ProjectName = this2;
			this.iCommonProject = 0;
			this.iTestModel = 0;
			this.iDTTestModel = 0;
			this.iJYTestModel = 0;
			this.iNYTestModel = 0;
			this.dDT_Threshold = 5.0;
			this.dDT_DTVoltage = 2.0;
			this.dDT_DTCurrent = 2000.0;
			this.dJY_Threshold = 20.0;
			this.dJY_JYHoldTime = 1.0;
			this.dJY_DCHighVolt = 100.0;
			this.dJY_DCRiseTime = 1.0;
			this.dNY_Threshold = 2.0;
			this.dNY_NYHoldTime = 1.0;
			this.dNY_ACHighVolt = 100.0;
			this.other1 = 0.0;
			this.other2 = 0.0;
			this.iGroupTestFlag = 0;
			this.batchMumberStr = this2;
			this.bcCableName = this2;
			this.Creator = this2;
			this.Remark = this2;
		}
	}
}
