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
	/// 表示 CoolQ 应用程序的 群成员信息 的模型类, 该类不能被继承
	/// </summary>
	public sealed class GroupMemberInfo : QQ, IEquatable<GroupMemberInfo>
	{
		#region --属性--
		/// <summary>
		/// 获取一个与当前实例关联的 <see cref="Model.Group"/> 实例
		/// </summary>
		public Group Group { get; private set; }
		/// <summary>
		/// 获取当前实例成员的 QQ 昵称
		/// </summary>
		public string Nick { get; private set; }
		/// <summary>
		/// 获取当前实例成员的名片
		/// </summary>
		public string Card { get; private set; }
		/// <summary>
		/// 获取当前实例成员的性别
		/// </summary>
		public Gender Gender { get; private set; }
		/// <summary>
		/// 获取当前实例成员的年龄
		/// </summary>
		public int Age { get; private set; }
		/// <summary>
		/// 获取当前实例成员的归属地区
		/// </summary>
		public string Location { get; private set; }
		/// <summary>
		/// 获取当前实例成员的入群时间
		/// </summary>
		public DateTime JoinTime { get; private set; }
		/// <summary>
		/// 获取当前实例成员的最后发言时间
		/// </summary>
		public DateTime LastSpeakTime { get; private set; }
		/// <summary>
		/// 获取当前实例成员的等级名称
		/// </summary>
		public string Level { get; private set; }
		/// <summary>
		/// 获取当前实例成员的类型
		/// </summary>
		public GroupMemberType MemberType { get; private set; }
		/// <summary>
		/// 获取当前实例成员是否为不良记录成员
		/// </summary>
		public bool IsBanRecordMember { get; private set; }
		/// <summary>
		/// 获取当前实例成员的专属头衔
		/// </summary>
		public string SpecialTitle { get; private set; }
		/// <summary>
		/// 获取当前实例成员的专属头衔过期时间
		/// </summary>
		public DateTime? SpecialTitleExpirationTime { get; private set; }
		/// <summary>
		/// 获取当前实例成员是否允许修改名片
		/// </summary>
		public bool IsAllowEditorCard { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		///  使用指定的密文初始化 <see cref="GroupMemberInfo"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		public GroupMemberInfo (CQApi api, byte[] ciphertext)
			: base (api, ciphertext)
		{ }
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (GroupMemberInfo obj)
		{
			if (obj is null)
			{
				return false;
			}

			return base.Equals (obj)
				&& this.Group.Equals (obj.Group)
				&& string.Compare (this.Nick, obj.Nick) == 0
				&& string.Compare (this.Card, obj.Card) == 0
				&& this.Gender == obj.Gender
				&& this.Age == obj.Age
				&& string.Compare (this.Location, obj.Location) == 0
				&& this.JoinTime == obj.JoinTime
				&& this.LastSpeakTime == obj.LastSpeakTime
				&& string.Compare (this.Level, obj.Level) == 0
				&& this.MemberType == obj.MemberType
				&& string.Compare (this.SpecialTitle, obj.SpecialTitle) == 0
				&& this.SpecialTitleExpirationTime == obj.SpecialTitleExpirationTime
				&& this.IsBanRecordMember == obj.IsBanRecordMember
				&& this.IsAllowEditorCard == obj.IsAllowEditorCard;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as GroupMemberInfo);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return base.GetHashCode ()
				& this.Group.GetHashCode ()
				& this.Nick.GetHashCode ()
				& this.Card.GetHashCode ()
				& this.Gender.GetHashCode ()
				& this.Age.GetHashCode ()
				& this.Location.GetHashCode ()
				& this.JoinTime.GetHashCode ()
				& this.LastSpeakTime.GetHashCode ()
				& this.Level.GetHashCode ()
				& this.MemberType.GetHashCode ()
				& this.SpecialTitle.GetHashCode ()
				& this.SpecialTitleExpirationTime.GetHashCode ()
				& this.IsBanRecordMember.GetHashCode ()
				& this.IsAllowEditorCard.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{ID: {this.Id}, 群ID: {this.Group}, 昵称: {this.Nick ?? string.Empty}, 名片: {this.Card ?? string.Empty}, 性别: {this.Gender.GetDescription ()}, 地区: {this.Location}, 入群时间: {this.JoinTime}, 最后发言时间: {this.LastSpeakTime}, 等级: {this.Level}, 类型: {this.MemberType.GetDescription ()}, 专属头衔: {this.SpecialTitle}, 专属头衔过期时间: {(this.SpecialTitleExpirationTime != null ? this.SpecialTitleExpirationTime.Value.ToString () : "永久")}, 不良记录成员: {(this.IsBanRecordMember ? "是" : "否")}, 允许修改名片: {(this.IsAllowEditorCard ? "是" : "否")}}}";
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (reader.Length () < 40)
			{
				throw new InvalidDataException ("数据长度小于 40");
			}

			this.Group = new Group (this.Api, reader.ReadInt64_Ex ());
			this.Id = reader.ReadInt64_Ex ();
			this.Nick = reader.ReadString_Ex (Global.DefaultEncoding);
			this.Card = reader.ReadString_Ex (Global.DefaultEncoding);
			this.Gender = (Gender)reader.ReadInt32_Ex ();
			this.Age = reader.ReadInt32_Ex ();
			this.Location = reader.ReadString_Ex (Global.DefaultEncoding);
			this.JoinTime = reader.ReadInt32_Ex ().GetDateTime ();
			this.LastSpeakTime = reader.ReadInt32_Ex ().GetDateTime ();
			this.Level = reader.ReadString_Ex (Global.DefaultEncoding);
			this.MemberType = (GroupMemberType)reader.ReadInt32_Ex ();
			this.IsBanRecordMember = reader.ReadInt32_Ex () == 1;
			this.SpecialTitle = reader.ReadString_Ex (Global.DefaultEncoding);

			int temp = reader.ReadInt32_Ex ();
			if (temp == -1)
			{
				this.SpecialTitleExpirationTime = null;
			}
			else
			{
				this.SpecialTitleExpirationTime = new DateTime? (temp.GetDateTime ());
			}

			this.IsAllowEditorCard = reader.ReadInt32_Ex () == 1;
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="GroupMemberInfo"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (GroupMemberInfo a, GroupMemberInfo b)
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
		/// 确定两个指定的 <see cref="GroupMemberInfo"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (GroupMemberInfo a, GroupMemberInfo b)
		{
			return !(a == b);
		}
		#endregion
	}
}
