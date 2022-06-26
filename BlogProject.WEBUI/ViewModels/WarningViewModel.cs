using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.WEBUI.ViewModels
{
    public class WarningViewModel:NotifyViewModel<string>
    {
        public WarningViewModel()
        {
            Title = "Uyarı!";
        }
    }
}