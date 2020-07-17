using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "自定义音乐 " 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeCustomMusic : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例跳转详情链接的 URL 字符串
		/// </summary>
		public string Url => this.Dictionary[CQCodeKeys.Url];
		/// <summary>
		/// 获取当前实例的音乐直链 URL 字符串
		/// </summary>
		public string Audio => this.Dictionary[CQCodeKeys.Audio];
		/// <summary>
		/// 获取当前实例的音乐标题字符串
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
		/// 获取当前实例的音乐简介字符串
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
		/// 获取当前实例的图片字符串
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
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeCustomMusic"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeCustomMusic (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Type);
			base.ThrowKeyNotFound (CQCodeKeys.Url);
			base.ThrowKeyNotFound (CQCodeKeys.Audio);

			if (!(string.Compare (this.Dictionary[CQCodeKeys.Type], "custom") == 0))
			{
				throw new ArgumentException ("键: type 的值必须为 custom", nameof (text));
			}
		}
		/// <summary>
		/// 使用指定的分享链接和音乐外链来初始化 <see cref="CQCodeCustomMusic"/> 类的新实例
		/// </summary>
		/// <param name="url">点击跳转的详情页 URL</param>
		/// <param name="audio">播放的音乐直链 URL</param>
		/// <param name="title">音乐的标题, 建议12字内</param>
		/// <param name="content">音乐的简介, 建议30字内</param>
		/// <param name="image">音乐的封面图片 URL</param>
		public CQCodeCustomMusic (string url, string audio, string title = null, string content = null, string image = null)
			: base (CQCodeFunctions.Music, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Type, "custom" },
				{ CQCodeKeys.Url, url },
				{ CQCodeKeys.Audio, audio }
			})
		{
			if (title != null)
			{
				this.Dictionary.Add (CQCodeKeys.Title, title);
			}

			if (content != null)
			{
				this.Dictionary.Add (CQCodeKeys.Content, content);
			}

			if (image != null)
			{
				this.Dictionary.Add (CQCodeKeys.Image, image);
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeCustomMusic"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeCustomMusic (string value)
		{
			return new CQCodeCustomMusic (value);
		}
		#endregion
	}
}
