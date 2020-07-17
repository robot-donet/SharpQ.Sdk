using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "戳一戳" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeShake : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的戳一戳 "id"
		/// </summary>
		public int? Id
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Id))
				{
					return this.Dictionary[CQCodeKeys.Id];
				}

				return null;
			}
		}
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeShake"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeShake (string text)
			: base (text)
		{ }
		/// <summary>
		/// 初始化 <see cref="CQCodeShake"/> 类的新实例
		/// </summary>
		public CQCodeShake ()
			: base (CQCodeFunctions.Shake, null)
		{ }
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeShake"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeShake (string value)
		{
			return new CQCodeShake (value);
		}
		#endregion
	}
}
