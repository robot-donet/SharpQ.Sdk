using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 群成员类型 的枚举
	/// </summary>
	public enum GroupMemberType
	{
		/// <summary>
		/// 成员
		/// </summary>
		[Description ("成员")]
		Member = 1,
		/// <summary>
		/// 管理员
		/// </summary>
		[Description ("管理员")]
		Manager = 2,
		/// <summary>
		/// 群主
		/// </summary>
		[Description ("群主")]
		Creator = 3,
	}
}
