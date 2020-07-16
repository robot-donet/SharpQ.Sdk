using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 操作请求 的模型类, 该类不能被继承
	/// </summary>
	public sealed class Request : BasisModel, IEquatable<Request>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的请求反馈标识
		/// </summary>
		public string ResponseFlag { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="BasisStreamModel"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="responseFlag">绑定于当前实例用于后续操作的请求反馈标识</param>
		/// <exception cref="ArgumentNullException">api 或 responseFlag 为 null</exception>
		public Request (CQApi api, string responseFlag)
			: base (api)
		{
			if (responseFlag is null)
			{
				throw new ArgumentNullException (nameof (responseFlag));
			}
			ResponseFlag = responseFlag;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (Request obj)
		{
			if (obj is null)
			{
				return false;
			}

			return string.Compare (this.ResponseFlag, obj.ResponseFlag) == 0;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as Request);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.ResponseFlag.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{反馈标识: {this.ResponseFlag}}}";
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
		/// 定义将当前实例转化为 <see cref="string"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="Request"/> 实例</param>
		public static implicit operator string (Request value)
		{
			return value.ResponseFlag;
		}
		/// <summary>
		/// 确定两个指定的 <see cref="Request"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (Request a, Request b)
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
		/// 确定两个指定的 <see cref="Request"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (Request a, Request b)
		{
			return !(a == b);
		}
		#endregion
	}
}
