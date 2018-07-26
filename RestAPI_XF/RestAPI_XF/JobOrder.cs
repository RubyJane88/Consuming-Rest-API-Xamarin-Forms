using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestAPI_XF
{
    public class JobOrder : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _serviceOrder;

        [JsonProperty("ServiceOrder")]
        public string ServiceOrder
        {
            get => _serviceOrder;
            set => _serviceOrder = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}