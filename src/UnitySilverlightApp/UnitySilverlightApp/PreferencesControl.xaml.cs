using System.ComponentModel.Composition;
using System.Windows.Controls;
using UnitySilverlightApp.ProductService;
using UnitySilverlightLib;
using UnitySilverlightLib.ViewModels;

namespace UnitySilverlightApp
{
    [ViewType(Name="PreferencesSection", ViewTypeIs = ViewType.Preferences)]
    public partial class PreferencesControl
    {
        [Import]
        public MainViewModel ViewModel
        {
            get { return LayoutRoot.DataContext as MainViewModel; }
            set { LayoutRoot.DataContext = value;}
        }

        public PreferencesControl()
        {
            InitializeComponent();
        }
    }
}
