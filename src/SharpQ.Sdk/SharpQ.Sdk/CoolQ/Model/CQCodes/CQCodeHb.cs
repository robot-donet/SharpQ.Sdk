using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "红包" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeHb : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的红包标题
		/// </summary>
		public string Title => this.Dictionary[CQCodeKeys.Title];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeHb"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		/// <exception cref="KeyNotFoundException">text 不包含指定的键</exception>
		public CQCodeHb (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Title);
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeHb"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeHb (string value)
		{
			return new CQCodeHb (value);
		}
		#endregion
	}
}
