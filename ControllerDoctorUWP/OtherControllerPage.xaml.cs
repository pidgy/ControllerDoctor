using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Popups;
using Windows.Foundation;
using Windows.UI.Core;

namespace ControllerDoctorUWP
{
    public partial class OtherControllerPage : Page
    {
        Dictionary<string, ButtonData> Buttons;
        GenericController controller;

        List<Task> Tasks;
        CancellationTokenSource CancellationToken;

        public OtherControllerPage()
        {
            this.InitializeComponent();
            
            GlobalSettings.ApplyThemeTo(this);

            CancellationToken = new CancellationTokenSource();

            this.Loaded += (s1, e1) =>
            {
                X_Button_TextBlock.Foreground = new SolidColorBrush(Colors.Blue);
                Y_Button_TextBlock.Foreground = new SolidColorBrush(Colors.Yellow);
                B_Button_TextBlock.Foreground = new SolidColorBrush(Colors.Red);
                A_Button_TextBlock.Foreground = new SolidColorBrush(Colors.LawnGreen);
                
                Initialize();

                controller = new GenericController();

                controller.Connected += (s2, e2) =>
                {
                    SetConnectedAsync();
                };

                controller.Disconnected += (s2, e2) =>
                {
                    SetDisonnectedAsync();
                };

                controller.Refresh();
            };
        }

