using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDoctorUWP
{
    class GlobalSettings
    {
        public static int DelayMilliseconds { get; set; }
        public static int StrokeThickness  { get; set; }

        public const bool GENERIC = true;
        public const bool XBOX = false;

        public static bool DeadzoneController = GENERIC;

        public static void ApplyDefaults()
        {
            DelayMilliseconds = 20;
            StrokeThickness = 2;
        }
    }
}
