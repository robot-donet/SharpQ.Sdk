using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 群成员信息列表 模型类, 该类不能被继承
	/// </summary>
	public sealed class GroupMemberInfoCollection : BasisCollectionModel<GroupMemberInfo>
	{
		#region --构造函数--
		/// <summary>
		///  使用指定的密文初始化 <see cref="GroupInfoCollection"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		public GroupMemberInfoCollection (CQApi api, byte[] ciphertext)
			: base (api, ciphertext)
		{
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine ("[");
			foreach (GroupMemberInfo info in this)
			{
				builder.AppendLine ($"\t{info}");
			}
			builder.Append ("]");
			return builder.ToString ();
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public override string GetMessage ()
		{
			return this.ToString ();
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (reader.Length () < 4)
			{
				throw new InvalidDataException ("数据长度小于 4");
			}

			int count = reader.ReadInt32_Ex ();
			for (int i = 0; i < count; i++)
			{
				if (reader.Length () <= 0)
				{
					throw new EndOfStreamException ("无法读取数据, 因为已经到达末尾");
				}

				this._list.Add (new GroupMemberInfo (this.Api, reader.ReadToken_Ex ()));
			}
		}
		#endregion
	}
}
