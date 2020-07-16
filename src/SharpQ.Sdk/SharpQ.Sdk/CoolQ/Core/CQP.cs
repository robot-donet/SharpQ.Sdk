using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpQ.Sdk.CoolQ.Core
{
	internal static class CQP
	{
		#region --常量--
		private const string LibraryName = "CQP.dll";
		#endregion

		#region --外部函数--
#pragma warning disable IDE1006
		[DllImport (LibraryName, EntryPoint = nameof (CQ_sendPrivateMsg), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_sendPrivateMsg (Int32 authCode, Int64 qq, IntPtr msg);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_sendGroupMsg), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_sendGroupMsg (Int32 authCode, Int64 group, IntPtr msg);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_sendDiscussMsg), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_sendDiscussMsg (Int32 authCode, Int64 discuss, IntPtr msg);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_deleteMsg), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_deleteMsg (Int32 authCode, Int64 msgId);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_sendLikeV2), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_sendLikeV2 (Int32 authCode, Int64 qq, Int32 count);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getCookiesV2), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getCookiesV2 (Int32 authCode, IntPtr domain);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getRecordV2), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getRecordV2 (Int32 authCode, IntPtr file, IntPtr outFormat);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getImage), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getImage (Int32 authCode, IntPtr file);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_canSendImage), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_canSendImage (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_canSendRecord), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_canSendRecord (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getCsrfToken), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_getCsrfToken (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getAppDirectory), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getAppDirectory (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getLoginQQ), CallingConvention = CallingConvention.StdCall)]
		public static extern Int64 CQ_getLoginQQ (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getLoginNick), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getLoginNick (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupKick), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupKick (Int32 authCode, Int64 group, Int64 qq, Boolean addBlacklist);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupBan), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupBan (Int32 authCode, Int64 group, Int64 qq, Int64 time);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupAdmin), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupAdmin (Int32 authCode, Int64 group, Int64 qq, Boolean setAdmin);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupSpecialTitle), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupSpecialTitle (Int32 authCode, Int64 group, Int64 qq, IntPtr specialTitle, Int64 expiredTime);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupWholeBan), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupWholeBan (Int32 authCode, Int64 group, Boolean openBan);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupAnonymousBan), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupAnonymousBan (Int32 authCode, Int64 group, IntPtr anonymous, Int64 banTime);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupAnonymous), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupAnonymous (Int32 authCode, Int64 group, Boolean openAnonymous);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupCard), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupCard (Int32 authCode, Int64 group, Int64 qq, IntPtr newCard);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupLeave), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupLeave (Int32 authCode, Int64 group, Boolean isDisband);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setDiscussLeave), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setDiscussLeave (Int32 authCode, Int64 discuss);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setFriendAddRequest), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setFriendAddRequest (Int32 authCode, IntPtr responseFlag, Int32 responseType, IntPtr notes);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setGroupAddRequestV2), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setGroupAddRequestV2 (Int32 authCode, IntPtr responseFlag, Int32 requestType, Int32 responseType, IntPtr reason);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_addLog), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_addLog (Int32 authCode, Int32 level, IntPtr type, IntPtr content);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_setFatal), CallingConvention = CallingConvention.StdCall)]
		public static extern Int32 CQ_setFatal (Int32 authCode, IntPtr errorMsg);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getGroupMemberInfoV2), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getGroupMemberInfoV2 (Int32 authCode, Int64 group, Int64 qq, Boolean noUseCache);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getGroupMemberList), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getGroupMemberList (Int32 authCode, Int64 group);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getGroupList), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getGroupList (Int32 authCode);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getFriendList), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getFriendList (Int32 authCode, Boolean reserved = false);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getStrangerInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getStrangerInfo (Int32 authCode, Int64 qq, Boolean noUseCache);

		[DllImport (LibraryName, EntryPoint = nameof (CQ_getGroupInfo), CallingConvention = CallingConvention.StdCall)]
		public static extern IntPtr CQ_getGroupInfo (Int32 authCode, Int64 group, Boolean noUseCache);
#pragma warning restore IDE1006
		#endregion
	}
}
