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
	/// 表示 CoolQ 应用程序的 消息 的模型类
	/// </summary>
	public class Message : BasisStreamModel, IEquatable<Message>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的唯一标识 (消息ID)
		/// </summary>
		public int Id { get; private set; }
		/// <summary>
		/// 获取当前实例的文本形式
		/// </summary>
		public string Text { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定的消息内容和消息标识初始化 <see cref="Message"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="msgId">绑定于当前实例的消息标识</param>
		/// <param name="msg">绑定于当前实例的消息内容字符串</param>
		/// <exception cref="ArgumentNullException">api 或 msg 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">msgId 的值小于 0</exception>
		public Message (CQApi api, int msgId, string msg)
			: base (api)
		{
			if (msgId < 0)
			{
				throw new ArgumentOutOfRangeException (nameof (msgId), "消息标识不能小于 0");
			}

			if (msg is null)
			{
				throw new ArgumentNullException (nameof (msg));
			}

			this.Id = msgId;
			this.Text = msg;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (Message obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Id == obj.Id && string.Compare (this.Text, obj.Text) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as Message);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Id.GetHashCode () & this.Text.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{ID: {this.Id}, 消息内容: {this.Text}}}";
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public override string GetMessage ()
		{
			return this;
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{ }
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="Message"/> 实例</param>
		public static implicit operator string (Message value)
		{
			return value.Text;
		}
		/// <summary>
		/// 确定两个指定的 <see cref="Message"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Message a, Message b)
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
		/// 确定两个指定的 <see cref="Message"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Message a, Message b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="Message"/> 实例和 <see cref="string"/> 是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Message"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果是 a 的值与 b 相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Message a, string b)
		{
			if (a is null && b is null)
			{
				return true;
			}

			if (a is null)
			{
				return false;
			}

			return ((string)a).Equals (b);
		}
		/// <summary>
		/// 确定指定的 <see cref="Message"/> 实例和 <see cref="string"/> 是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Message"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果是 a 的值与 b 不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Message a, string b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="string"/> 和 <see cref="Message"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Message"/> 对象</param>
		/// <returns>如果是 a 与 b 的值相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (string a, Message b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="string"/> 和 <see cref="Message"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Message"/> 对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (string a, Message b)
		{
			return b != a;
		}
		#endregion
	}
}
