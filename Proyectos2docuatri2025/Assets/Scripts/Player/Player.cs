using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Controller controller;

    [Header("Movement Settings")]
    public float speed = 5f;

    private Vector3 moveDir;

    void Update()
    {
        moveDir = controller.GetMovementInput();

        // Movimiento
        if (moveDir != Vector3.zero)
        {
            transform.position += moveDir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speed *= multiplier;
    }


}

