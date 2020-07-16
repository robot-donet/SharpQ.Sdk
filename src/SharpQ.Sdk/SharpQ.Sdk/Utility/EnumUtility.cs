using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.Utility
{
	internal static class EnumUtility
	{
		/// <summary>
		/// 获取枚举成员上的 <see cref="DescriptionAttribute"/> 标记的值
		/// </summary>
		/// <param name="value">要获取标记的枚举值</param>
		/// <returns>如果成功获取标记, 则为标记 <see cref="DescriptionAttribute.Description"/> 的值, 否则为 <see cref="string.Empty"/></returns>
		public static string GetDescription (this Enum value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			try
			{
				Type type = value.GetType ();
				FieldInfo fieldInfo = type.GetField (value.ToString ());
				DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute> (false);
				return attribute.Description;
			}
			catch
			{ }

			return string.Empty;
		}
	}
}
