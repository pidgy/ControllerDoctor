using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace ControllerDoctorUWP
{
    public class GenericController : IController
    {
        public RawGameController Controller;
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public GenericController()
        {
            Debug.WriteLine("CONTROLLERS: " + RawGameController.RawGameControllers.Count);

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
            Connected.Invoke(this, EventArgs.Empty);
            this.Controller = e;
        }

        protected virtual void OnDisconnected(RawGameController e)
        {
            Disconnected.Invoke(this, EventArgs.Empty);
            this.Controller = null;
        }

        public bool IsConnected()
        {
            return this.Controller != null;
        }

        public void Refresh()
        {
            if (RawGameController.RawGameControllers.Count > 0)
            {
                OnConnected(RawGameController.RawGameControllers[0]);
            }
        }

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

        public double LeftStickXPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbLeftX();
        }

        public double LeftStickYPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbLeftY();
        }

        public double RightStickXPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbRightX();
        }

        public double RightStickYPosition()
        {
            if (Controller == null)
            {
                return 0;
            }

            return ThumbRightY();
        }

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

            Debug.WriteLine("RX: " + (100 * AxisArray[2]));

            return 100 * AxisArray[2];
        }
    }
}
