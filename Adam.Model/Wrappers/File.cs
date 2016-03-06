using System.Collections.Generic;
using System.IO;

namespace Adam.Model.Wrappers {
	public class FileWrapper {
		#region Private Fields

		private const string output_filename_meta_key = "OutputFilename";
		private const string output_path_meta_key = "OutputPath";
		private const string extension_meta_key = "Extension";

		#endregion Private Fields
		
		#region Public Properties

		public Dictionary<string, Stack<object>> Metas { get; } = new Dictionary<string, Stack<object>>();
		public string OriginalPath { get; private set; }

		public string OutputFilename {
			get { return (string)PeekMeta(output_filename_meta_key); }
			set { PushMeta(output_filename_meta_key, value); }
		}

		public string OutputPath {
			get { return (string)PeekMeta(output_path_meta_key); }
			set { PushMeta(output_path_meta_key, value); }
		}

		public string Extension {
			get { return (string)PeekMeta(extension_meta_key); }
			set { PushMeta(extension_meta_key, value); }
		}

		public FileInfo FileInfo { get; }

		#endregion Public Properties
		
		#region Public Ctor / Dtor

		public FileWrapper(string originalPath) {
			OriginalPath = originalPath;
			FileInfo = new FileInfo(originalPath);

			OutputFilename = FileInfo.Name.Remove(FileInfo.Name.Length - FileInfo.Extension.Length);
			OutputPath = FileInfo.DirectoryName;
		}

		#endregion Public Ctor / Dtor
		
		#region Private Methods

		private void PushMeta(string key, string value) {
			if (!Metas.ContainsKey(key))
				Metas[key] = new Stack<object>();
			Metas[key].Push(value);
		}

		private object PeekMeta(string key) => Metas.ContainsKey(key) ? Metas[key].Peek() : null;

		#endregion Private Methods
	}
}