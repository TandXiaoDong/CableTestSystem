using System;
namespace CableTestManager
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
