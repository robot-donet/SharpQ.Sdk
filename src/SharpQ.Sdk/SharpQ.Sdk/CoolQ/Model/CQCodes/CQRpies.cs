using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 猜拳 的枚举
	/// </summary>
	public enum CQRpies
	{
		/// <summary>
		/// 表示猜拳结果是 "石头"
		/// </summary>
		Rock = 0,
		/// <summary>
		/// 表示猜拳结果是 "剪刀"
		/// </summary>
		Scissors = 1,
		/// <summary>
		/// 表示猜拳结果是 "布"
		/// </summary>
		Paper = 2
	}
}
