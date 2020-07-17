using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 分享名片类型 的枚举
	/// </summary>
	public enum CQShareCardTypes
	{
		/// <summary>
		/// 表示分享类型未知
		/// </summary>
		[Description ("unknown")]
		Unknown,
		/// <summary>
		/// 表示分享类型为 QQ
		/// </summary>
		[Description ("qq")]
		Qq,
		/// <summary>
		/// 表示分享类型为 Group
		/// </summary>
		[Description ("group")]
		Group
	}
}
