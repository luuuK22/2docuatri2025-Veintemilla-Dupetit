using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
        public override Vector3 GetMovementInput()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // El movimiento en el plano XZ
            Vector3 dir = new Vector3(h, 0, v).normalized;
            Debug.Log($"Input: {dir}");
            return dir;
        }
    
}
