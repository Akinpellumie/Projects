using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuditPage : ContentPage
    {
        public AuditPage()
        {
            InitializeComponent();
        }

        private void ShowPopup(object o, EventArgs e)
        {
           PopupNavigation.Instance.PushAsync(new PopupView());
        }
        private void ShowHistoryPopUp(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpHistory());
        }
    }
}