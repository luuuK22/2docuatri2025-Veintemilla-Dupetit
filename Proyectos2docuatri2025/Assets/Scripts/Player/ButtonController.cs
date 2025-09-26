using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Controller
{
    
    public override Vector3 GetMovementInput()
    {
        return _moveDir;
    }

    public void MoveUp()
    {
        _moveDir = Vector3.forward;
    }

    public void MoveDown()
    {
        _moveDir = Vector3.back;
    }

    public void MoveRight()
    {
        _moveDir = Vector3.right;
    }

    public void MoveLeft()
    {
        _moveDir = Vector3.left;
    }

    public void Static()
    {
        _moveDir = Vector3.zero;
    }
}


