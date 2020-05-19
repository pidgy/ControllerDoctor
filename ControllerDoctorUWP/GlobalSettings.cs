using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;

namespace ControllerDoctorUWP
{
    public sealed class GlobalSettings
    {
        public const bool DARK = true;
        public const bool LIGHT = false;

        private static bool theme;
        public static bool Theme
        {
            get
            {
                try
                {
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    if (localSettings.Values.ContainsKey("THEME"))
                    {
                        theme = (bool)localSettings.Values["THEME"];
                    }
                    else
                    {
                        theme = DARK;
                    }
                }
                catch
                {
                    return DARK;
                }

                return theme;
            }
            set
            {
                try
                {
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["THEME"] = (bool)value;
                    theme = value;
                }
                catch { }
            }
        }

        public static Brush DefaultForegroundText = new SolidColorBrush(Colors.AliceBlue);
        public static Brush DefaultForeground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1F, 0x1F, 0x1F));
        public static Brush DefaultBackground = new SolidColorBrush(Color.FromArgb(0xFF, 0x1F, 0x1F, 0x1F));

        public static int DelayMilliseconds { get; set; }
        public static int StrokeThickness  { get; set; }

        private static CONTROLLER_TYPE cType;
        public static CONTROLLER_TYPE ControllerType
        { 
            get 
            {
                try
                {
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    if (localSettings.Values.ContainsKey("CONTROLLER_TYPE"))
                    {
                        cType = (CONTROLLER_TYPE)localSettings.Values["CONTROLLER_TYPE"];
                    }
                    else
                    {
                        cType = CONTROLLER_TYPE.GENERIC;
                    }
                }
                catch
                {
                    return CONTROLLER_TYPE.GENERIC;
                }

                return cType;
            }
            set 
            {
                try
                {
                    ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    localSettings.Values["CONTROLLER_TYPE"] = (int)value;
                    cType = value;
                }
                catch { }
            } 
        }

        public static void ApplyDefaults()
        {
            DelayMilliseconds = 20;
            StrokeThickness = 2;
        }

        public static BitmapImage ControllerImageSource(IController Controller)
        {
            switch (Controller.Type())
            {
                case CONTROLLER_TYPE.XBOX:
                    return new BitmapImage(new Uri("ms-appx:///controller-xbox.png"));
                case CONTROLLER_TYPE.PLAYSTATION:
                    return new BitmapImage(new Uri("ms-appx:///controller-ps.png"));
                case CONTROLLER_TYPE.GENERIC:
                    return new BitmapImage(new Uri("ms-appx:///controller-other.png"));
                case CONTROLLER_TYPE.KBM:
                    return new BitmapImage(new Uri("ms-appx:///controller-kb.png"));
            }

            return null;
        }

        private static Brush Accent()
        {
            if (Theme == DARK)
            {
               return new SolidColorBrush(Color.FromArgb(0xFF, 0x9f, 0x9f, 0xc6));
            }
         
            return DefaultBackground;
        }

        private static Brush Background()
        {
            if (Theme == LIGHT)
            {
                return new SolidColorBrush(Color.FromArgb(0xFF, 0x9f, 0x9f, 0xc6));
            }

            return DefaultBackground;
        }

        private static Brush BackgroundText()
        {
            if (Theme == LIGHT)
            {
                return DefaultForeground;
            }

            return new SolidColorBrush(Color.FromArgb(0xFF, 0x9f, 0x9f, 0xc6));
        }

        private static Brush Foreground()
        {
            if (Theme == LIGHT)
            {
               return new SolidColorBrush(Color.FromArgb(0xFF, 0x26, 0x26, 0x40));
            }

            return DefaultForeground;
        }

        private static Brush ForegroundText()
        {
            if (Theme == LIGHT)
            {
                return new SolidColorBrush(Color.FromArgb(0xFF, 0x26, 0x26, 0x40));
            }

            return DefaultForegroundText;
        }

        public static void ApplyThemeTo(Page page)
        {
            ApplyThemeTo((Grid)page.Content);
        }
        
        public static void ApplyThemeTo(Grid grid)
        {
            grid.Background = Background();
            grid.BorderBrush = Foreground();
            grid.BorderThickness = new Thickness(0.5);

            foreach (UIElement element in grid.Children)
            {
                if (element is Grid g)
                {
                    ApplyThemeTo(g);
                }
                else if (element is Button b)
                {
                    b.Background = Foreground();
                    b.Foreground = new SolidColorBrush(Colors.AliceBlue);
                    b.BorderBrush = Background();
                }
                else if (element is TextBlock t)
                {
                    t.Foreground = ForegroundText();
                }
                else if (element is Slider s)
                {
                    s.Resources["SliderThumbBackground"] = Accent();
                    s.Resources["SliderThumbBackgroundHover"] = Accent();
                    s.Foreground = Accent();
                    s.UpdateLayout();
                }
                else if (element is Viewbox v)
                {
                    if (v.Child is Grid c)
                    {
                        ApplyThemeTo(c);
                    }
                }
                else if (element is Border bo)
                {
                    bo.BorderBrush = ForegroundText();
                }
            }
        }
    }
}
