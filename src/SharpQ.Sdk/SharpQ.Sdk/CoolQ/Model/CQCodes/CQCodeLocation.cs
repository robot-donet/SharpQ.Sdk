using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 "位置" 的模型类, 该类不能被继承
	/// </summary>
	public sealed class CQCodeLocation : CQCode
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的纬度
		/// </summary>
		public double Lat => (double)this.Dictionary[CQCodeKeys.Lat];
		/// <summary>
		/// 获取当前实例的经度
		/// </summary>
		public double Lon => (double)this.Dictionary[CQCodeKeys.Lon];
		/// <summary>
		/// 获取当前实例的放大倍数
		/// </summary>
		public int Zoom
		{
			get
			{
				if (this.Dictionary.ContainsKey (CQCodeKeys.Zoom))
				{
					return this.Dictionary[CQCodeKeys.Zoom];
				}

				return 15;
			}
		}
		/// <summary>
		/// 获取当前实例的地点
		/// </summary>
		public string Site => this.Dictionary[CQCodeKeys.Title];
		/// <summary>
		/// 获取当前实例的位置
		/// </summary>
		public string Location => this.Dictionary[CQCodeKeys.Content];
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCodeLocation"/> 类的新实例
		/// </summary>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">text 为 null</exception>
		public CQCodeLocation (string text)
			: base (text)
		{
			base.ThrowKeyNotFound (CQCodeKeys.Lat);
			base.ThrowKeyNotFound (CQCodeKeys.Lon);
			base.ThrowKeyNotFound (CQCodeKeys.Title);
			base.ThrowKeyNotFound (CQCodeKeys.Content);
		}
		/// <summary>
		/// 使用指定的经纬度和位置信息来初始化 <see cref="CQCodeLocation"/> 类的新实例
		/// </summary>
		/// <param name="lat">经纬度中的纬度值</param>
		/// <param name="lon">经纬度中的经度值</param>
		/// <param name="site">描述指定位置的地点名称</param>
		/// <param name="location">描述指定位置的详细地址. (建议20个字以内)</param>
		/// <param name="zoom">指示分享后呈现地图的放大倍数. 默认: 15倍</param>
		public CQCodeLocation (double lat, double lon, string site, string location, int? zoom = null)
			: base (CQCodeFunctions.Location, new CQCodeDictionary ()
			{
				{ CQCodeKeys.Lat, lat },
				{ CQCodeKeys.Lon, lon },
				{ CQCodeKeys.Title, site },
				{ CQCodeKeys.Content, location }
			})
		{
			if (zoom != null)
			{
				this.Dictionary.Add (CQCodeKeys.Zoom, zoom.Value);
			}
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 定义将当前实例转化为 <see cref="CQCodeLocation"/>
		/// </summary>
		/// <param name="value">转换的 <see cref="string"/> 实例</param>
		public static implicit operator CQCodeLocation (string value)
		{
			return new CQCodeLocation (value);
		}
		#endregion
	}
}
