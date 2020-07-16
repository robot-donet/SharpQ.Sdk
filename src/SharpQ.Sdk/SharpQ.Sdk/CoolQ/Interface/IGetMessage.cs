using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Interface
{
	/// <summary>
	/// 表示 CoolQ 应用程序获取消息字符串的接口
	/// </summary>
	public interface IGetMessage
	{
		/// <summary>
		/// 在派生类中重写时, 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		string GetMessage ();
	}
}
