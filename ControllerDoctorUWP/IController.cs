using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Power;
using Windows.System.Power;

namespace ControllerDoctorUWP
{
    public enum CONTROLLER_TYPE 
    {
        XBOX = 0,
        PLAYSTATION = 1,
        GENERIC = 3,
        KBM = 4,
        AUTO = 5
    }

    public enum VENDOR_ID
    {
        XBOX = 0x045E,
        PLAYSTATION = 0x054C,
        GENERIC = 0xFF,
        KBM = 0xFFF,
    }

    public interface IController
    {
        /// <summary>  
        /// IsConnected will check for a connected controller after creation.
        /// </summary> 
        /// <returns>
        /// IsConnected will return true if the Controllers' last event was Connected, false if the event was Disconnected.
        /// </returns>
        bool IsConnected();

        /// <summary>  
        /// Refresh will check for a connected controller after creation.
        /// This method should be called if the Connected EventHandler does not get raised at creation time.
        /// </summary>  
        void Refresh();

        /// <summary>  
        /// ButtonBackPressed maps to the Share button on a Playstation controller, or Back button of a Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonBackPressed returns true if pressed, false otherwise;
        /// </returns>
        bool ButtonBackPressed();

        /// <summary>  
        /// LeftStickXPosition maps to the position of the left thumbstick on a controller in the X-Axis.
        /// </summary>  
        /// <returns>
        /// LeftStickXPosition returns the result of ThumbLeftX;
        /// </returns>
        double LeftStickXPosition();

        /// <summary>  
        /// LeftStickYPosition maps to the position of the left thumbstick on a controller in the Y-Axis.
        /// </summary>  
        /// <returns>
        /// LeftStickYPosition returns the result of ThumbLeftY;
        /// </returns>
        double LeftStickYPosition();

        /// <summary>  
        /// RightStickXPosition maps to the position of the right thumbstick on a controller in the X-Axis.
        /// </summary>  
        /// <returns>
        /// RightStickYPosition returns the result of ThumbRightX;
        /// </returns>
        double RightStickXPosition();

        /// <summary>  
        /// RightStickYPosition maps to the position of the right thumbstick on a controller in the Y-Axis.
        /// </summary>  
        /// <returns>
        /// RightStickYPosition returns the result of ThumbRightY;
        /// </returns>
        double RightStickYPosition();

        /// <summary>  
        /// ThumbpadRightPressed maps to the right thumbstick on a controller.
        /// </summary>  
        /// <returns>
        /// ThumbpadRightPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ThumbpadRightPressed();

        /// <summary>  
        /// ButtonLeftPressed maps to the left button on a controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonLeftPressed();

        /// <summary>  
        /// ButtonDownPressed maps to the down button on a controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonDownPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonDownPressed();

        /// <summary>  
        /// ButtonUpPressed maps to the up button on a controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonUpPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonUpPressed();

        /// <summary>  
        /// ButtonRightPressed maps to the right button on a controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonRightPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonRightPressed();

        /// <summary>  
        /// TriggerLeftPressed maps to the L2 button on a Playsation controller, or left trigger on a Xbox controller.
        /// </summary>  
        /// <returns>
        /// TriggerLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        bool TriggerLeftPressed();

        /// <summary>  
        /// TriggerRightPressed maps to the R2 button on a Playstation controller, or right trigger on a Xbox controller.
        /// </summary>  
        /// <returns>
        /// TriggerRightPressed returns true if pressed, false otherwise.
        /// </returns>
        bool TriggerRightPressed();

        /// <summary>  
        /// ButtonAPressed maps to the X button on a Playstation controller, or A button on a Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonAPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonAPressed();

        /// <summary>  
        /// ButtonBPressed maps to the Circle button on a Playstation controller, or B button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonBPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonBPressed();

        /// <summary>  
        /// ButtonXPressed maps to the Square button on a Playstation controller, or X button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonXPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonXPressed();

        /// <summary>  
        /// ButtonShoulderLeftPressed maps to the L1 button on a Playstation controller, or left bumper button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonShoulderLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonShoulderLeftPressed();

