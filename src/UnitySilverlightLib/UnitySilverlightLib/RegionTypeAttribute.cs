using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace UnitySilverlightLib
{
    [MetadataAttributeAttribute]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RegionTypeAttribute :ExportAttribute
    {
        public RegionTypeAttribute():base(typeof(UIElement))
        {
            
        }

        public ViewType TargetView{get; set;}
    }
}
