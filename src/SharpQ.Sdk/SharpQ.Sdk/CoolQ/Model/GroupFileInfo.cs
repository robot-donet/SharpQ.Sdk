using SharpQ.Sdk.Utility;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Model
{
	/// <summary>
	/// 表示 CoolQ 应用程序的 群文件信息 的模型类, 该类不能被继承
	/// </summary>
	public class GroupFileInfo : BasisStreamModel, IEquatable<GroupFileInfo>
	{
		#region --属性--
		/// <summary>
		/// 获取当前实例的文件ID
		/// </summary>
		public string FileId { get; private set; }
		/// <summary>
		/// 获取当前实例的文件名
		/// </summary>
		public string FileName { get; private set; }
		/// <summary>
		/// 获取当前实例的文件大小
		/// </summary>
		public long FileSize { get; private set; }
		/// <summary>
		/// 获取当实例的 BusID
		/// </summary>
		public long BusId { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		///  使用指定的密文初始化 <see cref="QQ"/> 类的新实例, 并持有用于扩展方法的 <see cref="CQApi"/> 实例
		/// </summary>
		/// <param name="api">绑定于当前实例的 <see cref="CQApi"/> 对象</param>
		/// <param name="ciphertext">预解密的密文</param>
		/// <exception cref="ArgumentNullException">api 或 ciphertext 为 null</exception>
		public GroupFileInfo (CQApi api, byte[] ciphertext)
			: base (api, ciphertext)
		{
		}
		#endregion

		#region --公开方法--
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public bool Equals (GroupFileInfo obj)
		{
			if (obj is null)
			{
				return false;
			}

			return string.Compare (this.FileId, obj.FileId) == 0
				&& string.Compare (this.FileName, obj.FileName) == 0
				&& this.FileSize == obj.FileSize
				&& this.BusId == obj.BusId;
		}
		/// <summary>
		/// 指示当前对象是否等于同一类型的另一个对象
		/// </summary>
		/// <param name="obj">一个与此对象进行比较的对象</param>
		/// <returns>如果当前对象等于 obj 参数，则为 <see langword="true"/>；否则为 <see langword="false"/></returns>
		public override bool Equals (object obj)
		{
			return this.Equals (obj as GroupFileInfo);
		}
		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns>32 位有符号整数哈希代码</returns>
		public override int GetHashCode ()
		{
			return this.FileId.GetHashCode () & this.FileName.GetHashCode () & this.FileSize.GetHashCode () & this.BusId.GetHashCode ();
		}
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			return $"{{ID: {this.FileId}, 文件名: {this.FileName}, 大小: {this.FileSize}, BusID: {this.BusId}}}";
		}
		/// <summary>
		/// 获取当前实例的消息字符串
		/// </summary>
		/// <returns>当前实例的消息字符串</returns>
		public override string GetMessage ()
		{
			throw new NotImplementedException ();
		}
		#endregion

		#region --私有方法--
		/// <summary>
		/// 对当前实例的密文进行初始化
		/// </summary>
		/// <param name="reader">用于解析模型数据的 <see cref="BinaryReader"/></param>
		protected override void Initialize (BinaryReader reader)
		{
			if (reader.Length () < 20)
			{
				throw new InvalidDataException ("数据长度小于 20");
			}

			this.FileId = reader.ReadString_Ex (Global.DefaultEncoding);
			this.FileName = reader.ReadString_Ex (Global.DefaultEncoding);
			this.FileSize = reader.ReadInt64_Ex ();
			this.BusId = reader.ReadInt64_Ex ();
		}
		#endregion
	}
}
