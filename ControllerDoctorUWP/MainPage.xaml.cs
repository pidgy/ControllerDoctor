using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ControllerDoctorUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationViewItem _lastItem;

        public MainPage()
        {
            this.InitializeComponent();

            GlobalSettings.ApplyDefaults();
            GlobalSettings.ApplyThemeTo(this);
            
            Press.DirectionBrushes = new List<Brush>();
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.PRESSED), new SolidColorBrush(Colors.LawnGreen));
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.UP), new SolidColorBrush(Colors.Red));
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.DOWN), new SolidColorBrush(Colors.Yellow));
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.LEFT), new SolidColorBrush(Colors.DodgerBlue));
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.RIGHT), new SolidColorBrush(Colors.White));
            Press.DirectionBrushes.Insert((int)Math.Sqrt((int)Press.DIRECTION.NONE), new SolidColorBrush(Colors.LawnGreen));

            Press.DirectionHit = new List<double>();
            Press.DirectionHit = new List<double>();

            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.PRESSED), 0.1);
            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.UP), 0.1);
            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.DOWN), 0.1);
            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.LEFT), 0.1);
            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.RIGHT), 0.1);
            Press.DirectionHit.Insert((int)Math.Sqrt((int)Press.DIRECTION.NONE), 0.1);

            NavView.ItemInvoked += NavigationView_OnItemInvoked;

            NavView.SelectionChanged += (s, e) =>
            {
                if (_lastItem == null)
                {
                    return;
                }
            };
            
            NavView.Loaded += (s, e) =>
            {
                var settings = (NavigationViewItem)NavView.SettingsItem;
                settings.IsTabStop = false;
                NavView.PaneClosing += (ss, ee) =>
                {
                    NavView.IsPaneOpen = true;
                };
            };

            ContentFrame.Navigate(typeof(HomePage));
            Home_Navigation.IsSelected = true;
        }

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (!(args.InvokedItemContainer is NavigationViewItem item))
            {
                ContentFrame.Navigate(typeof(HomePage));
                return;
            }

            if (item == _lastItem)
            {
                return;
            }

            bool canNavigate = false;

            if (item.Name == "Home_Navigation")
            {
                canNavigate = ContentFrame.Navigate(typeof(HomePage));
            }
            else if (item.Name == "About_Navigation")
            {
                canNavigate = ContentFrame.Navigate(typeof(AboutPage));
            }
            else if (item.Name == "Xbox_Controller_Health")
            {
                canNavigate = ContentFrame.Navigate(typeof(XboxControllerPage));
            }
            else if (item.Name == "Playstation_Controller_Health")
            {
                canNavigate = ContentFrame.Navigate(typeof(PlaystationControllerPage));
            }
            else if (item.Name == "Other_Controller_Health")
            {
                canNavigate = ContentFrame.Navigate(typeof(OtherControllerPage));
            }
            else if (item.Name == "All_Controller_Deadzone")
            {
                canNavigate = ContentFrame.Navigate(typeof(ControllerDeadzonePage));
            }
            else if (item.Name == "All_Controller_Vibration")
            {
                canNavigate = ContentFrame.Navigate(typeof(ControllerVibrationPage));
            }
            else if (item.Name == "All_Controller_Triggers")
            {
                canNavigate = ContentFrame.Navigate(typeof(ControllerTriggerPage));
            }
            else if (item.Name == "All_Controller_Battery")
            {
                canNavigate = ContentFrame.Navigate(typeof(ControllerBatteryPage));
            }
            else if (item.Name.Contains("History"))
            {
                canNavigate = ContentFrame.Navigate(typeof(HistoryPage), item.Name.Replace('_', ' '));
            }
            else if (item == NavView.SettingsItem)
            {
                Debug.WriteLine("----> "+ item.Name);
                canNavigate = ContentFrame.Navigate(typeof(SettingsPage));
            }

            if (!canNavigate)
            {
                string error = "Unknown Page";
                if (item != null)
                {
                    error = item.Name.Replace('_', ' ');
                }

                AlertAndWaitAsync("There is currently no support for this device.", error);
            }

            _lastItem = item;
        }

        public void AlertAndWaitAsync(string msg, string title)
        {
            MessageDialog messageDialog = new MessageDialog(msg, title);
            _ = messageDialog.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.Frame.BackStack.Count > 0)
            {
                this.Frame.BackStack.RemoveAt(this.Frame.BackStack.Count - 1);
            }
        }
    }
}
