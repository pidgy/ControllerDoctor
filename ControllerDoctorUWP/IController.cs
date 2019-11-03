using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerDoctorUWP
{
    public interface IController
    {
        bool IsConnected();
        bool ButtonBackPressed();
        double LeftStickXPosition();
        double LeftStickYPosition();
        double RightStickXPosition();
        double RightStickYPosition();
        bool ThumbpadRightPressed();
        bool ButtonLeftPressed();
        bool ButtonDownPressed();
        bool ButtonUpPressed();
        bool ButtonRightPressed();
        bool TriggerLeftPressed();
        bool TriggerRightPressed();
        bool ButtonAPressed();
        bool ButtonBPressed();
        bool ButtonXPressed();
        bool ButtonShoulderLeftPressed();
        bool ButtonShoulderRightPressed();
        bool ButtonStartPressed();
        bool ButtonYPressed();
        bool ThumbpadLeftPressed();
        double ThumbLeftY();
        double ThumbLeftX();
        double ThumbRightY();
        double ThumbRightX();
    }
}
