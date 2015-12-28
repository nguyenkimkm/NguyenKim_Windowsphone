using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Information : Page
    {
        
        public Information()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int chiso = (int)e.Parameter;
            tbName.Text = MainPage.dsdd[chiso].name;
            string diachi = MainPage.dsdd[chiso].location.address + "\n";
            string khoangcach = MainPage.dsdd[chiso].location.distance.ToString() + " m\n";
            string tp = MainPage.dsdd[chiso].location.city + "\n";
            string qg = MainPage.dsdd[chiso].location.country + "\n";
            tbND.Text = "\nAddress:\n" + diachi + "\nDistance:\n" + khoangcach + "\nCity:\n" + tp + "\nCountry:\n" + qg;
           
            List<Category> listcate = MainPage.dsdd[chiso].categories;
            
            if (listcate != null && listcate.Count > 0)
            {
                string avatar = listcate[0].icon.prefix + listcate[0].icon.suffix;
                imgAvatar.Source = new BitmapImage(new Uri(avatar));
            } 
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("http://www.gravatar.com/avatar/6810d91caff032b202c50701dd3af745?d=identicon&r=PG");
                imgAvatar.Source = bitmapImage;
            }
            
        }
    }
}
