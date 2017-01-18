using System;

namespace Adam.Model.Metadata {
    [AttributeUsage(AttributeTargets.Property)]
    class OptionDescriptorAttribute : Attribute {
        public readonly string Category, Name, IsEnabledPath, Description;

        //public readonly bool FixedSize, Wide;

        public OptionDescriptorAttribute(string category, string name, string desc = null, string isEnabledPath = null) {
            Category = category;
            Name = name;
            IsEnabledPath = isEnabledPath;
            Description = desc;
        }
    }
}