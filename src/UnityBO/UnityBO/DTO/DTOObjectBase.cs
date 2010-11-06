using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UnityBO.DTO
{
    [DataContract]
    public abstract class DTOObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}