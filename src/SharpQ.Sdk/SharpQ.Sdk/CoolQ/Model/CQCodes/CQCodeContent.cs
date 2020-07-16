using SharpQ.Sdk.CoolQ.Interface;
using SharpQ.Sdk.Utility;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model.CQCodes
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 CQ码内容 的模型类
	/// </summary>
	public class CQCodeContent : IGetMessage, IDictionary<CQCodeKeys, CQCodeValue>, IEquatable<CQCodeContent>
	{
		#region --字段--
		private readonly Dictionary<CQCodeKeys, CQCodeValue> _dict;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取或设置与指定的键关联的值
		/// </summary>
		/// <param name="key">要获取或设置的值的键</param>
		/// <returns>与指定的键相关联的值。 如果指定键未找到，则 Get 操作引发 <see cref="KeyNotFoundException"/>，而 Set 操作创建一个带指定键的新元素</returns>
		/// <exception cref="ArgumentNullException">key 为 null</exception>
		/// <exception cref="KeyNotFoundException">已检索该属性且集合中不存在 key</exception>
		public CQCodeValue this[CQCodeKeys key]
		{
			get => this._dict[key];
			set => this._dict[key] = value;
		}
		/// <summary>
		/// 获得一个包含 <see cref="CQCodeContent"/> 中的键的集合
		/// </summary>
		public ICollection<CQCodeKeys> Keys => this._dict.Keys;
		/// <summary>
		/// 获得一个包含 <see cref="CQCodeContent"/> 中的值的集合
		/// </summary>
		public ICollection<CQCodeValue> Values => this._dict.Values;
		/// <summary>
		/// 获取包含在 <see cref="CQCodeContent"/> 中的键/值对的数目
		/// </summary>
		public int Count => this._dict.Count;
		/// <summary>
		/// 获取一个值，该值指示 <see cref="CQCodeContent"/> 是否为只读
		/// </summary>
		bool ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>.IsReadOnly => ((ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>)this._dict).IsReadOnly;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQCodeContent"/> 类的新实例，该实例为空
		/// </summary>
		public CQCodeContent ()
			: this (0)
		{ }
		/// <summary>
		/// 初始化 <see cref="CQCodeContent"/> 类的新实例，该实例为空，具有指定的初始容量
		/// </summary>
		/// <param name="capacity"><see cref="CQCodeContent"/> 可包含的初始元素数</param>
		/// <exception cref="ArgumentOutOfRangeException">capacity 小于 0</exception>
		public CQCodeContent (int capacity)
		{
			this._dict = new Dictionary<CQCodeKeys, CQCodeValue> (capacity);
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 将指定的键和值添加到 <see cref="CQCodeContent"/> 中
		/// </summary>
		/// <param name="key">要添加的元素的键</param>
		/// <param name="value">要添加的元素的值</param>
		/// <exception cref="ArgumentNullException">value 为 null</exception>
		public void Add (CQCodeKeys key, CQCodeValue value)
		{
			if (value is null)
			{
				throw new ArgumentNullException (nameof (value));
			}

			this._dict.Add (key, value);
		}
		/// <summary>
		/// 确定 <see cref="CQCodeContent"/> 是否包含带有指定键的元素
		/// </summary>
		/// <param name="key">要在 <see cref="CQCodeContent"/> 中定位的键</param>
		/// <returns>如果 <see cref="CQCodeContent"/> 包含具有键的元素，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool ContainsKey (CQCodeKeys key)
		{
			return this._dict.ContainsKey (key);
		}
		/// <summary>
		/// 从 <see cref="CQCodeContent"/> 中移除带有指定键的元素
		/// </summary>
		/// <param name="key">要移除的元素的键</param>
		/// <returns>如果该元素已成功移除，则为 <see langword="true"/>；否则为 <see langword="false"/>。 如果在原始 <see cref="CQCodeContent"/> 中没有找到 key，此方法也会返回 <see langword="false"/></returns>
		public bool Remove (CQCodeKeys key)
		{
			return this._dict.Remove (key);
		}
		/// <summary>
		/// 获取与指定键关联的值
		/// </summary>
		/// <param name="key">要获取其值的键</param>
		/// <param name="value">当此方法返回时，如果找到指定键，则返回与该键相关联的值；否则，将返回 value 参数的类型的默认值。 此参数未经初始化即被传递</param>
		/// <returns>如果 <see cref="CQCodeContent"/> 包含具有指定键的元素，则为 <see langword="true"/>；否则，为 <see langword="false"/></returns>
		/// <exception cref="ArgumentNullException">key 为 null</exception>
		public bool TryGetValue (CQCodeKeys key, out CQCodeValue value)
		{
			return this._dict.TryGetValue (key, out value);
		}
		/// <summary>
		/// 从 <see cref="CQCodeContent"/> 中移除所有项
		/// </summary>
		public void Clear ()
		{
			this._dict.Clear ();
		}
		/// <summary>
		/// 返回一个循环访问集合的枚举器
		/// </summary>
		/// <returns>用于循环访问集合的枚举数</returns>
		public IEnumerator<KeyValuePair<CQCodeKeys, CQCodeValue>> GetEnumerator ()
		{
			return this._dict.GetEnumerator ();
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (CQCodeContent obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this._dict.SequenceEqual (obj._dict);
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as CQCodeContent);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this._dict.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();

			for (int i = 0; i < this.Count; i++)
			{
				CQCodeKeys key = this.Keys.ElementAt (i);
				CQCodeValue value = this.Values.ElementAt (i);

				builder.Append ($"{key.GetDescription ()}={value}");
				if (i < this.Count - 1)
				{
					builder.Append (",");
				}
			}

			return builder.ToString ();
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public string GetMessage ()
		{
			return this.ToString ();
		}
		/// <summary>
		/// 将某项添加到 <see cref="ICollection{T}"/> 中
		/// </summary>
		/// <param name="item">要添加到 <see cref="ICollection{T}"/> 的对象</param>
		void ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>.Add (KeyValuePair<CQCodeKeys, CQCodeValue> item)
		{
			this.Add (item.Key, item.Value);
		}
		/// <summary>
		/// 从特定的 <see cref="ICollection{T}"/> 索引处开始，将 System.Array 的元素复制到一个 <see cref="Array"/> 中
		/// </summary>
		/// <param name="array">一维 <see cref="Array"/>，它是从 <see cref="ICollection{T}"/> 复制的元素的目标。 <see cref="Array"/> 必须具有从零开始的索引</param>
		/// <param name="arrayIndex">array 中从零开始的索引，从此处开始复制</param>
		/// <exception cref="ArgumentNullException">array 为 null</exception>
		/// <exception cref="ArgumentOutOfRangeException">arrayIndex 小于 0</exception>
		void ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>.CopyTo (KeyValuePair<CQCodeKeys, CQCodeValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>)this._dict).CopyTo (array, arrayIndex);
		}
		/// <summary>
		/// 从 <see cref="ICollection{T}"/> 中移除特定对象的第一个匹配项
		/// </summary>
		/// <param name="item">要从 <see cref="ICollection{T}"/> 中删除的对象</param>
		/// <returns>如果从 <see cref="ICollection{T}"/> 中成功移除 item，则为 <see langword="true"/>；否则为 <see langword="false"/>。 如果在原始 <see cref="ICollection{T}"/> 中没有找到 item，该方法也会返回 <see langword="false"/></returns>
		bool ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>.Remove (KeyValuePair<CQCodeKeys, CQCodeValue> item)
		{
			return ((ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>)this._dict).Remove (item);
		}
		/// <summary>
		/// 确定 <see cref="ICollection{T}"/> 是否包含特定值
		/// </summary>
		/// <param name="item">要在 <see cref="ICollection{T}"/> 中定位的对象</param>
		/// <returns>如果在 <see cref="ICollection{T}"/> 中找到 item，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		bool ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>.Contains (KeyValuePair<CQCodeKeys, CQCodeValue> item)
		{
			return ((ICollection<KeyValuePair<CQCodeKeys, CQCodeValue>>)this._dict).Contains (item);
		}
		/// <summary>
		/// 返回一个循环访问集合的枚举器
		/// </summary>
		/// <returns>用于循环访问集合的枚举数</returns>
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return ((IEnumerable<KeyValuePair<CQCodeKeys, CQCodeValue>>)this).GetEnumerator ();
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="CQCodeContent"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (CQCodeContent a, CQCodeContent b)
		{
			if (a is null && b is null)
			{
				return true;
			}

			if (a is null)
			{
				return false;
			}

			return a.Equals (b);
		}
		/// <summary>
		/// 确定两个指定的 <see cref="CQCodeContent"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (CQCodeContent a, CQCodeContent b)
		{
			return !(a == b);
		}
		#endregion
	}
}
