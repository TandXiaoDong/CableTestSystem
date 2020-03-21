using System;
using System.Runtime.Serialization;
namespace CrtImplementationDetails
{
	[System.Serializable]
	internal class ModuleLoadException : System.Exception
	{
		public const string Nested = "A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n";
		protected ModuleLoadException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		public ModuleLoadException(string message, System.Exception innerException) : base(message, innerException)
		{
		}
		public ModuleLoadException(string message) : base(message)
		{
		}
	}
}
