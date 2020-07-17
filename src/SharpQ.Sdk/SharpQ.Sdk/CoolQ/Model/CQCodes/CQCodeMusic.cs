using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "音乐 " 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeMusic : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的歌曲ID
		/// </summary>
		public long Id => this.Dictionary[CQCodeKeys.Id];
		/// <summary>
		/// 获取当前实例的歌曲来源
		/// </summary>
		public CQMusicSources Source
		{
			get
			{
				string value = this.Dictionary[CQCodeKeys.Type];

				CQMusicSources[] array = (CQMusicSources[])Enum.GetValues (typeof (CQMusicSources));
				foreach (CQMusicSources item in array)
				{
					if (string.Compare (item.GetDescription (), value) == 0)
					{
						return item;
					}
				}

				return CQMusicSources.Unknown;
			}
		}
		/// <summary>
		/// 获取当前实例的歌曲样式
		/// </summary>
		public CQMusicStyles? Style
		{
			get
			{
				if (!this.Dictionary.ContainsKey (CQCodeKeys.Style))
				{
					return null;
				}

				return (CQMusicStyles)(int)this.Dictionary[CQCodeKeys.Style];
			}
		}
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeMusic"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeMusic (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Id);
			if (!this.Dictionary.ContainsKey (CQCodeKeys.Type))
			{
				this.Dictionary.Add (CQCodeKeys.Type, (int)CQMusicSources.Tencent);
			}
		}
		/// <summary>
		/// 使用指定的歌曲ID来初始化 <see cref="CQCodeMusic"/> 类的新实例
		/// </summary>
		/// <param name="id">绑定于当前实例的歌曲ID</param>
		/// <param name="source">指定检索歌曲ID的源</param>
		/// <param name="style">指定歌曲分享的样式</param>
		public CQCodeMusic (long id, CQMusicSources source = CQMusicSources.Tencent, CQMusicStyles? style = null)
			: base (CQCodeFunctions.Music, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Id, id },
				{ CQCodeKeys.Type, source.GetDescription () }
			})
		{
			if (style != null)
			{
				this.Dictionary.Add (CQCodeKeys.Style, (int)style);
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeMusic"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeMusic (string value)
		{
			return new CQCodeMusic (value);
		}
		#endregion
	}
}
