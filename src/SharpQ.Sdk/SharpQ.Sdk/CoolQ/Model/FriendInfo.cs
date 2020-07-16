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
	/// 表示 CoolQ 应用程序的 好友信息 的模型类, 该类不能被继承
	/// </summary>
	public sealed class FriendInfo : QQ, IEquatable<FriendInfo>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的昵称
		/// </summary>
		public string Nick { get; private set; }
		/// <summary>
		/// 获取当前实例的备注
		/// </summary>
		public string Notes { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		///  使用指定的密文初始化 <see cref="FriendInfo"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		public FriendInfo (CQApi api, byte[] ciphertext)
			: base (api, ciphertext)
		{ }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (FriendInfo obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Id == obj.Id && string.Compare (this.Nick, obj.Nick) == 0 && string.Compare (this.Notes, obj.Notes) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as FriendInfo);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			int hashCode = base.GetHashCode ();

			if (!(this.Nick is null))
			{
				hashCode &= this.Nick.GetHashCode ();
			}

			if (!(this.Notes is null))
			{
				hashCode &= this.Notes.GetHashCode ();
			}

			return hashCode;
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{QQ: {this.Id}, 昵称: {this.Nick ?? string.Empty}, 备注: {this.Notes ?? string.Empty}}}";
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (reader.Length () < 12)
			{
				throw new InvalidDataException ("数据长度小于 12");
			}

			this.Id = reader.ReadInt64_Ex ();
			this.Nick = reader.ReadString_Ex (Global.DefaultEncoding);
			this.Notes = reader.ReadString_Ex (Global.DefaultEncoding);
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="FriendInfo"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (FriendInfo a, FriendInfo b)
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
		/// 确定两个指定的 <see cref="FriendInfo"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (FriendInfo a, FriendInfo b)
		{
			return !(a == b);
		}
		#endregion
	}
}
