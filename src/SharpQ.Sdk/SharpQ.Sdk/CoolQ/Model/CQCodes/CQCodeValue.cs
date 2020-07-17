using System;
using System.Text;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码值 的模型类
	/// </summary>
	public class CQCodeValue : IEquatable<CQCodeValue>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的原始值
		/// </summary>
		public string Value { get; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQCodeValue"/> 类的新实例
		/// </summary>
		/// <param name="value">一个 <see cref="string"/> 对象</param>
		public CQCodeValue (string value)
		{
			this.Value = Decode (value);
		}
		/// <summary>
		/// 初始化 <see cref="CQCodeValue"/> 类的新实例
		/// </summary>
		/// <param name="value">一个 <see cref="int"/> 对象</param>
		public CQCodeValue (int value)
		{
			this.Value = Convert.ToString (value);
		}
		/// <summary>
		/// 初始化 <see cref="CQCodeValue"/> 类的新实例
		/// </summary>
		/// <param name="value">一个 <see cref="long"/> 对象</param>
		public CQCodeValue (long value)
		{
			this.Value = Convert.ToString (value);
		}
		/// <summary>
		/// 初始化 <see cref="CQCodeValue"/> 类的新实例
		/// </summary>
		/// <param name="value">一个 <see cref="double"/> 对象</param>
		public CQCodeValue (double value)
		{
			this.Value = Convert.ToString (value);
		}
		/// <summary>
		/// 初始化 <see cref="CQCodeValue"/> 类的新实例
		/// </summary>
		/// <param name="value">一个 <see cref="bool"/> 对象</param>
		public CQCodeValue (bool value)
		{
			this.Value = Convert.ToString (value).ToLower ();
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (CQCodeValue obj)
		{
			if (obj is null)
			{
				return false;
			}

			return string.Compare (this.Value, obj.Value) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as CQCodeValue);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Value.GetHashCode ();
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
		/// 将指定的字符串根据 CQ码 的编码规则进行转义
		/// </summary>
		/// <param name="str">要编码的原始字符串</param>
		/// <param name="escapeComma">是否转义逗号, 默认: False</param>
		/// <returns>转义后的字符串</returns>
		public static string Encode (string str, bool escapeComma = false)
		{
			StringBuilder builder = new StringBuilder (str);
			builder.Replace ("&", "&amp;");
			builder.Replace ("[", "&#91;");
			builder.Replace ("]", "&#93;");
			if (escapeComma)
			{
				builder.Replace (",", "&#44;");
			}
			return builder.ToString ();
		}
		/// <summary>
		/// 将指定的字符串根据 CQ码 的解码规则进行反转义
		/// </summary>
		/// <param name="str">要编码的原始字符串</param>
		/// <returns>反转义后的字符串</returns>
		public static string Decode (string str)
		{
			StringBuilder builder = new StringBuilder (str);
			builder.Replace ("&#91;", "[");
			builder.Replace ("&#93;", "]");
			builder.Replace ("&#44;", ",");
			builder.Replace ("&amp;", "&");
			return builder.ToString ();
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator string (CQCodeValue value)
		{
			return Encode (value.Value, true);
		}
		/// <summary>
		/// 定义将 <see cref="string"/> 实例转化为 <see cref="CQCodeValue"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator CQCodeValue (string value)
		{
			return new CQCodeValue (value);
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="int"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator int (CQCodeValue value)
		{
			return Convert.ToInt32 ((string)value);
		}
		/// <summary>
		/// 定义将 <see cref="int"/> 实例转化为 <see cref="CQCodeValue"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator CQCodeValue (int value)
		{
			return new CQCodeValue (value);
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="long"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator long (CQCodeValue value)
		{
			return Convert.ToInt64 ((string)value);
		}
		/// <summary>
		/// 定义将 <see cref="long"/> 实例转化为 <see cref="CQCodeValue"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator CQCodeValue (long value)
		{
			return new CQCodeValue (value);
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="double"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator double (CQCodeValue value)
		{
			return Convert.ToDouble ((string)value);
		}
		/// <summary>
		/// 定义将 <see cref="double"/> 实例转化为 <see cref="CQCodeValue"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator CQCodeValue (double value)
		{
			return new CQCodeValue (value);
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="bool"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator bool (CQCodeValue value)
		{
			return Convert.ToBoolean ((string)value);
		}
		/// <summary>
		/// 定义将 <see cref="bool"/> 实例转化为 <see cref="CQCodeValue"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCodeValue"/> 实例</param>
		public static implicit operator CQCodeValue (bool value)
		{
			return new CQCodeValue (value);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="CQCodeValue"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (CQCodeValue a, CQCodeValue b)
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
		/// 确定两个指定的 <see cref="CQCodeValue"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (CQCodeValue a, CQCodeValue b)
		{
			return !(a == b);
		}
		#endregion
	}
}
