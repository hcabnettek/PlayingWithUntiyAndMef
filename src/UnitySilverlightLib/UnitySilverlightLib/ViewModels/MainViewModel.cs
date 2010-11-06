using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using UnitySilverlightLib.Interfaces;


namespace UnitySilverlightLib.ViewModels
{
    [Export]
    public class MainViewModel: INotifyPropertyChanged, IPartImportsSatisfiedNotification 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged(string prop)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ObservableCollection<string> ShapePreferences{get; set;}

       

        public MainViewModel()
        {
            ShapePreferences = new ObservableCollection<string>();
        }


        private string _currentPreference;

        public string CurrentPreference
        {
            get { return _currentPreference; }
            set
            {
                _currentPreference = value;
                RaisedPropertyChanged("CurrentPreference");
                if(!string.IsNullOrEmpty(value))
                {
                    _SelectViews(value);
                }
            }
        }

        [ImportMany(AllowRecomposition = true)]
        public Lazy<UIElement, IRegionTypeCapabilities>[] Regions { get; set; }


        [ImportMany(AllowRecomposition = true)]
        public Lazy<UserControl, IViewTypeCapabilities>[] Views { get; set; }

        
        private void _SelectViews(string viewName)
        {
            foreach(var view in Views)
            {
                if (view.Metadata.ViewTypeIs.Equals(ViewType.Shape))
                {
                    view.Value.Visibility = view.Metadata.Name.Equals(viewName)
                        ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
        
        
        public void OnImportsSatisfied()
        {
            ContentControl prefsRegion = null;
            ItemsControl shapesRegion = null;

            foreach (var region in Regions)
            {
                if(region.Value is ItemsControl)
                {
                    ((ItemsControl) region.Value).Items.Clear();
                }

                if(region.Metadata.TargetView.Equals(ViewType.Preferences))
                {
                    prefsRegion = (ContentControl) region.Value;
                }

                else
                {
                    shapesRegion = (ItemsControl) region.Value;
                }
            }

            ShapePreferences.Clear();

            foreach(var view in Views)
            {
                if(view.Metadata.ViewTypeIs.Equals(ViewType.Preferences))
                {
                    if (prefsRegion != null)
                    {
                        prefsRegion.Content = view.Value;

                    }
                }
                else
                {
                    if(shapesRegion != null)
                    {
                        ShapePreferences.Add(view.Metadata.Name);
                        view.Value.Visibility = Visibility.Collapsed;
                        shapesRegion.Items.Add(view.Value);
                    }
                }
            }
        }
    }
}