using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace RestAPI_XF
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://10.0.2.2:3000/joborders/"; //for Android emulators
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<JobOrder> _orders;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            List<JobOrder> orders = JsonConvert.DeserializeObject<List<JobOrder>>(content);
            _orders = new ObservableCollection<JobOrder>(orders);
            JobListView.ItemsSource = _orders;

            base.OnAppearing();
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            JobOrder jobOrder = new JobOrder { ServiceOrder = $"Timestamp {DateTime.UtcNow.Ticks}" };
            string content = JsonConvert.SerializeObject(jobOrder);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            _orders.Insert(0, jobOrder);
        }

        public async void OnUpdate(object sender, EventArgs e)
        {
            JobOrder jobOrder = _orders[0];
            jobOrder.ServiceOrder += "[updated]";
            string content = JsonConvert.SerializeObject(jobOrder);
            await _client.PutAsync(Url + jobOrder.Id, new StringContent(content, Encoding.UTF8, "application/json"));
            
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            JobOrder jobOrder = _orders[0];
            await _client.DeleteAsync(Url + jobOrder.Id);
            _orders.Remove(jobOrder);
        }
    }
}