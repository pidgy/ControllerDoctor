using System;
using System.Diagnostics;
using Windows.Devices.Input;
using Windows.Gaming.Input;

namespace ControllerDoctorUWP
{
    public class Controller
    {
        public static string TypeString(ushort VendorID)
        {
            switch (VendorID)
            {
                case (ushort)VENDOR_ID.XBOX:
                    return "Xbox";
                case (ushort)VENDOR_ID.PLAYSTATION:
                    return "Playstation";
                default:
                    return "Generic";
            }
        }
    }
}

