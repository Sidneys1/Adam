using System.Collections.ObjectModel;
using Adam.Model.Interface;

namespace Adam.Model {
	public static class AdamCore {
		static ObservableCollection<IModule> Modules { get; } = new ObservableCollection<IModule>();
	}
}
