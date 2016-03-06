using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace barcoder
{

	public static class CharTable128
	{

		private static List<CharEntry> list = new List<CharEntry>();

		private static void add(int num, string binary, string c)
		{
			list.Add(new CharEntry(){ num = num, bits = binary, Char = c });
		}

		static CharTable128()
		{
			add(0, "11011001100", " ");
			add(1, "11001101100", "!");
			add(2, "11001100110", "\"");
			add(3, "10010011000", "#");
			add(4, "10010001100", "$");
			add(5, "10001001100", "%");
			add(6, "10011001000", "&");
			add(7, "10011000100", "'");
			add(8, "10001100100", "(");
			add(9, "11001001000", ")");
			add(10, "11001000100", "*");
			add(11, "11000100100", "+");
			add(12, "10110011100", "0");
			add(13, "10011011100", "-");
			add(14, "10011001110", ".");
			add(15, "10111001100", "/");
			add(16, "10011101100", "0");
			add(17, "10011100110", "1");
			add(18, "11001110010", "2");
			add(19, "11001011100", "3");
			add(20, "11001001110", "4");
			add(21, "11011100100", "5");
			add(22, "11001110100", "6");
			add(23, "11101101110", "7");
			add(24, "11101001100", "8");
			add(25, "11100101100", "9");
			add(26, "11100100110", ":");
			add(27, "11101100100", ";");
			add(28, "11100110100", "<");
			add(29, "11100110010", "=");
			add(30, "11011011000", ">");
			add(31, "11011000110", "?");
			add(32, "11000110110", "@");
			add(33, "10100011000", "A");
			add(34, "10001011000", "B");
			add(35, "10001000110", "C");
			add(36, "10110001000", "D");
			add(37, "10001101000", "E");
			add(38, "10001100010", "F");
			add(39, "11010001000", "G");
			add(40, "11000101000", "H");
			add(41, "11000100010", "I");
			add(42, "10110111000", "J");
			add(43, "10110001110", "K");
			add(44, "10001101110", "L");
			add(45, "10111011000", "M");
			add(46, "10111000110", "N");
			add(47, "10001110110", "O");
			add(48, "11101110110", "P");
			add(49, "11010001110", "Q");
			add(50, "11000101110", "R");
			add(51, "11011101000", "S");
			add(52, "11011100010", "T");
			add(53, "11011101110", "U");
			add(54, "11101011000", "V");
			add(55, "11101000110", "W");
			add(56, "11100010110", "X");
			add(57, "11101101000", "Y");
			add(58, "11101100010", "Z");
			add(59, "11100011010", "[");
			add(60, "11101111010", "\\");
			add(61, "11001000010", "]");
			add(62, "11110001010", "^");
			add(63, "10100110000", "_");
			add(64, "10100001100", "`");
			add(65, "10010110000", "a");
			add(66, "10010000110", "b");
			add(67, "10000101100", "c");
			add(68, "10000100110", "d");
			add(69, "10110010000", "e");
			add(70, "10110000100", "f");
			add(71, "10011010000", "g");
			add(72, "10011000010", "h");
			add(73, "10000110100", "i");
			add(74, "10000110010", "j");
			add(75, "11000010010", "k");
			add(76, "11001010000", "l");
			add(77, "11110111010", "m");
			add(78, "11000010100", "n");
			add(79, "10001111010", "o");
			add(80, "10100111100", "p");
			add(81, "10010111100", "q");
			add(82, "10010011110", "r");
			add(83, "10111100100", "s");
			add(84, "10011110100", "t");
			add(85, "10011110010", "u");
			add(86, "11110100100", "v");
			add(87, "11110010100", "w");
			add(88, "11110010010", "x");
			add(89, "11011011110", "y");
			add(90, "11011110110", "z");
			add(91, "11110110110", "{");
			add(92, "10101111000", "|");
			add(93, "10100011110", "}");
			add(94, "10001011110", "~");
			add(95, "10111101000", "DEL");
			add(96, "10111100010", "FNC3");
			add(97, "11110101000", "FNC2");
			add(98, "11110100010", "ShiftA");
			add(99, "10111011110", "CodeC");
			add(100, "10111101110", "FNC4");
			add(101, "11101011110", "CodeA");
			add(102, "11110101110", "FNC1");
			add(103, "11010000100", "StartCodeA");
			add(104, "11010010000", "StartCodeB");
			add(105, "11010011100", "StartCodeC");
			add(106, "1100011101011", "Stop");
			add(-1, "11010111000", "ReverseStop");
		}

		public static CharEntry getEntry(string Char)
		{
			return list.First(itm => itm.Char == Char);
		}

		public static CharEntry getEntry(int num)
		{
			return list.First(itm => itm.num == num);
		}

	}

	public class CharEntry
	{
		public string Char;
		public int num;
		public string bits;
	}

	public class HoneyWellCommandBarcode : Barcode128
	{

		public HoneyWellCommandBarcode(string input)
			: base(input)
		{
		}

		public override void setInput(string input)
		{
			base.setInput("~" + input + "{FNC3}");
		}

	}

	public class Barcode128
	{

		public Barcode128(string input)
		{
			setInput(input);
			this.label = input;
		}

		public Barcode128(string input, string label)
		{
			setInput(input);
			this.label = label;
		}

		public string label;

		public List<CharEntry> inputChars = new List<CharEntry>();
		public List<CharEntry> outputChars = new List<CharEntry>();

		public void calculateOutputChars()
		{
			outputChars.Clear();
			outputChars.Add(CharTable128.getEntry("StartCodeB"));
			outputChars.AddRange(inputChars);
			outputChars.Add(calcCheckChar());
			outputChars.Add(CharTable128.getEntry("Stop"));
		}

		private CharEntry calcCheckChar()
		{
			var sum = outputChars[0].num;
			for (var i = 1; i < outputChars.Count; i++) {
				sum += outputChars[i].num * i;
			}
			var checksum = sum % 103;
			return CharTable128.getEntry(checksum);
		}

		private Regex reg = new Regex("(\\{.*?\\})|(.)");

		public virtual void setInput(string input)
		{
			inputChars.Clear();
			foreach (Match match in reg.Matches(input)) {
				var m = match.Value;
				if (m.StartsWith("{") && m.EndsWith("}")) {
					m = m.Substring(1, m.Length - 2);
				}
				inputChars.Add(CharTable128.getEntry(m));
			}

			calculateOutputChars();
		}

		private string svgTemplate = @"<?xml version=""1.0"" standalone=""no""?>
<!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN""
   ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">
<svg width=""{width}"" height=""63"" version=""1.1""
   xmlns=""http://www.w3.org/2000/svg"">
   <desc>{desc}</desc>

   <g id=""barcode"" fill=""#000000"">
			{bars}
      <text x=""{widthHalf}.00"" y=""59.00"" text-anchor=""middle""
         font-family=""Helvetica"" font-size=""8.0"" fill=""#000000"" >
         {text}
      </text>
   </g>
</svg>
";

		private string bgPattern = @"<rect x=""0"" y=""0"" width=""178"" height=""59"" fill=""#FFFFFF"" />";
		private string barPattern = @"<rect x=""{x}.00"" y=""0.00"" width=""{w}.00"" height=""{h}.00"" />";

		public string generateSvg()
		{
			var bits = "";
			foreach (var entry in outputChars)
				bits += entry.bits;

			var barLines = new List<string>();

			var tpl = svgTemplate;

			var pos = 0;
			while (true) {
				if (pos >= bits.Length)
					break;

				var currBit = bits[pos].ToString();
				var hPos = pos;
				var bitLength = countSameBits(bits, ref pos);
				if (bitLength == 0)
					break;
				if (currBit == "1") {
					var bar = barPattern.Replace("{x}", (hPos + 10).ToString()).Replace("{w}", bitLength.ToString()).Replace("{h}", "50");
					barLines.Add(bar);
				} else {
				}
			}

			tpl = tpl.Replace("{bars}", string.Join("\n", barLines));
			tpl = tpl.Replace("{desc}", label);
			tpl = tpl.Replace("{text}", label);
			tpl = tpl.Replace("{width}", (bits.Length + 10 * 2).ToString());
			tpl = tpl.Replace("{widthHalf}", ((bits.Length + 10) / 2).ToString());

			return tpl;
		}

		public int countSameBits(string bits, ref int pos)
		{
			if (pos >= bits.Length)
				return 0;
			
			var oldPos = pos;
			var startBit = bits[pos];
			while (true) {
				pos++;

				if (pos >= bits.Length)
					break;
				
				if (bits[pos] != startBit)
					break;
			}
			return pos - oldPos;	
		}

	}



}

