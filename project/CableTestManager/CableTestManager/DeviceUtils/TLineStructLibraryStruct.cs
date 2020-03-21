using System;

namespace CableTestManager.DeviceUtils
{
	public class TLineStructLibraryStruct
	{
		public string LID;
		public string LineStructName;
		public string PlugInfo;
		public int LinePinNum;
		public string Remark;
		public TLineStructLibraryStruct()
		{
			string this2 = "";
			this.LID = this2;
			this.LineStructName = this2;
			this.PlugInfo = this2;
			this.LinePinNum = 0;
			this.Remark = this2;
		}
	}
}
