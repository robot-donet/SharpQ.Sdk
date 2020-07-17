using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "分享链接" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeShare : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的分享链接
		/// </summary>
		public string Url => this.Dictionary[CQCodeKeys.Url];
		/// <summary>
		/// 获取当前实例的分享标题
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
		/// 获取当前实例的详细内容
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
		/// 获取当前实例的图片链接
		/// </summary>
		public string Image
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Image))
				{
					return this.Dictionary[CQCodeKeys.Image];
				}

				return null;
			}
		}
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeShare"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		/// <exception cref="KeyNotFoundException">text 不包含指定的键</exception>
		public CQCodeShare (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Url);
		}
		/// <summary>
		/// 使用指定的链接来初始化 <see cref="CQCodeShare"/> 类的新实例
		/// </summary>
		/// <param name="url">绑定于当前实例的分享 URL 字符串</param>
		/// <param name="title">绑定于当前实例的标题字符串 或 null</param>
		/// <param name="content">绑定于当前实例的内容字符串 或 null</param>
		/// <param name="imageUrl">绑定于当前实例的图片 URL 或 null</param>
		public CQCodeShare (string url, string title = null, string content = null, string imageUrl = null)
			: base (CQCodeFunctions.Share, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Url, url }
			})
		{
			if (!string.IsNullOrEmpty (title))
			{
				this.Dictionary.Add (CQCodeKeys.Title, title);
			}

			if (!string.IsNullOrEmpty (content))
			{
				this.Dictionary.Add (CQCodeKeys.Content, content);
			}

			if (!string.IsNullOrEmpty (imageUrl))
			{
				this.Dictionary.Add (CQCodeKeys.Image, imageUrl);
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeShare"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeShare (string value)
		{
			return new CQCodeShare (value);
		}
		#endregion
	}
}
