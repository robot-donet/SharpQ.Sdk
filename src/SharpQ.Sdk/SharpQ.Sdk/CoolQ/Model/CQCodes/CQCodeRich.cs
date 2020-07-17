using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "卡片式富消息" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeRich : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的标题
		/// </summary>
		public string Title
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Title))
				{
					return this.Dictionary[CQCodeKeys.Title];
				}

				return null;
			}
		}
		/// <summary>
		/// 获取当前实例的内容
		/// </summary>
		public string Content
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Content))
				{
					return this.Dictionary[CQCodeKeys.Content];
				}

				return null;
			}
		}
		/// <summary>
		/// 获取当前实例的文本
		/// </summary>
		public string Text
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Text))
				{
					return this.Dictionary[CQCodeKeys.Text];
				}

				return null;
			}
		}
		/// <summary>
		/// 获取当前实例的链接
		/// </summary>
		public string Url
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Url))
				{
					return this.Dictionary[CQCodeKeys.Url];
				}

				return null;
			}
		}
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeRich"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeRich (string text)
			: base (text)
		{
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeRich"/> 实例</param>
		public static implicit operator string (CQCodeRich value)
		{
			return value.ToString ();
		}
		#endregion
	}
}
