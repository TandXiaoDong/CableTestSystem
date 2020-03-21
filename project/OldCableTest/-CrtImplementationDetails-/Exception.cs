using System;
using System.Runtime.Serialization;
namespace CrtImplementationDetails
{
	[System.Serializable]
	internal class Exception : System.Exception
	{
		protected Exception(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		public Exception(string message, System.Exception innerException) : base(message, innerException)
		{
		}
		public Exception(string message) : base(message)
		{
		}
	}
}
