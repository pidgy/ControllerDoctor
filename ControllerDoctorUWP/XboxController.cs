using System;
using Windows.Devices.Power;
using Windows.Gaming.Input;
using Windows.System.Power;

namespace ControllerDoctorUWP
{
    public class XboxController : IController
    {
        /// <summary>
        /// Controller is the Windows.Gaming.Input.Gamepad object exposed to the user for the sake of missing Methods.
        /// </summary>
        public Gamepad Controller;

        /// <summary>
        /// Connected Event is raised when a XboxController is detected.
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Disconnected Event is raised when a XboxController is disconnected after being connected.
        /// </summary>
        public event EventHandler Disconnected;
        
        public XboxController()
        {
            this.Controller = null;

            Gamepad.GamepadAdded += (s, e) =>
            {
                OnConnected(e);
            };

            Gamepad.GamepadRemoved += (s, e) =>
            {
                OnDisconnected(e);
            };
        }

        protected virtual void OnConnected(Gamepad e)
        {
            this.Controller = e;
            Connected.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDisconnected(Gamepad e)
        {
            this.Controller = null;
            Disconnected.Invoke(this, EventArgs.Empty);
        }

        /// <summary>  
        /// IsConnected will check for a connected controller after creation.
        /// </summary> 
        /// <returns>
        /// IsConnected will return true if the Controllers' last event was Connected, false if the event was Disconnected.
        /// </returns>
        public bool IsConnected()
        {
            return this.Controller != null;
        }

        /// <summary>  
        /// Refresh will check for a connected controller after creation.
        /// This method should be called if the Connected EventHandler does not get raised at creation time.
        /// </summary>  
        public void Refresh()
        {
            if (Gamepad.Gamepads.Count > 0)
            {
                OnConnected(Gamepad.Gamepads[0]);
            }
        }

        /// <summary>  
        /// ButtonBackPressed maps to the Share button on a Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonBackPressed returns true if pressed, false otherwise;
        /// </returns>
        public bool ButtonBackPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.View;
        }

        /// <summary>  
        /// LeftStickXPosition maps to the position of the left thumbstick on a controller in the X-Axis.
        /// </summary>  
        /// <returns>
        /// LeftStickXPosition returns the result of ThumbLeftX;
        /// </returns>
        public double LeftStickXPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbLeftX();
        }

