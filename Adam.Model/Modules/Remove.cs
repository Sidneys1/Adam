using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Adam.Model.Interface;
using Adam.Model.Metadata;
using Adam.Model.Wrappers;

namespace Adam.Model.Modules {
    public class Remove : IModule {
        public string Name => "Remove";
        public string Description => "Removes specific text and characters.";
        public bool Removable => true;

        #region Settings

        [OptionDescriptor(null, "First #", "Remove a certain number of characters from the start of the filename.")]
        public int FirstNum { get; set; }

        [OptionDescriptor(null, "Last #", "Remove a certain number of characters from the end of the filename.")]
        public int LastNum { get; set; }

        [OptionDescriptor("Remove Region", "From", "The start index of the area to remove.")]
        public int From { get; set; }

        [OptionDescriptor("Remove Region", "To", "The end index of the area to remove.")]
        public int To { get; set; }

        [OptionDescriptor(null, "Remove Sequences", "Remove certain sequences from the filename.")]
        public ObservableCollection<string> RemoveSequences { get; } = new ObservableCollection<string>();

        [OptionDescriptor("Characters", "Numbers", "Remove Numbers (Inc. Roman Numerals Characters, Fractions, Etc.)")]
        public bool Numbers { get; set; } = false;

        [OptionDescriptor("Characters", "Trim", "Trims Whitespace from the beginning and end of the filename.")]
        public bool Trim { get; set; } = false;

        [OptionDescriptor("Characters", "Whitespace", "Remove Whitespace characters.")]
        public bool Whitespace { get; set; } = false;

        [OptionDescriptor("Characters", "Accents", "Remove Accent characters.")]
        public bool Accents { get; set; } = false;

        [OptionDescriptor("Characters", "Symbols", "Removes Symbol characters.")]
        public bool Symbols { get; set; } = false;

        [OptionDescriptor("Characters", "Punctuation", "Removes Punctuation characters.")]
        public bool Punctuation { get; set; } = false;

        [OptionDescriptor("Characters", "Uppercase", "Removes Uppercase characters.")]
        public bool Uppercase { get; set; } = false;

        [OptionDescriptor("Characters", "Lowercase", "Removes Lowercase characters.")]
        public bool Lowercase { get; set; } = false;

        #endregion

        public bool Process(List<FileWrapper> files) {
            foreach (var fileWrapper in files) {
                var s = fileWrapper.OutputFilename;
                if (From != To)
                    s = s.Substring(From, To - From);
                if (FirstNum != 0)
                    s = s.Remove(0, FirstNum);
                if (LastNum != 0)
                    s = s.Remove(s.Length - LastNum);

                foreach (var removeSequence in RemoveSequences) {
                    while (s.Contains(removeSequence))
                        s = s.Remove(s.IndexOf(removeSequence, StringComparison.Ordinal), removeSequence.Length);
                }

                if (Trim) s = s.Trim();

                for (var i = 0; i < s.Length;) {
                    var c = s[i];

                    if (Numbers && char.IsNumber(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }

                    if (Whitespace && char.IsWhiteSpace(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }

                    if (Symbols && char.IsSymbol(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }

                    if (Punctuation && char.IsPunctuation(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }
                    if (Uppercase && char.IsUpper(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }

                    if (Lowercase && char.IsLower(c)) {
                        s = s.Remove(i, 1);
                        continue;
                    }

                    i++;
                }

                fileWrapper.OutputFilename = s;
            }
            return true;
        }
    }
}