using System;
using System.Text.RegularExpressions;

namespace RealDebridFilterLinks
{
	public class Program
	{

		// paste the html in htmlData between the quotation marks
		public static string htmlData = "";

		static void Main(string[] args)
		{
			Console.WriteLine("Hey from Bizzy!");


			htmlData = File.ReadAllText("real_fullhtml.txt");

			//Regex validateDateRegex = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
			var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);




			//string[] extracted = linkParser.Matches(data)
			//	 .Cast<Match>()
			//.Select(m => m.Value)
			//.ToArray();


			//Console.WriteLine(extracted.Length);
			;
			//foreach (var url in linkParser.Matches(data))
			//{
			//
			//	Console.WriteLine(url);
			//}

			string[] urlMatches = Regex.Matches(htmlData, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
				.Cast<Match>()
				.Select(m => m.Value)
				.ToArray();
			List<string> downloadUrls = new List<string>();
			foreach (var url in urlMatches)
			{
				if (url.Contains("download.real-debrid.com")){
					downloadUrls.Add(url);
					Console.WriteLine("Found dl : " + url);
				}
				else
				{
					Console.WriteLine("Ignoring : " + url);
				}
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Download urls : ");
			Console.WriteLine();
			foreach (var url in downloadUrls)
			{
				Console.WriteLine(url);
			}
			Console.WriteLine();
			Console.WriteLine("Found : " + downloadUrls.Count + " urls");

			Console.ReadKey();

			//Console.WriteLine(extracted.Length);

		}
	}
}
