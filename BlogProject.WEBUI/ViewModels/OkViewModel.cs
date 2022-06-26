using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.WEBUI.ViewModels
{
    public class OkViewModel:NotifyViewModel<string>
    {
        public OkViewModel()
        {
            Title = "İşlem Başarılı";
        }
    }
}