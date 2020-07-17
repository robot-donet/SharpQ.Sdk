using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "表情" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeFace : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的 Face 表情编号
		/// </summary>
		public CQFaces Face => (CQFaces)(int)this.Dictionary[CQCodeKeys.Id];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeFace"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		/// <exception cref="KeyNotFoundException">text 不包含指定的键</exception>
		public CQCodeFace (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Id);
		}
		/// <summary>
		/// 使用指定的表情枚举来初始化 <see cref="CQCodeFace"/> 类的新实例
		/// </summary>
		/// <param name="face">绑定于当前实例的 <see cref="CQFaces"/> 表情枚举</param>
		public CQCodeFace (CQFaces face)
			: base (CQCodeFunctions.Face, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Id, (int)face }
			})
		{ }
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeFace"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeFace (string value)
		{
			return new CQCodeFace (value);
		}
		#endregion
	}
}
