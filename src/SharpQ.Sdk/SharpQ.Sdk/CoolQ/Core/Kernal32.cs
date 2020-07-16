using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Core
{
	internal class Kernal32
	{
		#region --常量--
		private const string LibraryName = "Kernal32.dll";
		#endregion

		#region --外部函数--
#pragma warning disable IDE1006
		[DllImport (LibraryName, EntryPoint = nameof (lstrlenA), CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern Int32 lstrlenA (IntPtr ptr);
#pragma warning restore IDE1006
		#endregion
	}
}
