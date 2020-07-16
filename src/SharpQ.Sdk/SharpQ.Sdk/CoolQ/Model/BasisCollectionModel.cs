using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 列表数据 模型基类, 该类是抽象的
	/// </summary>
	/// <typeparam name="T">列表中元素的类型</typeparam>
	public abstract class BasisCollectionModel<T> : BasisStreamModel, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IEquatable<BasisCollectionModel<T>>
	{
		#region --字段--
		/// <summary>
		/// 获取当前实例保护的列表数据
		/// </summary>
		protected readonly List<T> _list;
		#endregion

		#region --属性--
		/// <summary>
		/// 获取集合中的元素数
		/// </summary>
		public int Count => this._list.Count;
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="BasisCollectionModel{T}"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <exception cref="ArgumentNullException">api 为 null</exception>
		protected BasisCollectionModel (CQApi api)
			: base (api)
		{
			this._list = new List<T> ();
		}
		/// <summary>
		///  使用指定的密文初始化 <see cref="BasisCollectionModel{T}"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		protected BasisCollectionModel (CQApi api, byte[] ciphertext)
			: base (api, ciphertext)
		{
			this._list = new List<T> ();
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (BasisCollectionModel<T> obj)
		{
			if (obj is null)
			{
				return false;
			}

			return this._list.SequenceEqual (obj._list);
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as BasisCollectionModel<T>);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this._list.GetHashCode ();
		}
		/// <summary>
		/// 返回一个循环访问集合的枚举器
		/// </summary>
		/// <returns>用于循环访问集合的枚举数</returns>
		public IEnumerator<T> GetEnumerator ()
		{
			return this._list.GetEnumerator ();
		}
		/// <summary>
		/// 返回一个循环访问集合的枚举器
		/// </summary>
		/// <returns>用于循环访问集合的枚举数</returns>
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return ((IEnumerable<BasisCollectionModel<T>>)this).GetEnumerator ();
		}
		#endregion

		#region --运算符--
		/// <summary>
		/// 确定两个指定的 <see cref="BasisCollectionModel{T}"/> 实例是否具有相同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值相同，或两者均为 <see langword="null"/>，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator == (BasisCollectionModel<T> a, BasisCollectionModel<T> b)
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
		/// 确定两个指定的 <see cref="BasisCollectionModel{T}"/> 实例是否具有不同的值
		/// </summary>
		/// <param name="a">要比较的第一个对象</param>
		/// <param name="b">要比较的第二个对象</param>
		/// <returns>如果是 a 与 b 的值不同，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public static bool operator != (BasisCollectionModel<T> a, BasisCollectionModel<T> b)
		{
			return !(a == b);
		}
		#endregion
	}
}