        public async void SetConnectedAsync()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            {
                Connected_TextBlock.Text = "Connected";
                Connected_TextBlock.Foreground = new SolidColorBrush(Colors.LawnGreen);

                KillAllThreads();
                Run();
            });
        }

        public async void SetDisonnectedAsync()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, () => {
                Connected_TextBlock.Text = "Disconnected";
                Connected_TextBlock.Foreground = new SolidColorBrush(Colors.Red);

                KillAllThreads();
            });
        }

        private void Initialize()
        {
            Tasks = new List<Task>();

            Buttons = new Dictionary<string, ButtonData>();

            Buttons[Left_Stick.Name] = new ButtonData(Left_Stick, (IController c) => {
                if (c.ThumbpadLeftPressed())
                {
                    return Press.DIRECTION.PRESSED;
                }

                if (c.ThumbLeftY() > 55)
                {
                    return Press.DIRECTION.UP;
                }
                if (c.ThumbLeftY() < 45)
                {
                    return Press.DIRECTION.DOWN;
                }
                if (c.ThumbLeftX() < 45)
                {
                    return Press.DIRECTION.LEFT;
                }
                if (c.ThumbLeftX() > 55)
                {
                    return Press.DIRECTION.RIGHT;
                }

                return Press.DIRECTION.NONE;
            }, Left_Joystick_Status);

            Buttons[Right_Stick.Name] = new ButtonData(Right_Stick, (IController c) => {
                if (c.ThumbpadRightPressed())
                {
                    return Press.DIRECTION.PRESSED;
                }
                if (c.ThumbRightY() > 55)
                {
                    return Press.DIRECTION.UP;
                }
                if (c.ThumbRightY() < 45)
                {
                    return Press.DIRECTION.DOWN;
                }
                if (c.ThumbRightX() < 45)
                {
                    return Press.DIRECTION.LEFT;
                }
                if (c.ThumbRightX() > 55)
                {
                    return Press.DIRECTION.RIGHT;
                }
                return Press.DIRECTION.NONE;
            }, Right_Joystick_Status);

            Buttons[Direction_Pad.Name] = new ButtonData(Direction_Pad, (IController c) => {
                if (c.ButtonLeftPressed())
                {
                    return Press.DIRECTION.LEFT;
                }
                if (c.ButtonDownPressed())
                {
                    return Press.DIRECTION.DOWN;
                }
                if (c.ButtonUpPressed())
                {
                    return Press.DIRECTION.UP;
                }
                if (c.ButtonRightPressed())
                {
                    return Press.DIRECTION.RIGHT;
                }

                return Press.DIRECTION.NONE;
            }, Direction_Pad_Status);

            Buttons[Left_Trigger.Name] = new ButtonData(Left_Trigger, (IController c) => { return true == c.TriggerLeftPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Left_Trigger_Status);
            Buttons[Right_Trigger.Name] = new ButtonData(Right_Trigger, (IController c) => { return true == c.TriggerRightPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Right_Trigger_Status);
            Buttons[A_Button.Name] = new ButtonData(A_Button, (IController c) => { return true == c.ButtonAPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, A_Button_Status);
            Buttons[X_Button.Name] = new ButtonData(X_Button, (IController c) => { return true == c.ButtonXPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, X_Button_Status);
            Buttons[Y_Button.Name] = new ButtonData(Y_Button, (IController c) => { return true == c.ButtonYPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Y_Button_Status);
            Buttons[B_Button.Name] = new ButtonData(B_Button, (IController c) => { return true == c.ButtonBPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, B_Button_Status);
            Buttons[Left_Bumper.Name] = new ButtonData(Left_Bumper, (IController c) => { return true == c.ButtonShoulderLeftPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Left_Bumper_Status);
            Buttons[Right_Bumper.Name] = new ButtonData(Right_Bumper, (IController c) => { return true == c.ButtonShoulderRightPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Right_Bumper_Status);
            Buttons[Start_Button.Name] = new ButtonData(Start_Button, (IController c) => { return true == c.ButtonStartPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Start_Status);
            Buttons[Menu_Button.Name] = new ButtonData(Menu_Button, (IController c) => { return true == c.ButtonBackPressed() ? Press.DIRECTION.PRESSED : Press.DIRECTION.NONE; }, Menu_Status);
        }

        private void Clear()
        {
            if (Paused)
            {
                foreach (ButtonData button in Buttons.Values)
                {
                    button.Canvas.Children.Clear();
                }
            }

            if (InputDelayMarkers)
            {
                foreach (ButtonData button in Buttons.Values)
                {
                    button.Label.Foreground = new SolidColorBrush(Colors.White);
                    button.Label.Text = "0.0 ms";
                    button.Clear();
                    button.SetInputDelay(true);
                }
            }
            else
            {
                foreach (ButtonData button in Buttons.Values)
                {
                    button.Label.Foreground = new SolidColorBrush(Colors.White);
                    button.Label.Text = "Waiting...";
                    button.Clear();
                    button.SetInputDelay(false);
                }
            }
        }

        public void KillAllThreads()
        {
            CancellationToken.Cancel();
        }

        private void Run()
        {
            CancellationToken = new CancellationTokenSource();

            foreach (string canvasName in Buttons.Keys)
            {
                Buttons[canvasName].Polyline.Points = new PointCollection();

                Task task = new Task(Diagnos, Buttons[canvasName], CancellationToken.Token, TaskCreationOptions.LongRunning);
                task.Start();

                Tasks.Add(task);
            }
        }

        public void Diagnos(object obj)
        {
            ButtonData canvas = (ButtonData)obj;

            Debug.WriteLine("[THREAD START] PlaystationControllerPage -> Diagnos");

            while (true)
            {
                try
                {
                    CancellationToken.Token.ThrowIfCancellationRequested();

                    if (controller.IsConnected())
                    {
                        DrawAsync(canvas.Canvas, canvas.Pressed);
                    }
                }
                catch
                {
                    Debug.WriteLine("[THREAD KILL] PlaystationControllerPage -> Diagnos");
                    return;
                }

                Thread.Sleep(GlobalSettings.DelayMilliseconds);
            }
        }

        public async void DrawAsync(Canvas canvas, Press.Pressed pressed)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, () => {
                Draw(canvas.Name, pressed);
                CalculateInputDelay(canvas.Name);
            });
        }

        public void Draw(string canvasName, Press.Pressed pressed)
        {
            double ymin = 7;
            double ymax = Buttons[canvasName].Canvas.Height - ymin;
            double hit_y = (ymax - ymin);

            if (Buttons[canvasName].Polyline.Points.Count == Buttons[canvasName].Canvas.Width)
            {
                ButtonData button = Buttons[canvasName];
                button.Polyline.Points.Clear();
                button.LastPressed = new Point();
                Buttons[canvasName] = button;
            }

            Point point;

            Press.DIRECTION where = pressed(controller);
            if (where == Press.DIRECTION.NONE)
            {
                point = new Point(Buttons[canvasName].Polyline.Points.Count, hit_y);
            }
            else
            {
                point = new Point(Buttons[canvasName].Polyline.Points.Count, hit_y * Press.Direction(where));

                ButtonData button = Buttons[canvasName];

                if (point.X > button.LastPressed.X + 10)
                {
                    button.LastPressed = point;
                }

                Buttons[canvasName] = button;
            }

            if (!Paused)
            {
                Buttons[canvasName].Polyline.Points.Add(point);
            }

            if (!InputDelayMarkers)
            {
                Buttons[canvasName].Label.Text = Press.DirectionString(where);
            }

            Buttons[canvasName].Polyline.Stroke = Press.DirectionBrush(where);

            if (Buttons[canvasName].Canvas.Children.Contains(Buttons[canvasName].Polyline))
            {
                Buttons[canvasName].Canvas.Children.Remove(Buttons[canvasName].Polyline);
            }

            Buttons[canvasName].Canvas.Children.Add(Buttons[canvasName].Polyline);
        }

        public void CalculateInputDelay(string canvasName)
        {
            if (!InputDelayMarkers)
            {
                return;
            }

            // no button press yet...
            if (Buttons[canvasName].LastPressed.X == 0)
            {
                return;
            }

            // no new button press
            if (Buttons[canvasName].LastLastPressed == Buttons[canvasName].LastPressed)
            {
                return;
            }

            double last = 0;
            foreach (double xpos in Buttons[canvasName].InputDelayMarkerXPositions)
            {
                double pos = xpos + (xpos * 0.3);

                if (Buttons[canvasName].Polyline.Points.Count > last && Buttons[canvasName].Polyline.Points.Count < pos)
                {
                    ButtonData button = Buttons[canvasName];
                    button.Delay = Math.Abs(button.LastPressed.X - xpos) * GlobalSettings.DelayMilliseconds;
                    Buttons[canvasName] = button;
                }

                last = pos;
            }

            Buttons[canvasName].Label.Text = Buttons[canvasName].Delay + " ms";

            if (Buttons[canvasName].Delay <= 30)
            {
                Buttons[canvasName].Label.Foreground = new SolidColorBrush(Colors.LawnGreen);
            }
            else if (Buttons[canvasName].Delay > 30)
            {
                Buttons[canvasName].Label.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else if (Buttons[canvasName].Delay > 60)
            {
                Buttons[canvasName].Label.Foreground = new SolidColorBrush(Colors.Red);
            }

            Buttons[canvasName].LastLastPressed = Buttons[canvasName].LastPressed;
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        public bool InputDelayMarkers = false;
        private async void Delay_Button_Click(object sender, RoutedEventArgs e)
        {
            InputDelayMarkers = !InputDelayMarkers;
            if (InputDelayMarkers)
            {
                await SetupInputDelay();
            }
            else
            {
                TeardownInputDelay();
            }
        }

        private void TeardownInputDelay()
        {
            Delay_Button.Content = "Add Input Delay Markers";
            foreach (ButtonData button in Buttons.Values)
            {
                button.Label.Text = "Waiting...";
            }

            Clear();
        }

        private async Task SetupInputDelay()
        {
            Delay_Button.Content = "Remove Input Delay Markers";
            Status_TextBlock.Text = "Delay";

            foreach (ButtonData button in Buttons.Values)
            {
                button.Label.Text = "0.0 ms";
            }

            await AlertAndWaitAsync("Press the button you would like to test as it reaches the white bar. " + "\n\n" +
                            "The input delay for the button will be displayed under the \"Delay\" column.",
                            "Input Delay Test");

            Clear();
        }

        bool Paused = false;
        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {
            Paused = !Paused;

            if (Paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        private void Resume()
        {
            Pause_Button.Content = "Pause";
        }

        private void Pause()
        {
            Pause_Button.Content = "Resume";
        }

        public async Task AlertAndWaitAsync(string msg, string title)
        {
            MessageDialog messageDialog = new MessageDialog(msg, title);
            await messageDialog.ShowAsync();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            KillAllThreads();
            base.OnNavigatedFrom(e);
        }
    }
}