        /// <summary>  
        /// LeftStickYPosition maps to the position of the left thumbstick on a controller in the Y-Axis.
        /// </summary>  
        /// <returns>
        /// LeftStickYPosition returns the result of ThumbLeftY;
        /// </returns>
        public double LeftStickYPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbLeftY();
        }

        /// <summary>  
        /// RightStickXPosition maps to the position of the right thumbstick on a controller in the X-Axis.
        /// </summary>  
        /// <returns>
        /// RightStickYPosition returns the result of ThumbRightX;
        /// </returns>
        public double RightStickXPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbRightX();
        }

        /// <summary>  
        /// RightStickYPosition maps to the position of the right thumbstick on a controller in the Y-Axis.
        /// </summary>  
        /// <returns>
        /// RightStickYPosition returns the result of ThumbRightY;
        /// </returns>
        public double RightStickYPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbRightY();
        }

        /// <summary>  
        /// ThumbpadRightPressed maps to the right thumbstick on a Xbox controller.
        /// </summary>  
        /// <returns>
        /// ThumbpadRightPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ThumbpadRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.RightThumbstick;
        }

        /// <summary>  
        /// ButtonLeftPressed maps to the left button on a Xbox controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadLeft;
        }

        /// <summary>  
        /// ButtonDownPressed maps to the down button on a Xbox controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonDownPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonDownPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadDown;
        }

        /// <summary>  
        /// ButtonUpPressed maps to the up button on a Xbox controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonUpPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonUpPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadUp;
        }

        /// <summary>  
        /// ButtonRightPressed maps to the right button on a Xbox controllers Direction Pad.
        /// </summary>  
        /// <returns>
        /// ButtonRightPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadRight;
        }

        /// <summary>  
        /// TriggerLeftPressed maps to the left trigger on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// TriggerLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool TriggerLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().LeftTrigger > 0;
        }

        /// <summary>  
        /// TriggerRightPressed maps to the right trigger on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// TriggerRightPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool TriggerRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().RightTrigger > 0;
        }

        /// <summary>  
        /// ButtonAPressed maps to the A button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonAPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonAPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.A;
        }

        /// <summary>  
        /// ButtonBPressed maps to the B button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonBPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonBPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.B;
        }

        /// <summary>  
        /// ButtonXPressed maps to the X button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonXPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonXPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.X;
        }

        /// <summary>  
        /// ButtonShoulderLeftPressed maps to the left bumper on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonShoulderLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonShoulderLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.LeftShoulder;
        }

        /// <summary>  
        /// ButtonShoulderRightPressed maps to the right bumper on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonShoulderRightPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonShoulderRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.RightShoulder;
        }

        /// <summary>  
        /// ButtonStartPressed maps to the Start button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonStartPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonStartPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.Menu;
        }

        /// <summary>  
        /// ButtonYPressed maps to Y button on an Xbox controller.
        /// </summary>  
        /// <returns>
        /// ButtonYPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ButtonYPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.Y;
        }

        /// <summary>  
        /// ThumbpadLeftPressed maps to the left thumbstick on a controller.
        /// </summary>  
        /// <returns>
        /// ThumbpadLeftPressed returns true if pressed, false otherwise.
        /// </returns>
        public bool ThumbpadLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.LeftThumbstick;
        }

        /// <summary>  
        /// ThumbLeftY maps to the position of the left thumbstick on the Y-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbLeftY returns a value between 0 and 100, where 50 lies on the origin of the Y-Axis.
        /// </returns>
        public double ThumbLeftY()
        {
            if (Controller == null)
            {
                return 50;
            }

            double Reading = Controller.GetCurrentReading().LeftThumbstickY;
            Reading += 1;
            Reading *= 100;
            Reading /= 200;
            Reading *= 100;

            return Reading;
        }

        /// <summary>  
        /// ThumbLeftX maps to the position of the left thumbstick on the X-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbLeftX returns a value between 0 and 100, where 50 lies on the origin of the X-Axis.
        /// </returns>
        public double ThumbLeftX()
        {
            if (Controller == null)
            {
                return 50;
            }

            double Reading = Controller.GetCurrentReading().LeftThumbstickX;
            Reading += 1;
            Reading *= 100;
            Reading /= 200;
            Reading *= 100;

            return Reading;
        }

        /// <summary>  
        /// ThumbRightY maps to the position of the right thumbstick on the Y-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbRightY returns a value between 0 and 100, where 50 lies on the origin of the Y-Axis.
        /// </returns>
        public double ThumbRightY()
        {
            if (Controller == null)
            {
                return 50;
            }

            double Reading = Controller.GetCurrentReading().RightThumbstickY;
            Reading += 1;
            Reading *= 100;
            Reading /= 200;
            Reading *= 100;

            return Reading;
        }

        /// <summary>  
        /// ThumbRightX maps to the position of the right thumbstick on the X-Axis for the controller.
        /// </summary>  
        /// <returns>
        /// ThumbRightX returns a value between 0 and 100, where 50 lies on the origin of the X-Axis.
        /// </returns>
        public double ThumbRightX()
        {
            if (Controller == null)
            {
                return 50;
            }

            double Reading = Controller.GetCurrentReading().RightThumbstickX;
            Reading += 1;
            Reading *= 100;
            Reading /= 200;
            Reading *= 100;

            return Reading;
        }

        /// <summary>  
        /// SetLeftVibration will change the amount of vibration set for the left motor on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        public void SetLeftVibration(double d)
        {
            GamepadVibration vibration = new GamepadVibration();
            vibration.LeftMotor = d/100; 
            Controller.Vibration = vibration;
        }

        /// <summary>  
        /// LeftVibration represents the amount of vibration set for the left motor on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// LeftVibration returns a value between 0 and 100.
        /// </returns>
        public double LeftVibration()
        {
            return Controller.Vibration.LeftMotor * 100;
        }

        /// <summary>  
        /// SetRightVibration will change the amount of vibration set for the right motor on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        public void SetRightVibration(double d)
        {
            System.Diagnostics.Debug.WriteLine("HERE");
            GamepadVibration vibration = new GamepadVibration();
            vibration.RightMotor = d/100; 
            Controller.Vibration = vibration;
        }

        /// <summary>  
        /// RightVibration represents the amount of vibration set for the right motor on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// RightVibration returns a value between 0 and 100.
        /// </returns>
        public double RightVibration()
        {
            return Controller.Vibration.RightMotor * 100;
        }

        /// <summary>  
        /// SetLeftTrigger will change the amount of vibration set for the left trigger on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        public void SetLeftTrigger(double d)
        {
            GamepadVibration vibration = new GamepadVibration();
            vibration.LeftTrigger = d / 100;
            Controller.Vibration = vibration;
        }

        /// <summary>  
        /// LeftTrigger represents the amount of vibration set for the left trigger on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// LeftTrigger returns a value between 0 and 100.
        /// </returns>
        public double LeftTrigger()
        {
            return Controller.Vibration.LeftTrigger * 100;
        }

        /// <summary>  
        /// SetRightTrigger will change the amount of vibration set for the right trigger on an Xbox controller.
        /// A value between 0 and 100 is expected to be passed.
        /// </summary> 
        public void SetRightTrigger(double d)
        {
            GamepadVibration vibration = new GamepadVibration();
            vibration.RightTrigger = d / 100;
            Controller.Vibration = vibration;
        }

        /// <summary>  
        /// RightTrigger represents the amount of vibration set for the right trigger on an Xbox controller.
        /// </summary> 
        /// <returns>
        /// RightTrigger returns a value between 0 and 100.
        /// </returns>
        public double RightTrigger()
        {
            return Controller.Vibration.RightTrigger * 100;
        }

        /// <summary>  
        /// Type returns the CONTROLLER_TYPE value for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Type returns the CONTROLLER_TYPE value of XBOX.
        /// </returns>
        public CONTROLLER_TYPE Type()
        {
            return CONTROLLER_TYPE.XBOX;
        }

        /// <summary> 
        /// Vendor represents the Hardware Vendor ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Vendor returns the Hardware Vendor ID value for a IGamingController object.
        /// </returns>
        public ushort Vendor()
        {
            RawGameController raw = RawGameController.FromGameController(Controller);
            return raw.HardwareVendorId;
        }

        /// <summary> 
        /// Product represents the Hardware Product ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Product returns the Hardware Product ID value for a IGamingController object.
        /// </returns>
        public ushort Product()
        {
            RawGameController raw = RawGameController.FromGameController(Controller);
            return raw.HardwareProductId;
        }

        /// <summary> 
        /// Battery represents the current BatteryReport for a IGamingController object.
        /// This call should be wrapped in a try-catch for safety.
        /// </summary>
        /// <returns>
        /// Battery returns a Windows.Devices.Power.BatteryReport object for a IGamingController object.
        /// </returns>
        public BatteryReport Battery()
        {
            return Controller.TryGetBatteryReport();
        }
        
        /// <summary> 
        /// Status represents the current Battery Status for a IGamingController object.
        /// This call is wrapped in a try-catch for safe use.
        /// </summary>
        /// <returns>
        /// Status returns a Windows.System.Power.BatteryStatus object for a IGamingController object.
        /// </returns>
        public BatteryStatus Status()
        {
            try
            {
                return this.Battery().Status;
            }
            catch
            {
                return new BatteryStatus();
            }
        }
    }
}
