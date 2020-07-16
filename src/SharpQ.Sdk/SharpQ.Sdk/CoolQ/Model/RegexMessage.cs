using SharpQ.Sdk.Utility;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 正则消息 的模型类, 该类不能被继承
	/// </summary>
	public sealed class RegexMessage : Message, IReadOnlyDictionary<string, string>
	{
		#region --字段--
		private readonly Dictionary<string, string> _dict;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取与指定的键关联的值
		/// </summary>
		/// <param name="key">要获取或设置的值的键</param>
		/// <returns>与指定的键相关联的值。 如果指定键未找到，则 Get 操作引发 <see cref="KeyNotFoundException"/></returns>
		/// <exception cref="KeyNotFoundException">已检索该属性且集合中不存在 key</exception>
		public string this[string key] => this._dict[key];
		/// <summary>
		/// 获得一个包含 <see cref="RegexMessage"/> 中的键的集合
		/// </summary>
		/// <returns>一个 <see cref="IEnumerable{T}"/>，包含 <see cref="RegexMessage"/> 中的键</returns>
		public IEnumerable<string> Keys => this._dict.Keys;
		/// <summary>
		/// 获得一个包含 <see cref="RegexMessage"/> 中的值的集合
		/// </summary>
		/// <returns>一个 <see cref="IEnumerable{T}"/>，包含 <see cref="RegexMessage"/> 中的值</returns>
		public IEnumerable<string> Values => this._dict.Values;
		/// <summary>
		/// 获取包含在 <see cref="RegexMessage"/> 中的键/值对的数目
		/// </summary>
		/// <returns>包含在 <see cref="RegexMessage"/> 中的键/值对的数目</returns>
		public int Count => this._dict.Count;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 使用指定的消息内容和消息标识初始化 <see cref="Message"/> 类的新实例, 并且持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="msgId">绑定于当前实例的消息标识</param>
		/// <param name="msg">绑定于当前实例的消息内容字符串</param>
		/// <exception cref="ArgumentNullException">api 或 msg 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">msgId 的值小于 0</exception>
		public RegexMessage (CQApi api, int msgId, string msg)
			: base (api, msgId, msg)
		{
			try
			{
				this._dict = new Dictionary<string, string> ();

				byte[] base64Buffer = Convert.FromBase64String (msg);
				using (BinaryReader reader = new BinaryReader (new MemoryStream (base64Buffer)))
				{
					this.Initialize (reader);
				}
			}
			catch (FormatException)
			{
				throw;
			}
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 确定是否 <see cref="RegexMessage"/> 包含指定键
		/// </summary>
		/// <param name="key">要在 <see cref="RegexMessage"/> 中定位的键</param>
		/// <returns>如果 <see cref="RegexMessage"/> 包含具有指定键的元素，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool ContainsKey (string key)
		{
			return this._dict.ContainsKey (key);
		}
		/// <summary>
		/// 获取与指定键关联的值
		/// </summary>
		/// <param name="key">要获取的值的键</param>
		/// <param name="value">当此方法返回时，如果找到指定键，则包含与该键相关的值；否则包含 value 参数类型的默认值。 此参数未经初始化即被传递</param>
		/// <returns>如果 <see cref="RegexMessage"/> 包含具有指定键的元素，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool TryGetValue (string key, out string value)
		{
			return this._dict.TryGetValue (key, out value);
		}
		/// <summary>
		/// 返回循环访问 <see cref="RegexMessage"/> 的枚举数
		/// </summary>
		/// <returns>用于 <see cref="RegexMessage"/> 的 <see cref="IEnumerator{T}"/> 结构。</returns>
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator ()
		{
			return this._dict.GetEnumerator ();
		}
		/// <summary>
		/// 返回循环访问 <see cref="RegexMessage"/> 的枚举数
		/// </summary>
		/// <returns>用于 <see cref="RegexMessage"/> 的 <see cref="IEnumerator"/> 结构。</returns>
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this._dict.GetEnumerator ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine ($"ID: {this.Id}, 消息内容: {this.Text}");
			builder.Append (this.GetMessage ());
			return builder.ToString ();
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public override string GetMessage ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine ("解析结果:");
			foreach (KeyValuePair<string, string> item in this)
			{
				builder.AppendLine ($"{{键: {item.Key}, 值: {item.Value}}}");
			}
			return builder.ToString ();
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (reader.Length () < 4)
			{
				throw new InvalidDataException ("数据长度小于 4");
			}

			int count = reader.ReadInt32_Ex ();
			for (int i = 0; i < count; i++)
			{
				using (BinaryReader tempReader = new BinaryReader (new MemoryStream (reader.ReadToken_Ex ())))
				{
					if (tempReader.Length () < 4)
					{
						throw new InvalidDataException ("数据长度小于 4");
					}

					string key = tempReader.ReadString_Ex (Global.DefaultEncoding);
					string value = tempReader.ReadString_Ex (Global.DefaultEncoding);

					this._dict.Add (key, value);
				}
			}

		}
		#endregion
	}
}
