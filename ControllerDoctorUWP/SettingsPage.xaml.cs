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
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

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

            this.Loaded += (s, e) =>
            {
                Defaults();
            };
        }

        void Defaults()
        {
            Delay_Slider.Value = GlobalSettings.DelayMilliseconds;
            Brush_Slider.Value = GlobalSettings.StrokeThickness;
            switch (GlobalSettings.DeadzoneController)
            {
                case GlobalSettings.XBOX:
                    Deadzone_Toggle.Content = "Xbox";
                    break;
                case GlobalSettings.GENERIC:
                    Deadzone_Toggle.Content = "Generic";
                    break;
            }
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

        private void Deadzone_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            if (GlobalSettings.DeadzoneController == GlobalSettings.GENERIC)
            {
                Deadzone_Toggle.Content = "Xbox";
                GlobalSettings.DeadzoneController = GlobalSettings.XBOX;
            }
            else
            {
                Deadzone_Toggle.Content = "Generic";
                GlobalSettings.DeadzoneController = GlobalSettings.GENERIC;
            }
        }
    }
}
