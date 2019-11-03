using BrandonPotter.XBox;
using System;
using System.Diagnostics;
using Windows.Devices.Input;
using Windows.Gaming.Input;

namespace ControllerDoctorUWP
{
    public class Controller
    {
        public XBoxController XboxController;
        public KeyboardCapabilities Keyboard;
        public MouseDevice Mouse;
        public Gamepad GenericController;

        public event EventHandler Connected;
        public event EventHandler Disconnected;
        
        protected virtual void OnConnected(Gamepad e)
        {
            Connected.Invoke(this, EventArgs.Empty);
            this.GenericController = e;
        }

        protected virtual void OnDisconnected(Gamepad e)
        {
            Disconnected.Invoke(this, EventArgs.Empty);
            this.GenericController = null;
        }

        public Controller()
        {
            this.GenericController = null;

            Gamepad.GamepadRemoved += (s, e) =>
            {
                OnDisconnected(e);
            };

            Gamepad.GamepadAdded += (s, e) =>
            {
                OnConnected(e);
            };
        }

        public void Refresh()
        {
            if (Gamepad.Gamepads.Count > 0)
            {
                OnConnected(Gamepad.Gamepads[0]);
            }
        }

        public bool IsConnected
        {
            get
            {
                return this.XboxController != null || this.GenericController != null;
            }
        }
       
        public double LeftStickXPosition
        {
            get
            {
                if (GenericController != null)
                {
                    return ThumbLeftX;
                }

                if (XboxController != null)
                {
                    return XboxController.ThumbLeftX;
                }
                
                return 0;
            }
        }

        public double LeftStickYPosition
        {
            get
            {
                if (GenericController != null)
                {
                    return ThumbLeftY;
                }

                if (XboxController != null)
                {
                    return XboxController.ThumbLeftY;
                }
               
                return 0;
            }
        }

        public double RightStickXPosition
        {
            get
            {
                if (GenericController != null)
                {
                    return ThumbRightX;
                }

                if (XboxController != null)
                {
                    return XboxController.ThumbRightX;
                }

                return 0;
            }
        }
       
        public double RightStickYPosition
        {
            get
            {
                if (GenericController != null)
                {
                    return ThumbRightY;
                }
                
                if (XboxController != null)
                {
                    return XboxController.ThumbRightY;
                }

                return 0;
            }
        }

        public bool ThumbpadRightPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.RightThumbstick;
            }
        }

        public bool ButtonLeftPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.DPadLeft;
            }
        }

        public bool ButtonDownPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.DPadDown;
            }
        }

        public bool ButtonUpPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.DPadUp;
            }
        }

        public bool ButtonRightPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.DPadRight;
            }
        }

        public bool TriggerLeftPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().LeftTrigger > 0;
            }
        }

        public bool TriggerRightPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().RightTrigger > 0;
            }
        }

        public bool ButtonAPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.A;
            }
        }

        public bool ButtonBPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.B;
            }
        }

        public bool ButtonXPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.X;
            }
        }

        public bool ButtonShoulderLeftPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.LeftShoulder;
            }
        }

        public bool ButtonShoulderRightPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.RightShoulder;
            }
        }

        public bool ButtonStartPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.Menu;
            }
        }

        public bool ButtonBackPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.View;
            }
        }

        public bool ButtonYPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.Y;
            }
        }

        public bool ThumbpadLeftPressed
        {
            get
            {
                if (GenericController == null)
                {
                    return false;
                }

                return GenericController.GetCurrentReading().Buttons == GamepadButtons.LeftThumbstick;
            }
        }

        public double ThumbLeftY
        {
            get
            {
                if (GenericController == null)
                {
                    return 50;
                }

                double Reading = GenericController.GetCurrentReading().LeftThumbstickY;
                Reading += 1;
                Reading *= 100;
                Reading /= 200;
                Reading *= 100;

                return Reading;
            }
        }

        public double ThumbLeftX
        {
            get
            {
                if (GenericController == null)
                {
                    return 50;
                }

                double Reading = GenericController.GetCurrentReading().LeftThumbstickX;
                Reading += 1;
                Reading *= 100;
                Reading /= 200;
                Reading *= 100;

                return Reading;
            }
        }

        public double ThumbRightY
        {
            get
            {
                if (GenericController == null)
                {
                    return 50;
                }

                double Reading = GenericController.GetCurrentReading().RightThumbstickY;
                Reading += 1;
                Reading *= 100;
                Reading /= 200;
                Reading *= 100;

                return Reading;
            }
        }

        public double ThumbRightX
        {
            get
            {
                if (GenericController == null)
                {
                    return 50;
                }

                double Reading = GenericController.GetCurrentReading().RightThumbstickX;
                Reading += 1;
                Reading *= 100;
                Reading /= 200;
                Reading *= 100;

                return Reading;
            }
        }
    }
}