        /// <summary>  
        /// ButtonShoulderRightPressed maps to the R1 button on a Playstation controller, or right bumper on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonShoulderRightPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonShoulderRightPressed();

        /// <summary>  
        /// ButtonStartPressed maps to the Options button on a Playstation controller, or Start button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonStartPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonStartPressed();

        /// <summary>  
        /// ButtonYPressed maps to the Triangle button on a Playstation controller, or Y button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonYPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ButtonYPressed();

        /// <summary>  
        /// ThumbpadLeftPressed maps to the left thumbstick on a controller.
        /// </summary>  
        /// <returns>
        /// ThumbpadLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        bool ThumbpadLeftPressed();

        /// <summary>  
        /// ThumbLeftY maps to the position of the left thumbstick on the Y-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbLeftY returns a value between 0 and 100, where 50 lies on the origin of the Y-Axis.
        /// </returns>
        double ThumbLeftY();

        /// <summary>  
        /// ThumbLeftX maps to the position of the left thumbstick on the X-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbLeftX returns a value between 0 and 100, where 50 lies on the origin of the X-Axis.
        /// </returns>
        double ThumbLeftX();

        /// <summary>  
        /// ThumbRightY maps to the position of the right thumbstick on the Y-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbRightY returns a value between 0 and 100, where 50 lies on the origin of the Y-Axis.
        /// </returns>
        double ThumbRightY();

        /// <summary>  
        /// ThumbRightX maps to the position of the right thumbstick on the X-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbRightX returns a value between 0 and 100, where 50 lies on the origin of the X-Axis.
        /// </returns>
        double ThumbRightX();

        /// <summary>  
        /// SetLeftVibration will change the amount of vibration set for the left motor on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        void SetLeftVibration(double d);

        /// <summary>  
        /// LeftVibration represents the amount of vibration set for the left motor on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// LeftVibration returns a value between 0 and 100.
        /// </returns>
        double LeftVibration();
        
        /// <summary>  
        /// SetRightVibration will change the amount of vibration set for the right motor on a controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        void SetRightVibration(double d);

        /// <summary>  
        /// RightVibration represents the amount of vibration set for the right motor on a controller.
        /// </summary> 
        /// <returns>
        /// RightVibration returns a value between 0 and 100.
        /// </returns>
        double RightVibration();

        /// <summary>  
        /// SetLeftTrigger will change the amount of vibration set for the left trigger on a controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        void SetLeftTrigger(double d);

        /// <summary>  
        /// LeftTrigger represents the amount of vibration set for the left trigger on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// LeftTrigger returns a value between 0 and 100.
        /// </returns>
        double LeftTrigger();

        /// <summary>  
        /// SetRightTrigger will change the amount of vibration set for the right trigger on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary>
        void SetRightTrigger(double d);

        /// <summary>  
        /// RightTrigger represents the amount of vibration set for the right trigger on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// RightTrigger returns a value between 0 and 100.
        /// </returns>
        double RightTrigger();

        /// <summary> 
        /// Vendor represents the Hardware Vendor ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Vendor returns the Hardware Vendor ID value for a IGamingController object.
        /// </returns>
        ushort Vendor();

        /// <summary> 
        /// Product represents the Hardware Product ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Product returns the Hardware Product ID value for a IGamingController object.
        /// </returns>
        ushort Product();

        /// <summary> 
        /// Battery represents the current BatteryReport for a IGamingController object.
        /// This call should be wrapped in a try-catch for safety.
        /// </summary>
        /// <returns>
        /// Battery returns a Windows.Devices.Power.BatteryReport object for a IGamingController object.
        /// </returns>
        BatteryReport Battery();

        /// <summary> 
        /// Status represents the current Battery Status for a IGamingController object.
        /// This call is wrapped in a try-catch for safe use.
        /// </summary>
        /// <returns>
        /// Status returns a Windows.System.Power.BatteryStatus object for a IGamingController object.
        /// </returns>
        BatteryStatus Status();

        /// <summary>  
        /// Type returns the CONTROLLER_TYPE value for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Type returns a CONTROLLER_TYPE value.
        /// </returns>
        CONTROLLER_TYPE Type();
    }
}
