using System;
using System.Collections.Generic;
using Adam.Model.Interface;
using Adam.Model.Wrappers;

namespace Adam.Model.Modules {
    public class Regex : IModule {
        public string Name => "Regex";
        public string Description => "Replaces text using a Regex Search";
        public bool Removable => true;

        #region Properties

        public string RegexStr { get; set; }

        #endregion

        public bool Process(List<FileWrapper> files) {
            throw new NotImplementedException();
        }
    }
}