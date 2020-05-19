using System;
using Windows.Devices.Power;
using Windows.Gaming.Input;
using Windows.System.Power;

namespace ControllerDoctorUWP
{
    public class GenericController : IController
    {
        /// <summary>
        /// Controller is the Windows.Gaming.Input.RawGameController object exposed to the user for the sake of missing Methods.
        /// </summary>
        public RawGameController Controller;

        /// <summary>
        /// Connected Event is raised when a GenericController is detected.
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Disconnected Event is raised when a GenericController is disconnected after being connected.
        /// </summary>
        public event EventHandler Disconnected;

        public GenericController()
        {
            this.Controller = null;

            RawGameController.RawGameControllerRemoved += (s, e) =>
            {
                OnDisconnected(e);
            };

            RawGameController.RawGameControllerAdded += (s, e) =>
            {
                OnConnected(e);
            };
        }

        protected virtual void OnConnected(RawGameController e)
        {
            this.Controller = e;
            Connected.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDisconnected(RawGameController e)
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
            if (RawGameController.RawGameControllers.Count > 0)
            {
                OnConnected(RawGameController.RawGameControllers[0]);
            }
        }

        /// <summary>  
        /// ButtonBackPressed maps to the Share button on a Playstation controller, or Back button of a Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[8];
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
        /// ThumbpadRightPressed maps to the right thumbstick on a controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[11];
        }

        /// <summary>  
        /// ButtonLeftPressed maps to the left button on a controllers Direction Pad.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return SwitchArray[0] == GameControllerSwitchPosition.Left;
        }

        /// <summary>  
        /// ButtonDownPressed maps to the down button on a controllers Direction Pad.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return SwitchArray[0] == GameControllerSwitchPosition.Down;
        }

        /// <summary>  
        /// ButtonUpPressed maps to the up button on a controllers Direction Pad.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return SwitchArray[0] == GameControllerSwitchPosition.Up;
        }

        /// <summary>  
        /// ButtonRightPressed maps to the right button on a controllers Direction Pad.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return SwitchArray[0] == GameControllerSwitchPosition.Right;
        }

        /// <summary>  
        /// TriggerLeftPressed maps to the L2 button on a Playsation controller, or left trigger on a Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[6];
        }

        /// <summary>  
        /// TriggerRightPressed maps to the R2 button on a Playstation controller, or right trigger on a Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[7];
        }

        /// <summary>  
        /// ButtonAPressed maps to the X button on a Playstation controller, or A button on a Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[1];
        }

        /// <summary>  
        /// ButtonBPressed maps to the Circle button on a Playstation controller, or B button on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[2];
        }

        /// <summary>  
        /// ButtonXPressed maps to the Square button on a Playstation controller, or X button on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[0];
        }

        /// <summary>  
        /// ButtonShoulderLeftPressed maps to the L1 button on a Playstation controller, or left bumper button on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[4];
        }

        /// <summary>  
        /// ButtonShoulderRightPressed maps to the R1 button on a Playstation controller, or right bumper on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[5];
        }

        /// <summary>  
        /// ButtonStartPressed maps to the Options button on a Playstation controller, or Start button on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[9];
        }

        /// <summary>  
        /// ButtonYPressed maps to the Triangle button on a Playstation controller, or Y button on an Xbox controller.
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[3];
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return ButtonArray[10];
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return 100 * (1 - AxisArray[1]);
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return 100 * AxisArray[0];
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return 100 * (1 - AxisArray[5]);
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

            Boolean[] ButtonArray = new Boolean[20];
            GameControllerSwitchPosition[] SwitchArray = new GameControllerSwitchPosition[20];
            Double[] AxisArray = new Double[20];

            Controller.GetCurrentReading(ButtonArray, SwitchArray, AxisArray);

            return 100 * AxisArray[2];
        }

        /// <summary>  
        /// SetLeftVibration is disabled for GenericController objects for the time being.
        /// </summary>  
        public void SetLeftVibration(double d)
        {

        }

        /// <summary>  
        /// LeftVibration is disabled for GenericController objects for the time being.
        /// </summary>  
        public double LeftVibration()
        {
            return 0;
        }

        /// <summary>  
        /// SetRightVibration is disabled for GenericController objects for the time being.
        /// </summary>  
        public void SetRightVibration(double d)
        {

        }

        /// <summary>  
        /// RightVibration is disabled for GenericController objects for the time being.
        /// </summary>  
        public double RightVibration()
        {
            return 0;
        }

        /// <summary>  
        /// SetLeftTrigger is disabled for GenericController objects for the time being.
        /// </summary>  
        public void SetLeftTrigger(double d)
        {

        }

        /// <summary>  
        /// LeftTrigger is disabled for GenericController objects for the time being.
        /// </summary>  
        public double LeftTrigger()
        {
            return 0;
        }

        /// <summary>  
        /// SetRightTrigger is disabled for GenericController objects for the time being.
        /// </summary>  
        public void SetRightTrigger(double d)
        {

        }

        /// <summary>  
        /// RightTrigger is disabled for GenericController objects for the time being.
        /// </summary>  
        public double RightTrigger()
        {
            return 0;
        }

        /// <summary>  
        /// Type returns the CONTROLLER_TYPE value for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Type returns the CONTROLLER_TYPE value of GENERIC.
        /// </returns>
        public CONTROLLER_TYPE Type()
        {
            return CONTROLLER_TYPE.GENERIC;
        }

        /// <summary> 
        /// Vendor represents the Hardware Vendor ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Vendor returns the Hardware Vendor ID value for a IGamingController object.
        /// </returns>
        public ushort Vendor()
        {
            return Controller.HardwareVendorId;
        }

        /// <summary> 
        /// Product represents the Hardware Product ID for a IGamingController object.
        /// </summary>
        /// <returns>
        /// Product returns the Hardware Product ID value for a IGamingController object.
        /// </returns>
        public ushort Product()
        {
            return Controller.HardwareProductId;
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
