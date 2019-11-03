using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandonPotter.XBox;

namespace ControllerDoctorUWP
{
    public class XboxController : IController
    {
        public XBoxController Controller;
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        XBoxControllerWatcher watcher;
        
        public XboxController()
        {
            this.Controller = null;

            watcher = new XBoxControllerWatcher();

            watcher.ControllerConnected += (c) =>
            {
                OnConnected(c);
            };

            watcher.ControllerDisconnected += (c) =>
            {
                OnDisconnected(c);
            };
        }

        protected virtual void OnConnected(XBoxController x)
        {
            Connected.Invoke(this, EventArgs.Empty);
            this.Controller = x;
        }

        protected virtual void OnDisconnected(XBoxController x)
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
            foreach (XBoxController c in XBoxController.GetConnectedControllers())
            {
                OnConnected(c);
                return;
            }
        }

        public bool ButtonBackPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonBackPressed;
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

            return Controller.ThumbpadRightPressed;
        }

        public bool ButtonLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonLeftPressed;
        }

        public bool ButtonDownPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonDownPressed;
        }

        public bool ButtonUpPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonUpPressed;
        }

        public bool ButtonRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonRightPressed;
        }

        public bool TriggerLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.TriggerLeftPressed;
        }

        public bool TriggerRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.TriggerRightPressed;
        }

        public bool ButtonAPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonAPressed;
        }

        public bool ButtonBPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonBPressed;
        }

        public bool ButtonXPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonXPressed;
        }

        public bool ButtonShoulderLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonShoulderLeftPressed;
        }

        public bool ButtonShoulderRightPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonShoulderRightPressed;
        }

        public bool ButtonStartPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonStartPressed;
        }

        public bool ButtonYPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ButtonYPressed;
        }

        public bool ThumbpadLeftPressed()
        {
            if (Controller == null)
            {
                return false;
            }

            return Controller.ThumbpadLeftPressed;
        }

        public double ThumbLeftY()
        {
            if (Controller == null)
            {
                return 50;
            }

            return Controller.ThumbLeftY;
        }

        public double ThumbLeftX()
        {
            if (Controller == null)
            {
                return 50;
            }

            return Controller.ThumbLeftX;
        }

        public double ThumbRightY()
        {
            if (Controller == null)
            {
                return 50;
            }

            return Controller.ThumbRightY;
        }

        public double ThumbRightX()
        {
            if (Controller == null)
            {
                return 50;
            }

            return Controller.ThumbRightX;
        }
    }

}
