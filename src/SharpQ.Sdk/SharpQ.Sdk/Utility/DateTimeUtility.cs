using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.Utility
{
	internal static class DateTimeUtility
	{
		#region --字段--
		private static readonly DateTime _localTime; 
		#endregion

		#region --构造函数--
		static DateTimeUtility ()
		{
			_localTime = TimeZone.CurrentTimeZone.ToLocalTime (new DateTime (1970, 1, 1));
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 以当前计算机时区为基准, 将 <see cref="int"/> 时间戳转换为以 "1970年1月1日" 为起始点的 <see cref="DateTime"/> 类型的标准时间
		/// </summary>
		/// <param name="unixTime">要转换的 UNIX 时间戳</param>
		/// <returns>当前计算机时区的标准时间</returns>
		/// <exception cref="ArgumentOutOfRangeException">unixTime 小于 0</exception>
		public static DateTime GetDateTime (this int unixTime)
		{
			if (unixTime < 0)
			{
				throw new ArgumentOutOfRangeException (nameof (unixTime));
			}

			return _localTime.Add (TimeSpan.FromSeconds (Convert.ToDouble (unixTime)));
		} 
		#endregion
	}
}
