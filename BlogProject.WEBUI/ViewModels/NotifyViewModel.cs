using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.WEBUI.ViewModels
{
    public class NotifyViewModel<T>
    {
       public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool IsRedirecting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }


        public NotifyViewModel()
        {
            Header = "Yönlendiriliyorsunuz!";
            Title = "Geçersiz İşlem";
            IsRedirecting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 7000;
            Items = new List<T>();
        }
    }
}