using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace UnitySilverlightLib
{
    [MetadataAttributeAttribute]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class ViewTypeAttribute : ExportAttribute
    {
        public ViewTypeAttribute()
            : base(typeof(UserControl))
        {

        }

        public ViewType ViewTypeIs { get; set; }

        public string Name { get; set; }
    }
}