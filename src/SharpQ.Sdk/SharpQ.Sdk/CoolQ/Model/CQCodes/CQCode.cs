using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码 的模型类
	/// </summary>
	public class CQCode : BasisModel, IEquatable<CQCode>
	{
		#region --字段--
		private string _orginalString;
		private CQCodeFunctions _function;
		private readonly CQCodeContent _content;
		private static readonly Regex _funRegex = new Regex (@"\[CQ:([A-Za-z]*)(?:(,[^\[\]]+))?\]", RegexOptions.Compiled);
		private static readonly Regex _kvRegex = new Regex (@",([A-Za-z]+)=([^,\[\]]+)", RegexOptions.Compiled);
		#endregion

		#region --属性--
		/// <summary>
		/// 获取当前实例的功能
		/// </summary>
		public virtual CQCodeFunctions Function => _function;
		/// <summary>
		/// 获取当前实例的内容
		/// </summary>
		public CQCodeContent Content => _content;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定格式的字符串来初始化 <see cref="CQCode"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="text">绑定于当前实例的字符串</param>
		/// <exception cref="ArgumentNullException">api 或 text 为 null</exception>
		public CQCode (CQApi api, string text)
			: this (api, CQCodeFunctions.Unknown, null)
		{
			if (text is null)
			{
				throw new ArgumentNullException (nameof (text));
			}

			this._orginalString = text;
			this.GetFunction (this._orginalString);
			this.GetContent (this._orginalString);
		}
		/// <summary>
		/// 使用指定CQ码功能和对应的键值对初始化 <see cref="CQCode"/>  类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="function">指定当前实例功能的 <see cref="CQCodeFunctions"/></param>
		/// <param name="content">指定当前实例的内容键值对</param>
		public CQCode (CQApi api, CQCodeFunctions function, CQCodeContent content)
			: base (api)
		{
			this._function = function;
			this._content = content ?? new CQCodeContent ();

			this.SetProperty (this._content);
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (CQCode obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this.Function == obj.Function && this.Content == obj.Content;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as CQCode);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.Function.GetHashCode () & this.Content.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			if (string.IsNullOrEmpty (this._orginalString))
			{
				StringBuilder builder = new StringBuilder ();
				builder.Append ("[CQ:");
				builder.Append (this.Function.GetDescription ());
				if (this.Content != null)
				{
					builder.Append (",");
					builder.Append (this.Content);
				}
				builder.Append ("]");
				this._orginalString = builder.ToString ();
			}

			return this._orginalString;
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

		#region --私有方法--
		/// <summary>
		/// 当在派生类中重写时, 设置必要的属性值
		/// </summary>
		/// <param name="content">要设置的 <see cref="CQCodeContent"/></param>
		protected virtual void SetProperty (CQCodeContent content)
		{ }
		/// <summary>
		/// 获取字符串中的 CQ码 类型, 设置到当前实例中
		/// </summary>
		/// <param name="str">要解析的字符串</param>
		/// <exception cref="FormatException">str 不符合 CQ码 格式</exception>
		private void GetFunction (string str)
		{
			Match funMatch = CQCode._funRegex.Match (str);
			if (!funMatch.Success)
			{
				throw new FormatException ("传入的字符串不符合 CQ码 格式");
			}

			#region 解析CQ码类型
			if (!Enum.TryParse (funMatch.Groups[1].Value, true, out this._function))
			{
				this._function = CQCodeFunctions.Unknown;
			}
			#endregion
		}
		/// <summary>
		/// 获取字符串中的 CQ码 内容, 设置到当前实例中
		/// </summary>
		/// <param name="str">要解析的字符串</param>
		/// <exception cref="FormatException">str 不符合 CQ码 格式</exception>
		private void GetContent (string str)
		{
			Match funMatch = CQCode._funRegex.Match (str);
			if (!funMatch.Success)
			{
				throw new FormatException ("传入的字符串不符合 CQ码 格式");
			}

			#region 解析键值对
			string contentStr = funMatch.Groups[2].Value;
			MatchCollection contentCollection = CQCode._kvRegex.Matches (contentStr);
			foreach (Match item in contentCollection)
			{

				if (!Enum.TryParse (item.Groups[1].Value, true, out CQCodeKeys key))
				{
					throw new ArgumentException ($"解析到未知的键: {item.Groups[1].Value}", nameof (str));
				}

				this._content.Add (key, new CQCodeValue (item.Groups[2].Value));
			}
			#endregion

			// 设置子类属性
			this.SetProperty (this._content);
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="CQCode"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (CQCode a, CQCode b)
		{
			if (a is null && b is null)
			{
				return false;
			}

			if (a is null)
			{
				return false;
			}

			return a.Equals (b);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="CQCode"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (CQCode a, CQCode b)
		{
			return !(a == b);
		}
		#endregion

		/*
		[CQ:image,file=C6C954C53E03ADA35075C7AD929041BC.png]
		[CQ:record,file=2B89C664E86A4953BA8CFC2A7FCC8088.silk]
		[CQ:face,id=178]
		[CQ:emoji,id=128522]
		[CQ:bface,p=202991,id=2BC726E1D2234FCB7444A34A0EB27CF5]
		[CQ:shake,id=1]
		[CQ:at,qq=666]
		[CQ:rich,title=&#91;QQ小程序&#93;哔哩哔哩,content={"detail_1":{"shareTemplateData":{}&#44;"scene":1036&#44;"appid":"1109937557"&#44;"icon":"http://miniapp.gtimg.cn/public/appicon/432b76be3a548fc128acaa6c1ec90131_200.jpg"&#44;"preview":"external-30160.picsz.qpic.cn/e6d16fd53620d169ae3d436be39f469c/jpg1"&#44;"title":"哔哩哔哩"&#44;"qqdocurl":""&#44;"host":{"nick":"木馨"&#44;"uin":3305409920}&#44;"shareTemplateId":"8C8E89B49BE609866298ADDFF2DBABA4"&#44;"desc":"请病人不要死在走廊上 双点医院#1 &#91;杨远游戏实况&#93;"&#44;"url":"m.q.qq.com/a/s/719c429b939f90b3f6ef7b19beed874a"}}]
		[CQ:rich,title=全聚德土团通知,content={"mannounce":{"encode":1&#44;"fid":"ebc0b22b00000000dec4df5c105a0100"&#44;"gc":"733135083"&#44;"pic":&#91;{"height":451&#44;"url":"Ov6SVrwsmUQAnsNzd7icph95yuF5ocPZF5tUuoicWBXm8"&#44;"width":380}&#93;&#44;"sign":"5246ad9692927f6ebc142f0d3075da7a"&#44;"text":"5YWo6IGa5b635pys5qyh5Zyf5Zui55uu5qCHQei6uu+8jOmihOmAieS9nOS4muaaguWumuS4ujEwMDBX77yM5aaC5p6c5LiN5aSf6aKE6YCJ57q/5Lya5qC55o2u5a6e6ZmF5oOF5Ya16K+35aSn5a625aSa5omT5]
		[CQ:rich,text=位置分享      获取经纬度失败]
		[CQ:rich,url=https://music.apple.com/cn/album/theme/1452524230?i=1452524245,text=https://music.apple.com/cn/album/theme/1452524230?i=1452524245 https://music.apple.com/cn/album/theme/1452524230?i=1452524245]
		[CQ:rich,url=http://v.gdt.qq.com/gdt_stats.fcg?viewid=cV!X65Zm58loatVltYAuHSUb3mJ1hGpMU7XA_JhLBH8NQ5inJe!X_KlobExzjgScKVMlnscMenkK8g99Rt57OWW0Lh7uSznW2tpmmqFlSoSwCQZYASRdNq0dM4wKZ0yuMqXIlbTYQNB38RmcM!lLcDxkaVooD!JN8Dx4yBUZDUiq87lPch19v2QKBSwaIUpk597jrSSTKqo2Aj9VSJFvoI_jmLiL55iuwaXI1Yu4IoYx4Xl5HICUwrIIimfWXBF_8QxfJaR!QLcfTUIatcR4Ug&i=1&os=2&xp=2,text=在上海，只要你是“1999”年出生的，即可领取1000元写真价值券！ 领取之后，一年有效 阅读全文]
		[CQ:rich,content={"about":{"DATA7":""&#44;"DATA12":"该群涉嫌违规"&#44;"DATA11":"即将封禁该群"&#44;"DATA9":""&#44;"DATA10":""&#44;"DATA13":""&#44;"time":"1564437550"&#44;"DATA8":""}}]
		[CQ:contact,id=827572487,type=group]
		[CQ:contact,id=827572487,type=qq]
		[CQ:anonymous,ignore=true]
		*/
	}
}
