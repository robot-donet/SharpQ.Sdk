using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 音乐来源 的枚举
	/// </summary>
	public enum CQMusicSources
	{
        /// <summary>
        /// 未知来源
        /// </summary>
        [Description("unknown")]
        Unknown,
        /// <summary>
        /// QQ 音乐
        /// </summary>
        [Description ("qq")]
        Tencent,
        /// <summary>
        /// 网易云音乐
        /// </summary>
        [Description ("163")]
        Netease,
        /// <summary>
        /// 虾米音乐
        /// </summary>
        [Description ("xiami")]
        XiaMi
    }
}
