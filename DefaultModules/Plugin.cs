using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adam.Model.Interface;

namespace DefaultModules {
	public class Plugin : IPlugin
	{
		public string Name => "";
		public string Version { get; }
		public string Author { get; }
		public IReadOnlyList<Type> Modules { get; }
	}
}
