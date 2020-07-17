using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "语音 " 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeRecord : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的文件相对路径
		/// </summary>
		public string File => this.Dictionary[CQCodeKeys.File];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeRecord"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeRecord (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.File);
		}
		/// <summary>
		/// 使用指定的图片路径来初始化 <see cref="CQCodeRecord"/> 类的新实例
		/// </summary>
		/// <param name="filePath">
		///		图片的相对路径. 
		///		<para>请将图片放在 <see langword="\酷Q\data\image"/> 下, 如 <see langword="\酷Q\data\image\1.jpg"/> 则填写 <see langword="1.jpg"/></para>
		/// </param>
		/// <param name="reserve">保留参数</param>
		public CQCodeRecord (string filePath, object reserve = null)
			: base (CQCodeFunctions.Record, new CQCodeDictionary ()
			{
				{ CQCodeKeys.File, filePath }
			})
		{

		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeRecord"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeRecord (string value)
		{
			return new CQCodeRecord (value);
		}
		#endregion
	}
}
