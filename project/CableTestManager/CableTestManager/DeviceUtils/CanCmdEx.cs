using System;

namespace CableTestManager.DeviceUtils
{
	public class CanCmdEx
	{
		public int mnFrmId;
		public byte[] mCmdBuf;
		public CanCmdEx()
		{
			this.mCmdBuf = new byte[8];
		}
	}
}
