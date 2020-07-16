using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 性别 的枚举
	/// </summary>
	public enum Gender
	{
		/// <summary>
		/// 男性
		/// </summary>
		[Description ("男")]
		Male = 0,
		/// <summary>
		/// 女性
		/// </summary>
		[Description ("女")]
		Female = 1,
		/// <summary>
		/// 未知性别
		/// </summary>
		[Description ("未知")]
		Unknown = 255,
	}
}
