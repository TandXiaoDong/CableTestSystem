using System;
namespace CableTestManager
{
	public class TLineStructLibraryDetailStruct
	{
		public string LID;
		public string PlugName1;
		public string PinName1;
		public string PlugName2;
		public string PinName2;
		public int IsGround;
		public int IsTestDT;
		public int IsTestDL;
		public int IsTestJY;
		public int IsTestDDJY;
		public int IsTestNY;
		public TLineStructLibraryDetailStruct()
		{
			this.LID = "0";
			string this2 = "";
			this.PlugName1 = this2;
			this.PinName1 = this2;
			this.PlugName2 = this2;
			this.PinName2 = this2;
			this.IsGround = 0;
			this.IsTestDT = 1;
			this.IsTestDL = 0;
			this.IsTestJY = 0;
			this.IsTestDDJY = 0;
			this.IsTestNY = 0;
		}
	}
}
