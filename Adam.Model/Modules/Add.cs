using System.Collections.Generic;
using System.Text;
using Adam.Model.Interface;
using Adam.Model.Metadata;
using Adam.Model.Wrappers;

namespace Adam.Model.Modules {
    public class Add : IModule {
        #region Public Properties

        public string Description => "Adds fixed text to the filename.";

        public string Name => "Add";

        public bool Removable => true;

        #region Options

        [OptionDescriptor(null, "Prefix", "Add text at the start of the filename.")]
        public string Prefix { get; set; }

        [OptionDescriptor("Insert", "Text", "The text to insert at the specified location.")]
        public string Insert { get; set; }

        [OptionDescriptor("Insert", "Position", "The position to insert text at.")]
        public int InsertionPosition { get; set; }

        [OptionDescriptor(null, "Suffix", "Add text at the start of the filename.")]
        public string Suffix { get; set; }

        #endregion

        #endregion Public Properties

        #region Public Methods

        public bool Process(List<FileWrapper> files) {
            foreach (var fileWrapper in files)
                fileWrapper.OutputFilename =
                    new StringBuilder(fileWrapper.OutputFilename)
                        .Insert(InsertionPosition, Insert)
                        .Insert(0, Prefix)
                        .Append(Suffix)
                        .ToString();

            return true;
        }

        #endregion Public Methods
    }
}