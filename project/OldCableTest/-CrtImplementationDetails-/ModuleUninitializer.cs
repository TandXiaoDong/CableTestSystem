using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;
namespace CrtImplementationDetails
{
	internal class ModuleUninitializer : System.Collections.Stack
	{
		private static object @lock = new object();
		internal static ModuleUninitializer _ModuleUninitializer = new ModuleUninitializer();
		[System.Security.SecuritySafeCritical]
		internal void AddHandler(System.EventHandler handler)
		{
			bool mustReleaseLock = false;
			System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
				System.Threading.Monitor.Enter(ModuleUninitializer.@lock, ref mustReleaseLock);
				System.Runtime.CompilerServices.RuntimeHelpers.PrepareDelegate(handler);
				this.Push(handler);
			}
			finally
			{
				if (mustReleaseLock)
				{
					System.Threading.Monitor.Exit(ModuleUninitializer.@lock);
				}
			}
		}
		[System.Security.SecuritySafeCritical]
		private ModuleUninitializer()
		{
			System.EventHandler singletonHandler = new System.EventHandler(this.SingletonDomainUnload);
			System.AppDomain.CurrentDomain.DomainUnload += singletonHandler;
			System.AppDomain.CurrentDomain.ProcessExit += singletonHandler;
		}
		[System.Runtime.ConstrainedExecution.PrePrepareMethod, System.Security.SecurityCritical]
		private void SingletonDomainUnload(object source, System.EventArgs arguments)
		{
			bool mustReleaseLock = false;
			System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
				System.Threading.Monitor.Enter(ModuleUninitializer.@lock, ref mustReleaseLock);
				System.Collections.IEnumerator enumerator = this.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						((System.EventHandler)enumerator.Current)(source, arguments);
					}
				}
				finally
				{
					System.IDisposable source2 = enumerator as System.IDisposable;
					if (source2 != null)
					{
						source2.Dispose();
					}
				}
			}
			finally
			{
				if (mustReleaseLock)
				{
					System.Threading.Monitor.Exit(ModuleUninitializer.@lock);
				}
			}
		}
	}
}
