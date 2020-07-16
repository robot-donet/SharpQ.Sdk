using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "戳一戳" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeShake : CQCode
	{
		#region --字段--
		private int _id;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的戳一戳 "id"
		/// </summary>
		public int Id => this._id;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeFace"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">api 或 text 为 null</exception>
		public CQCodeShake (CQApi api, string text)
			: base (api, text)
		{ }
		/// <summary>
		/// 使用指定的 Face 表情编号来初始化 <see cref="CQCodeFace"/> 类的新势力, 并且持有用于扩展方法的 CQApi 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="id">绑定于当前实例的表情编号</param>
		public CQCodeShake (CQApi api)
			: base (api, CQCodeFunctions.Shake, null)
		{
		} 
		#endregion

		#region --私有方法--
		/// <summary>
		/// 设置必要的属性值
		/// </summary>
		/// <param name="content">要设置的 <see cref="CQCodeContent"/></param>
		protected override void SetProperty (CQCodeContent content)
		{
			if (content.ContainsKey(CQCodeKeys.Id))
			{
				this._id = content[CQCodeKeys.Id];
			}
		}
		#endregion
	}
}
