using System;
using System.Collections.Generic;

namespace CableTestManager.DeviceUtils
{
	public class KGroupTestParaInfo
	{
		public bool bGroupTestFlag;
		public string strPID;
		public string strLID;
		public string strProjectName;
		public string strCableName;
		public System.Collections.Generic.List<GroupTestParaStruct> GroupTestParaStructArray;
		public System.Collections.Generic.List<GroupTestParaStruct> GroupTestJYParaStructList;
		public System.Collections.Generic.List<GroupTestParaStruct> GroupTestNYParaStructList;
		public KGroupTestParaInfo()
		{
			this.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
			this.GroupTestJYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
			this.GroupTestNYParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
			this.bGroupTestFlag = false;
			string text = "0";
			this.strPID = text;
			this.strLID = text;
			string this2 = "";
			this.strProjectName = this2;
			this.strCableName = this2;
		}
		public void InitVariableInfoFunc()
		{
			this.GroupTestParaStructArray.Clear();
			this.GroupTestJYParaStructList.Clear();
			this.GroupTestNYParaStructList.Clear();
			this.bGroupTestFlag = false;
			this.strPID = "0";
			this.strLID = "0";
			this.strProjectName = "";
			this.strCableName = "";
		}
	}
}
