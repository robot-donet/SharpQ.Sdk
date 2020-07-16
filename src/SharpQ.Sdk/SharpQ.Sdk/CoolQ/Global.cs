using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ
{
	internal static class Global
	{
		/// <summary>
		/// 获取默认编码
		/// </summary>
		public static Encoding DefaultEncoding => Encoding.GetEncoding ("GB18030");
	}
}
