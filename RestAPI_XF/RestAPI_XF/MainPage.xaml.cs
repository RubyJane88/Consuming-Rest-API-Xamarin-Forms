using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
	        _orders  = new ObservableCollection<JobOrder>(orders);
	        JobListView.ItemsSource = _orders; 
            
	        base.OnAppearing();
	    }

	    private void OnAdd(object sender, EventArgs e)
	    {
	       
	    }

	    private void OnUpdate(object sender, EventArgs e)
	    {
	        
	    }

	    private void OnDelete(object sender, EventArgs e)
	    {
	       
	    }
	}
}
