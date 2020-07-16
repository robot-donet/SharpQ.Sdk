using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 Emoji 的模型类
	/// </summary>
	public sealed class CQCodeEmoji : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的 Emoji 表情编号
		/// </summary>
		public int Id => this.Content[CQCodeKey.Id];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeEmoji"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">api 或 text 为 null</exception>
		public CQCodeEmoji (CQApi api, string text)
			: base (api, text)
		{ }
		/// <summary>
		/// 使用指定的 Emoji 表情编号来初始化 <see cref="CQCodeEmoji"/> 类的新势力, 并且持有用于扩展方法的 CQApi 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="id">绑定于当前实例的表情编号</param>
		public CQCodeEmoji (CQApi api, int id)
			: base (api, CQCodeFunctions.Emoji, null)
		{
			this.Content.Add (CQCodeKey.Id, id);
		}
		#endregion
	}
}
