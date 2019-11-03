using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;

namespace ControllerDoctorUWP
{
    public class Press
    {
        public static List<Brush> DirectionBrushes;
        public static List<double> DirectionHit;

        public delegate DIRECTION Pressed(IController m);

        public enum DIRECTION
        {
            PRESSED = 0,
            UP = 1,
            DOWN = 2,
            LEFT = 4,
            RIGHT = 8,
            NONE = 16,
        }

        public static Brush DirectionBrush(DIRECTION where)
        {
            return DirectionBrushes[(int)Math.Sqrt((int)where)];
        }

        public static double Direction(Press.DIRECTION where)
        {
            return DirectionHit[(int)Math.Sqrt((int)where)];
        }
        
        public static string DirectionString(Press.DIRECTION where)
        {
            switch (where)
            {
                case Press.DIRECTION.UP:
                    return "Up";
                case Press.DIRECTION.DOWN:
                    return "Down";
                case Press.DIRECTION.LEFT:
                    return "Left";
                case Press.DIRECTION.RIGHT:
                    return "Right";
                case Press.DIRECTION.PRESSED:
                    return "Pressed";
            }

            return "Waiting...";
        }
    }
}
