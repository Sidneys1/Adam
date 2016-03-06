using System.Collections.Generic;
using System.Globalization;
using Adam.Model.Enums;
using Adam.Model.Interface;
using Adam.Model.Metadata;
using Adam.Model.Wrappers;

namespace Adam.Model.Modules {
	public class Casing : IModule{
		public string Name => "Casing";
		public string Description => "Adjusts the casing of the file.";
		public bool Removable => true;

		#region Options
		[OptionDescriptor(null, "Casing", "The Casing style to use.")]
		public CasingType CasingType { get; set; }

		#endregion

		public bool Process(List<FileWrapper> files) {
			foreach (var file in files) {
				var s = file.OutputFilename;

				switch (CasingType) {
					case CasingType.Uppercase:
						s = s.ToUpper();
						break;
					case CasingType.Lowercase:
						s = s.ToLower();
						break;
					case CasingType.Titlecase:
						s = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
						break;
				}
				file.OutputFilename = s;
			}
			return true;
		}
	}
}
