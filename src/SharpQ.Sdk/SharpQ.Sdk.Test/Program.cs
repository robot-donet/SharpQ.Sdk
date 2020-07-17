using SharpQ.Sdk.CoolQ;
using SharpQ.Sdk.CoolQ.Model.CQCodes;

using System;

namespace SharpQ.Sdk.Test
{
	class Program
	{
		static void Main ()
		{

			CQCodeMusic code = new CQCodeMusic ("[CQ:music,id=10,type=qq,style=1]");
			var a = code.Source;
			Console.ReadKey ();
		}
	}
}
