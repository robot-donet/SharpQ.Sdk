using SharpQ.Sdk.CoolQ.Interface;
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
	/// 表示 CoolQ 应用程序的 悬浮窗 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQFloatWindow : IEquatable<CQFloatWindow>, IGetMessage
	{
		#region --属性--
		/// <summary>
		/// 获取或设置当前悬浮窗的值
		/// </summary>
		public object Value { get; set; }
		/// <summary>
		/// 获取或设置当前悬浮窗使用的单位
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		/// 获取或设置当前悬浮窗的文本颜色
		/// </summary>
		public CQFloatWindowColors TextColor { get; set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQFloatWindow"/> 类的新实例
		/// </summary>
		public CQFloatWindow ()
			: this (string.Empty, string.Empty, CQFloatWindowColors.Black)
		{ }
		/// <summary>
		/// 初始化 <see cref="CQFloatWindow"/> 类的新实例
		/// </summary>
		/// <param name="value">用于展示的数据值</param>
		public CQFloatWindow (object value)
			: this (value, string.Empty, CQFloatWindowColors.Black)
		{ }
		/// <summary>
		/// 初始化 <see cref="CQFloatWindow"/> 类的新实例
		/// </summary>
		/// <param name="value">用于展示的数据值</param>
		/// <param name="unit">数据值的单位</param>
		public CQFloatWindow (object value, string unit)
			: this (value, unit, CQFloatWindowColors.Black)
		{ }
		/// <summary>
		/// 初始化 <see cref="CQFloatWindow"/> 类的新实例
		/// </summary>
		/// <param name="value">用于展示的数据值</param>
		/// <param name="unit">数据值的单位</param>
		/// <param name="textColor">文本颜色</param>
		public CQFloatWindow (object value, string unit, CQFloatWindowColors textColor)
		{
			this.Value = value ?? throw new ArgumentNullException ("value");
			this.Unit = unit;
			this.TextColor = textColor;
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 other 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (CQFloatWindow obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Value.Equals (obj.Value)
				&& string.Compare (this.Unit, obj.Unit) == 0
				&& this.TextColor == obj.TextColor;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 other 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as CQFloatWindow);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return Value.GetHashCode () & this.Unit.GetHashCode () & this.TextColor.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{值: {this.Value}, 单位: {this.Unit}, 颜色: {this.TextColor.GetDescription ()}}}";
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public string GetMessage ()
		{
			using (BinaryWriter writer = new BinaryWriter (new MemoryStream ()))
			{
				writer.Write_Ex (Convert.ToString (this.Value));
				writer.Write_Ex (this.Unit ?? string.Empty);
				writer.Write_Ex ((int)this.TextColor);
				return Convert.ToBase64String (writer.ToArray ());
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="CQFloatWindow"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (CQFloatWindow a, CQFloatWindow b)
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
		/// 确定两个指定的 <see cref="CQFloatWindow"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (CQFloatWindow a, CQFloatWindow b)
		{
			return !(a == b);
		}
		#endregion
	}
}
