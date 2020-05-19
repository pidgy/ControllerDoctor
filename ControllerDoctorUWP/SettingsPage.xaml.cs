using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ControllerDoctorUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            GlobalSettings.ApplyThemeTo(this);

            this.Loaded += (s, e) =>
            {
                Defaults();
            };
        }

        async void Defaults()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Delay_Slider.Value = GlobalSettings.DelayMilliseconds;
                Brush_Slider.Value = GlobalSettings.StrokeThickness;

                Xbox_Radio_Button.IsChecked = GlobalSettings.ControllerType == CONTROLLER_TYPE.XBOX;
                Other_Radio_Button.IsChecked = GlobalSettings.ControllerType == CONTROLLER_TYPE.PLAYSTATION;
                Playstation_Radio_Button.IsChecked = GlobalSettings.ControllerType == CONTROLLER_TYPE.GENERIC;
                Auto_Radio_Button.IsChecked = GlobalSettings.ControllerType == CONTROLLER_TYPE.AUTO;

                switch (GlobalSettings.Theme)
                {
                    case GlobalSettings.LIGHT:
                        Light_Radio_Button.IsChecked = true;
                        Dark_Radio_Button.IsChecked = false;
                        break;
                    case GlobalSettings.DARK:
                        Dark_Radio_Button.IsChecked = true;
                        Light_Radio_Button.IsChecked = false;
                        break;
                }
            });
        }

        private void Brush_Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            GlobalSettings.StrokeThickness = (int)e.NewValue;
        }

        private void Delay_Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue >= 10)
            {
               GlobalSettings.DelayMilliseconds = (int)e.NewValue;
            }
            else
            {
                GlobalSettings.DelayMilliseconds = 10;
            }
        }

        private void Default_Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ApplyDefaults();
            Defaults();
        }

        private void Xbox_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ControllerType = CONTROLLER_TYPE.XBOX;
            Other_Radio_Button.IsChecked = false;
            Playstation_Radio_Button.IsChecked = false;
            Auto_Radio_Button.IsChecked = false;
        }

        private void Other_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ControllerType = CONTROLLER_TYPE.GENERIC;
            Xbox_Radio_Button.IsChecked = false;
            Playstation_Radio_Button.IsChecked = false;
            Auto_Radio_Button.IsChecked = false;
        }

        private void Playstation_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ControllerType = CONTROLLER_TYPE.PLAYSTATION;
            Xbox_Radio_Button.IsChecked = false;
            Other_Radio_Button.IsChecked = false;
            Auto_Radio_Button.IsChecked = false;
        }

        private void Auto_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ControllerType = CONTROLLER_TYPE.AUTO;
        }

        private void Light_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            Dark_Radio_Button.IsChecked = false;
            GlobalSettings.Theme = GlobalSettings.LIGHT;
            GlobalSettings.ApplyThemeTo(this);
        }

        private void Dark_Radio_Button_Checked(object sender, RoutedEventArgs e)
        {
            Light_Radio_Button.IsChecked = false;
            GlobalSettings.Theme = GlobalSettings.DARK;
            GlobalSettings.ApplyThemeTo(this);
        }
    }
}
