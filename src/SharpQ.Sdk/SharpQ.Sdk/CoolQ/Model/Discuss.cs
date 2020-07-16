using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 讨论组 的模型类, 该类不能被继承
	/// </summary>
	public sealed class Discuss : BasisModel
	{
		#region --常量--
		/// <summary>
		/// 表示 <see cref="Discuss"/> 实例的最小唯一标识, 此字段为常数.
		/// </summary>
		public const long MinValue = 10000;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的唯一标识 (讨论组号)
		/// </summary>
		public long Id { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="Discuss"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="id">绑定于当前实例的唯一标识</param>
		/// <exception cref="ArgumentNullException">api 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">id 小于 <see cref="MinValue"/></exception>
		public Discuss (CQApi api, long id)
			: base (api)
		{
			if (id < MinValue)
			{
				throw new ArgumentOutOfRangeException (nameof (id));
			}

			this.Id = id;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (Discuss obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Id == obj.Id;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as Discuss);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Id.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return this;
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

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="long"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="Discuss"/> 实例</param>
		public static implicit operator long (Discuss value)
		{
			return value.Id;
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="Discuss"/> 实例</param>
		public static implicit operator string (Discuss value)
		{
			return ((long)value).ToString ();
		}
		/// <summary>
		/// 确定两个指定的 <see cref="Discuss"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Discuss a, Discuss b)
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
		/// 确定两个指定的 <see cref="Discuss"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Discuss a, Discuss b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="Discuss"/> 实例和 <see cref="long"/> 是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Discuss"/> 对象</param>
		/// <param name="b">要比较的 <see cref="long"/> 对象</param>
		/// <returns>如果是 a 的值与 b 相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Discuss a, long b)
		{
			if (a is null)
			{
				return false;
			}

			return a.Id == b;
		}
		/// <summary>
		/// 确定指定的 <see cref="Discuss"/> 实例和 <see cref="long"/> 是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Discuss"/> 对象</param>
		/// <param name="b">要比较的 <see cref="long"/> 对象</param>
		/// <returns>如果是 a 的值与 b 不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Discuss a, long b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="long"/> 和 <see cref="Discuss"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="long"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Discuss"/> 对象</param>
		/// <returns>如果是 a 与 b 的值相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (long a, Discuss b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="long"/> 和 <see cref="Discuss"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="long"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Discuss"/> 对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (long a, Discuss b)
		{
			return b != a;
		}
		/// <summary>
		/// 确定指定的 <see cref="Discuss"/> 实例和 <see cref="string"/> 是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Discuss"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果是 a 的值与 b 相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Discuss a, string b)
		{
			if (a is null && string.IsNullOrEmpty (b))
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
		/// 确定指定的 <see cref="Discuss"/> 实例和 <see cref="string"/> 是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="Discuss"/> 对象</param>
		/// <param name="b">要比较的 <see cref="string"/> 对象</param>
		/// <returns>如果是 a 的值与 b 不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Discuss a, string b)
		{
			return !(a == b);
		}
		/// <summary>
		/// 确定指定的 <see cref="string"/> 和 <see cref="Discuss"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Discuss"/> 对象</param>
		/// <returns>如果是 a 与 b 的值相同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (string a, Discuss b)
		{
			return b == a;
		}
		/// <summary>
		/// 确定指定的 <see cref="string"/> 和 <see cref="Discuss"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的 <see cref="string"/> 对象</param>
		/// <param name="b">要比较的 <see cref="Discuss"/> 对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (string a, Discuss b)
		{
			return b != a;
		}
		#endregion
	}
}
