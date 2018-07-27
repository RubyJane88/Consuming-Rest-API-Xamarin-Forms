using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestAPI_XF.Annotations;

namespace RestAPI_XF
{
    public class JobOrder : INotifyPropertyChanged
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        private string _serviceOrder;

        [JsonProperty("serviceOrder")]
        public string ServiceOrder
        {
            get => _serviceOrder;
            set
            {
                _serviceOrder = value; 
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}