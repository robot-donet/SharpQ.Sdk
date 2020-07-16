using SharpQ.Sdk.CoolQ.Interface;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 流式数据 模型基类, 该类是抽象的
	/// </summary>
	public abstract class BasisStreamModel : BasisModel
	{
		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="BasisStreamModel"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <exception cref="ArgumentNullException">api 为 null</exception>
		protected BasisStreamModel (CQApi api)
			: base (api)
		{ }
		/// <summary>
		///  使用指定的密文初始化 <see cref="BasisStreamModel"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		protected BasisStreamModel (CQApi api, byte[] ciphertext)
			: this (api)
		{
			if (ciphertext is null)
			{
				throw new ArgumentNullException (nameof (ciphertext));
			}

			if (ciphertext.Length >= 0)
			{
				using (BinaryReader reader = new BinaryReader (new MemoryStream (ciphertext)))
				{
					this.Initialize (reader);
				}
			}
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 当在派生类中重写时, 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected abstract void Initialize (BinaryReader reader);
		#endregion
	}
}
