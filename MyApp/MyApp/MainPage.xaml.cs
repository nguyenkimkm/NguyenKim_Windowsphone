using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        public static List<Venue> dsdd;
        public class DataShow
        {
            public string ten { get; set; }
            public string diachi { get; set; }
        }
        private async Task<Geoposition> getCoordinates()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                return await geolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5), timeout: TimeSpan.FromSeconds(10));
            }
            catch
            {
                return null;
            }

        }

        private async void getNearbyPlaces()
        {
            string fsClient = "C3ML2TDLI315P4WG2C0GSIHTLX3NTEG005P5UUAAKVODKB0R";
            string fsSecret = "LKACZPLHNPQ5TGN2HL1SIVAMU0Z2JGG0RMMDQV3NW3ARMTBE";
            Geoposition pos = await getCoordinates();
            //var posTest = new Windows.Devices.Geolocation.BasicGeoposition();
            //posTest.Latitude = 10.764102;
            //posTest.Longitude = 106.656254;
            try
            {
                string datapost = "?client_id=" + fsClient + "&client_secret=" + fsSecret + "&limit=50" + "&intent=browse" +"&radius=800"
                    + "&v=20151225&ll=" + pos.Coordinate.Latitude + "," + pos.Coordinate.Longitude;
                Uri address = new Uri("https://api.foursquare.com/v2/venues/search" + datapost);
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream streamResponse = response.GetResponseStream())
                        {
                            using (StreamReader streamRead = new StreamReader(streamResponse, Encoding.UTF8))
                            {
                                
                                RootObject nearbyVenues = JsonConvert.DeserializeObject<RootObject>(streamRead.ReadToEnd().ToString());
                                dsdd = nearbyVenues.response.venues;
                                for (int i = 0; i < dsdd.Count; i++)
                                {
                                    var item = new DataShow();
                                    item.ten = dsdd[i].name;
                                    item.diachi = dsdd[i].location.address;
                                    list.Items.Add(item);
                                }
                                
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageDialog dialog = new MessageDialog(" Loi xay ra ", "Error");
                dialog.ShowAsync();
            }
        }
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            getNearbyPlaces();
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Information),list.SelectedIndex);
        }

      
    }
}
