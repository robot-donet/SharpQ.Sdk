using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "名片分享" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeContact : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的分享名片类型
		/// </summary>
		public CQShareCardTypes Type
		{
			get
			{
				if (!Enum.TryParse (this.Dictionary[CQCodeKeys.Type], true, out CQShareCardTypes type))
				{
					return CQShareCardTypes.Unknown;
				}
				return type;
			}
		}
		/// <summary>
		/// 获取当前实例的好友Id (QQ号)
		/// </summary>
		public long Id => this.Dictionary[CQCodeKeys.Id];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeContact"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		/// <exception cref="KeyNotFoundException">text 不包含指定的键</exception>
		public CQCodeContact (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Type);
			base.ThrowKeyNotFound (CQCodeKeys.Id);
		}
		/// <summary>
		/// 使用群号或QQ号来初始化 <see cref="CQCodeContact"/> 类的新实例
		/// </summary>
		/// <param name="type">创建新实例指定的分享名片类型</param>
		/// <param name="id">绑定于当前实例的 Id</param>
		public CQCodeContact (CQShareCardTypes type, long id)
			: base (CQCodeFunctions.Share, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Type, type.GetDescription() },
				{ CQCodeKeys.Id, id }
			})
		{ }
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeContact"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeContact (string value)
		{
			return new CQCodeContact (value);
		}
		#endregion
	}
}
