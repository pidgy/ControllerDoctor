using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace ControllerDoctorUWP
{
    public class ButtonData
    {
        public Press.Pressed Pressed;
        public TextBlock Label;

        public Polyline Polyline { get; set; }

        public double Delay { get; set; }
        public Point LastPressed;
        public Point LastLastPressed;

        public List<Path> InputDelayPaths;
        public List<double> InputDelayMarkerXPositions;

        private Canvas canvas;

        public ButtonData(Canvas canvas, Press.Pressed pressed, TextBlock label)
        {
            this.canvas = canvas;

            this.Pressed = pressed;
            this.Label = label;
            this.Polyline = new Polyline();
            this.LastPressed = new Point();
            this.LastLastPressed = new Point();
            
            this.Delay = 0;
            
            this.InputDelayPaths = new List<Path>();
            this.InputDelayMarkerXPositions = new List<double>();

            this.Polyline.StrokeThickness = GlobalSettings.StrokeThickness;

            this.canvas.CacheMode = new BitmapCache();
        }

        bool inputDelay = false;
        public void SetInputDelay(bool delay)
        { 

            inputDelay = delay;
            Clear();
        }

        public void Clear()
        {
            canvas.Children.Clear();
            Polyline = new Polyline();
            InputDelayPaths.Clear();

            if (inputDelay)
            {
                DrawInputDelayCanvasFrom(this.canvas);
            }
        }

        public Canvas Canvas
        {
            get 
            { 
                return this.canvas;
            }
        }

        private void DrawInputDelayCanvasFrom(Canvas canvas)
        {
            if (InputDelayPaths.Count == 0)
            {
                InputDelayMarkerXPositions = new List<double>() { canvas.Width * 0.2, canvas.Width * 0.4, canvas.Width * 0.6, canvas.Width * 0.8 };

                foreach (double at in InputDelayMarkerXPositions)
                {
                    GeometryGroup YAxisGeomGroup = new GeometryGroup();
                    LineGeometry LineGeom = new LineGeometry();
                    LineGeom.StartPoint = new Point(at, 0);
                    LineGeom.EndPoint = new Point(at, canvas.Height);
                    YAxisGeomGroup.Children.Add(LineGeom);

                    Path YAxisPath = new Path();
                    YAxisPath.StrokeThickness = GlobalSettings.StrokeThickness;
                    YAxisPath.Stroke = new SolidColorBrush(Colors.White);
                    YAxisPath.Data = YAxisGeomGroup;

                    InputDelayPaths.Add(YAxisPath);

                    this.canvas.Children.Add(YAxisPath);
                }
            }
        }
    }
}
