using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "匿名" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeAnonymous : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取一个值, 指示当前实例描述匿名信息时是否在发送失败时转换为正常消息发送
		/// </summary>
		public bool Ignore
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Ignore))
				{
					return this.Dictionary[CQCodeKeys.Ignore];
				}

				return false;
			}
		}
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeAnonymous"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeAnonymous (string text)
			: base (text)
		{
			if (this.Dictionary.ContainsKey (CQCodeKeys.Ignore))
			{
				if (this.Dictionary[CQCodeKeys.Ignore] == false)
				{
					throw new ArgumentException ("键: ignore 的值不能为 false", nameof (text));
				}
			}
		}
		/// <summary>
		/// 初始化 <see cref="CQCodeAnonymous"/> 类的新实例, 并指定是否在发送失败时转换为正常消息
		/// </summary>
		/// <param name="ignore">指定是否在发送失败时转换为正常消息</param>
		public CQCodeAnonymous (bool ignore = false)
			: base (CQCodeFunctions.Anonymous, null)
		{
			if (ignore)
			{
				this.Dictionary.Add (CQCodeKeys.Ignore, ignore);
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeAnonymous"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeAnonymous (string value)
		{
			return new CQCodeAnonymous (value);
		}
		#endregion
	}
}
