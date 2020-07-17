using SharpQ.Sdk.CoolQ.Interface;
using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 的模型类
	/// </summary>
	public class CQCode : IGetMessage, IEquatable<CQCode>
	{
		#region --字段--
		private string _orginalString;
		private CQCodeFunctions _function;
		private readonly CQCodeDictionary _dictionary;
		private static readonly Regex _funRegex = new Regex (@"\[CQ:([A-Za-z]*)(?:(,[^\[\]]+))?\]", RegexOptions.Compiled);
		private static readonly Regex _kvRegex = new Regex (@",([A-Za-z]+)=([^,\[\]]+)", RegexOptions.Compiled);
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的功能
		/// </summary>
		public virtual CQCodeFunctions Function => _function;
		/// <summary>
		/// 获取当前实例的键值对
		/// </summary>
		public CQCodeDictionary Dictionary => _dictionary;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCode"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCode (string text)
			: this (CQCodeFunctions.Unknown, null)
		{
			if (text is null)
			{
				throw new ArgumentNullException (nameof (text));
			}

			this._orginalString = text;
			this.GetFunction (this._orginalString);
			this.GetContent (this._orginalString);
		}
		/// <summary>
		/// 使用指定CQ码功能和对应的键值对初始化 <see cref="CQCode"/>  类的新实例
		/// </summary>
		/// <param name="function">指定当前实例功能的 <see cref="CQCodeFunctions"/></param>
		/// <param name="content">指定当前实例的内容键值对</param>
		public CQCode (CQCodeFunctions function, CQCodeDictionary content)
		{
			this._function = function;
			this._dictionary = content ?? new CQCodeDictionary ();
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (CQCode obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Function == obj.Function && this.Dictionary == obj.Dictionary;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as CQCode);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Function.GetHashCode () & this.Dictionary.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			if (string.IsNullOrEmpty (this._orginalString))
			{
				StringBuilder builder = new StringBuilder ();
				builder.Append ("[CQ:");
				builder.Append (this.Function.GetDescription ());
				if (this.Dictionary != null)
				{
					if (this.Dictionary.Count > 0)
					{
						builder.Append (",");
						builder.Append (this.Dictionary);
					}
				}
				builder.Append ("]");
				this._orginalString = builder.ToString ();
			}

			return this._orginalString;
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public string GetMessage ()
		{
			return this.ToString ();
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 检查指定的 Key 是否存在, 如果不存在则抛出 <see cref="KeyNotFoundException"/>
		/// </summary>
		/// <param name="key">要在 <see cref="CQCode"/> 中检查的 Key</param>
		protected void ThrowKeyNotFound (CQCodeKeys key)
		{
			if (!this.Dictionary.ContainsKey (key))
			{
				throw new KeyNotFoundException ($"不存在键: \"{key.GetDescription ()}\"");
			}
		}
		/// <summary>
		/// 获取字符串中的 CQ码 类型, 设置到当前实例中
		/// </summary>
		/// <param name="str">要解析的字符串</param>
		/// <exception cref="FormatException">str 不符合 CQ码 格式</exception>
		private void GetFunction (string str)
		{
			Match funMatch = CQCode._funRegex.Match (str);
			if (!funMatch.Success)
			{
				throw new FormatException ("传入的字符串不符合 CQ码 格式");
			}

			#region 解析CQ码类型
			if (!Enum.TryParse (funMatch.Groups[1].Value, true, out this._function))
			{
				this._function = CQCodeFunctions.Unknown;
			}
			#endregion
		}
		/// <summary>
		/// 获取字符串中的 CQ码 内容, 设置到当前实例中
		/// </summary>
		/// <param name="str">要解析的字符串</param>
		/// <exception cref="FormatException">str 不符合 CQ码 格式</exception>
		private void GetContent (string str)
		{
			Match funMatch = CQCode._funRegex.Match (str);
			if (!funMatch.Success)
			{
				throw new FormatException ("传入的字符串不符合 CQ码 格式");
			}

			#region 解析键值对
			string contentStr = funMatch.Groups[2].Value;
			MatchCollection contentCollection = CQCode._kvRegex.Matches (contentStr);
			foreach (Match item in contentCollection)
			{

				if (!Enum.TryParse (item.Groups[1].Value, true, out CQCodeKeys key))
				{
					throw new ArgumentException ($"解析到未知的键: {item.Groups[1].Value}", nameof (str));
				}

				this._dictionary.Add (key, new CQCodeValue (item.Groups[2].Value));
			}
			#endregion
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCode"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCode (string value)
		{
			return new CQCode (value);
		}
		/// <summary>
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="CQCode"/> 实例</param>
		public static implicit operator string (CQCode value)
		{
			return value.ToString ();
		}
		/// <summary>
		/// 确定两个指定的 <see cref="CQCode"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (CQCode a, CQCode b)
		{
			if (a is null && b is null)
			{
				return false;
			}

			if (a is null)
			{
				return false;
			}

			return a.Equals (b);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="CQCode"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (CQCode a, CQCode b)
		{
			return !(a == b);
		}
		#endregion
	}
}
