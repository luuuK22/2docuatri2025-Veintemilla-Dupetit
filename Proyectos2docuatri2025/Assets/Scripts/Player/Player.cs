using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] Controller controller;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 movement = controller.GetMovementInput();

        // Movimiento
        transform.position += movement * speed * Time.deltaTime;

        // Rotaci�n hacia la direcci�n de movimiento (si hay movimiento)
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }




}

