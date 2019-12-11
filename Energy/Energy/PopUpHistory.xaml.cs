using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpHistory
    {
        public PopUpHistory()
        {
            InitializeComponent();

            GetAudits();

        }
           private async void GetAudits()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://192.168.1.117:4545/audits");

            var audits = JsonConvert.DeserializeObject<List<Audits>>(response);
            AuditsListView.ItemsSource = audits;

        }
        void Navigate(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}