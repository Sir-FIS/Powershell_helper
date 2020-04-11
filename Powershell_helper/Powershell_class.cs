using System.Diagnostics;
using System.Runtime.InteropServices;

//HOW-TO
// "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\ildasm.exe"/out:helper.il Powershell_helper.dll
// edit the .il file and add ".export[1] to the top of the public method
// C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe helper.il /DLL /output=Helper.dll
// rundll32 Helper.dll,PSTest

namespace Powershell_Helper
{


	public class Program
	{
		//	[DllExport("Start", CallingConvention = CallingConvention.StdCall)] 
		public static void PSTest()
		{

			Process process = new Process();  //put a code in here
			string script = @"
				$var = 'foo'; 
				echo $var |Out-File foo.txt;
				";

			process.StartInfo.FileName = "powershell.exe";
			process.StartInfo.Arguments = " -c " + script + ";Start-Sleep -s 10";
			//process.StartInfo.Arguments = "-Noexit -c " + script + ";Start-Sleep -s 10"; //for debug

			//process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
		}
	}


}
