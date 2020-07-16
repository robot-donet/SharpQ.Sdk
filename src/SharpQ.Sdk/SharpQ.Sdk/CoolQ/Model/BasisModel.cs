using SharpQ.Sdk.CoolQ.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 数据 模型基类, 该类是抽象的
	/// </summary>
	public abstract class BasisModel : IGetMessage
	{
		#region --属性--
		/// <summary>
		/// 获取当前用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		public CQApi Api { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="BasisModel"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <exception cref="ArgumentNullException">api 为 null</exception>
		protected BasisModel (CQApi api)
		{
			this.Api = api ?? throw new ArgumentNullException (nameof (api));
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 在派生类中重写时, 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public abstract string GetMessage ();
		#endregion
	}
}
