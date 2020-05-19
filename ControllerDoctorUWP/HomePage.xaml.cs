using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControllerDoctorUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        GenericController Controller;

        public HomePage()
        {
            this.InitializeComponent();

            GlobalSettings.ApplyThemeTo(this);

            HomePageSettingsGrid.BorderThickness = new Thickness(0);

            LoadController();
        }

        void LoadController()
        {
            Controller = new GenericController();

            Controller.Connected += (s2, e2) =>
            {
                Connected();
            };

            Controller.Disconnected += (s2, e2) =>
            {
                Disconnected();
            };

            Controller.Refresh();
        }

        public async void Connected()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                switch (Controller.Vendor())
                {
                    case (ushort)VENDOR_ID.PLAYSTATION:
                        GlobalSettings.ControllerType = CONTROLLER_TYPE.PLAYSTATION;
                        break;
                    case (ushort)VENDOR_ID.XBOX:
                        GlobalSettings.ControllerType = CONTROLLER_TYPE.XBOX;
                        break;
                    default:
                        GlobalSettings.ControllerType = CONTROLLER_TYPE.GENERIC;
                        break;
                }

                Default_Controller_TextBlock.Text = ControllerDoctorUWP.Controller.TypeString(Controller.Vendor());

                Controller_Connected_TextBlock.Text = "Yes";
                Controller_Vendor_TextBlock.Text = "" + Controller.Vendor();
                Controller_Product_TextBlock.Text = "" + Controller.Product();

                Windows.Devices.Power.BatteryReport report = Controller.Battery();
                if (report != null)
                {
                    Controller_Battery_TextBlock.Text = report.RemainingCapacityInMilliwattHours + "%";
                }
            });
        }

        public async void Disconnected()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                Default_Controller_TextBlock.Text = "n/a";

                Controller_Connected_TextBlock.Text = "No";
                Controller_Vendor_TextBlock.Text = "n/a";
                Controller_Product_TextBlock.Text = "n/a";
                Controller_Battery_TextBlock.Text = "n/a";

                LoadController();
            });
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.Refresh();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        void Log(string msg)
        {
            System.Diagnostics.Debug.WriteLine("[HomePage]: " + msg);
        }
    }
}
