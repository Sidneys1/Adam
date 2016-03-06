using System;
using System.Collections.Generic;

namespace Adam.Model.Interface {
	public interface IPlugin
	{
		string Name { get; }
		string Version { get; }
		string Author { get; }

		IReadOnlyList<Type> Modules { get; }
	}
}
