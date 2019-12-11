using Energy.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView 
    {
        public PopupView()
        {
            InitializeComponent();
        }
        private async void BtnSave_OnClicked(object sender, EventArgs e)
        {

            Audits audits = new Audits()
            {
                title = EntTitle.Text,
                device = EntDevice.Text,
                rating = Convert.ToInt32(EntRating.Text),
                quantity = Convert.ToInt32(EntQuantity.Text),
                operation = Convert.ToInt32(EntOperation.Text)
            };
            var json = JsonConvert.SerializeObject(audits);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://192.168.1.117:4545/audits", content);

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Yoo!!!", "Device Added!", "Close");
            }
            await Navigation.PushAsync(new AuditPage());
        }

        private Task DisplayAlert(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}