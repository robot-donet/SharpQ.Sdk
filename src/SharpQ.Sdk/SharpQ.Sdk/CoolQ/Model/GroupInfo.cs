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
	/// 表示 CoolQ 应用程序的 群组信息 的模型类, 该类不能被继承
	/// </summary>
	public sealed class GroupInfo : Group, IEquatable<GroupInfo>
	{
		#region --字段--
		private readonly bool _isGroupList;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的名称
		/// </summary>
		public string Name { get; private set; }
		/// <summary>
		/// 获取当前实例的当前成员数量
		/// </summary>
		public int CurrentMemberCount { get; private set; }
		/// <summary>
		/// 获取当前实例的最大成员数量
		/// </summary>
		public int MaxMemberCount { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		///  使用指定的密文初始化 <see cref="QQ"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <param name="isGroupList">指示是否以解析的工作方式是否以 "群列表" 的方式进行</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		public GroupInfo (CQApi api, byte[] ciphertext, bool isGroupList)
			: base (api)
		{
			if (ciphertext is null)
			{
				throw new ArgumentNullException (nameof (ciphertext));
			}

			this._isGroupList = isGroupList;

			using (BinaryReader reader = new BinaryReader (new MemoryStream (ciphertext)))
			{
				this.Initialize (reader);
			}
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (GroupInfo obj)
		{
			if (obj is null)
			{
				return false;
			}

			return base.Equals (obj)
				&& string.Compare (this.Name, obj.Name) == 0
				&& this.CurrentMemberCount == obj.CurrentMemberCount
				&& this.MaxMemberCount == obj.CurrentMemberCount;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as GroupInfo);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return base.GetHashCode ()
				& this.Name.GetHashCode ()
				& this.CurrentMemberCount.GetHashCode ()
				& this.MaxMemberCount.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.Append ($"{{ID: {this.Id}, 群名: {this.Name ?? string.Empty}");
			if (!this._isGroupList)
			{
				builder.Append ($", 人数: {this.CurrentMemberCount}/{this.MaxMemberCount}");
			}
			builder.Append ("}");
			return builder.ToString ();
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (this._isGroupList)
			{
				if (reader.Length () < 10)
				{
					throw new InvalidDataException ("数据长度小于 10");
				}

				this.Id = reader.ReadInt64_Ex ();
				this.Name = reader.ReadString_Ex (Global.DefaultEncoding);
			}
			else
			{
				if (reader.Length () < 18)
				{
					throw new InvalidDataException ("数据长度小于 18");
				}

				this.Id = reader.ReadInt32_Ex ();
				this.Name = reader.ReadString_Ex (Global.DefaultEncoding);
				this.CurrentMemberCount = reader.ReadInt32_Ex ();
				this.MaxMemberCount = reader.ReadInt32_Ex ();
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="GroupInfo"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (GroupInfo a, GroupInfo b)
		{
			if (a is null && b is null)
			{
				return true;
			}

			if (a is null)
			{
				return false;
			}

			return a.Equals (b);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="GroupInfo"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (GroupInfo a, GroupInfo b)
		{
			return !(a == b);
		}
		#endregion
	}
}
