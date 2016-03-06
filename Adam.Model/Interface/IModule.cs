using Adam.Model.Wrappers;
using System.Collections.Generic;

namespace Adam.Model.Interface {
	public interface IModule {
		string Name { get; }
		string Description { get; }
		bool Removable { get; }

		bool Process(List<FileWrapper> files);
	}
}
