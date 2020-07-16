using SharpQ.Sdk.CoolQ.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ
{
	/// <summary>
	/// 表示 CoolQ 应用程序的接口封装类, 该类不允许继承
	/// </summary>
	public sealed class CQApi
	{
		#region --字段--
		private readonly int _authCode = 0;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQApi"/> 类的新实例, 该实例持有指定的唯一授权码
		/// </summary>
		/// <param name="authCode">授权码, 此码由 CoolQ 应用程序向应用的 Initialize 函数派发</param>
		public CQApi (int authCode)
		{
			this._authCode = authCode;
		}
		#endregion

		#region --公开方法--

		#endregion
	}
}
