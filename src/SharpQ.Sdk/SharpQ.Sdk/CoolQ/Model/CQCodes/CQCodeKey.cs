using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码键 的枚举
	/// </summary>
	public enum CQCodeKey
	{
		/// <summary>
		/// 表示 "id" 键
		/// </summary>
		[Description ("id")]
		Id,
		/// <summary>
		/// 表示 "qq" 键
		/// </summary>
		[Description ("qq")]
		QQ,
		/// <summary>
		/// 表示 "file" 键
		/// </summary>
		[Description ("file")]
		File,
		/// <summary>
		/// 表示 "p" 键
		/// </summary>
		[Description ("p")]
		P,
		/// <summary>
		/// 表示 "ignore" 键
		/// </summary>
		[Description ("ignore")]
		Ignore,
		/// <summary>
		/// 表示 "title" 键
		/// </summary>
		[Description ("title")]
		Title,
		/// <summary>
		/// 表示 "content" 键
		/// </summary>
		[Description ("content")]
		Content,
		/// <summary>
		/// 表示 "text" 键
		/// </summary>
		[Description ("text")]
		Text,
		/// <summary>
		/// 表示 "url" 键
		/// </summary>
		[Description ("url")]
		Url,
		/// <summary>
		/// 表示 "type" 键
		/// </summary>
		[Description ("type")]
		Type,
		/// <summary>
		/// 表示 "Style" 键
		/// </summary>
		[Description ("style")]
		Style,
		/// <summary>
		/// 表示 "image" 键
		/// </summary>
		[Description ("image")]
		Image,
		/// <summary>
		/// 表示 "lat" 键
		/// </summary>
		[Description ("lat")]
		Lat,
		/// <summary>
		/// 表示 "lon" 键
		/// </summary>
		[Description ("lon")]
		Lon,
		/// <summary>
		/// 表示 "zoom" 键
		/// </summary>
		[Description ("zoom")]
		Zoom,
		/// <summary>
		/// 表示 "audio" 键
		/// </summary>
		[Description ("audio")]
		Audio
	}
}
