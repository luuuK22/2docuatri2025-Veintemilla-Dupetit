using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPC : Controller
{
    [Header("Mobile Joystick")]
    public JoystickScript joystick;

    private bool useMobile;

    void Awake()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        useMobile = false;
#else
        useMobile = true;
#endif
    }

    public override Vector3 GetMovementInput()
    {
        if (useMobile && joystick != null)
        {
            // ANDROID — joystick real
            return joystick.GetMovementInput();
        }
        else
        {
            // PC — WASD
            Vector2 input = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            Vector3 dir = new Vector3(input.x, 0, input.y);
            return dir.normalized;
        }
    }
}
