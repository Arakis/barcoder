using System;
using barcoder;

namespace barcodercli
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var input = args[0];
			var bc = new Barcode128(input);
			var svg = bc.generateSvg();
			//System.IO.File.WriteAllText("/tmp/testsvg.svg", svg);
			Console.WriteLine(svg);
		}
	}
}
