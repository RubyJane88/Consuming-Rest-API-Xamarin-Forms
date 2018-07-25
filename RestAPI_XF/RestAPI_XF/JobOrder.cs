using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RestAPI_XF
{
    public class JobOrder
    {
        public int Id { get; set; }

        private string _serviceOrder;

       
        [JsonProperty("ServiceOrder")]
        public string ServiceOrder
        {
            get => _serviceOrder;
            set
            {
                _serviceOrder = value;
        
            }

        }

        
    }
}
