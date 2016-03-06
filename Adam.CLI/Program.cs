using System;
using System.Collections.Generic;
using System.Globalization;
using Adam.Model.Modules;
using Adam.Model.Wrappers;

namespace Adam.CLI {
	class Program {
		static void Main() {
			var add = new Add {Prefix = "Pre_", Suffix = "_post", Insert = "_insert_", InsertionPosition = 6};

			var file = new FileWrapper("E:\\Downloads\\New folder (3)\\a1 b2 c3 + d4, e5 f6 g7.txt");
			Console.WriteLine(file.OutputFilename);
			add.Process(new List<FileWrapper> {file});
			Console.WriteLine(file.OutputFilename);

			
			Console.WriteLine(file.OutputFilename);

			Console.ReadLine();
		}
	}
}
