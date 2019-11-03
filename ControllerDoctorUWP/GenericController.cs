using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace ControllerDoctorUWP
{
    public class GenericController : IController
    {
        public Gamepad Controller;
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public GenericController()
        {
            this.Controller = null;

            Gamepad.GamepadRemoved += (s, e) =>
            {
                OnDisconnected(e);
            };

            Gamepad.GamepadAdded += (s, e) =>
            {
                OnConnected(e);
            };
        }

        protected virtual void OnConnected(Gamepad e)
        {
            Connected.Invoke(this, EventArgs.Empty);
            this.Controller = e;
        }

        protected virtual void OnDisconnected(Gamepad e)
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
            if (Gamepad.Gamepads.Count > 0)
            {
                OnConnected(Gamepad.Gamepads[0]);
            }
        }

        public bool ButtonBackPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.View;
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

            return Controller.GetCurrentReading().Buttons == GamepadButtons.RightThumbstick;
        }

        public bool ButtonLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadLeft;
        }

        public bool ButtonDownPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadDown;
        }

        public bool ButtonUpPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadUp;
        }

        public bool ButtonRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.DPadRight;
        }

        public bool TriggerLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().LeftTrigger > 0;
        }

        public bool TriggerRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().RightTrigger > 0;
        }

        public bool ButtonAPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.A;
        }

        public bool ButtonBPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.B;
        }

        public bool ButtonXPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.X;
        }

        public bool ButtonShoulderLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.LeftShoulder;
        }

        public bool ButtonShoulderRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.RightShoulder;
        }

        public bool ButtonStartPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.Menu;
        }

        public bool ButtonYPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.Y;
        }

        public bool ThumbpadLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.GetCurrentReading().Buttons == GamepadButtons.LeftThumbstick;
        }

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
    }

}
