using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Models
{
    public class Events
    {
        public string Description { get; set; }        
        public string EndDateTime { get; set; }
        public string GroupId { get; set; }
        public string Id { get; set; }
        public string LocationId { get; set; }        
        public string StartDateTime { get; set; }
    }
}

