using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smoothSpeed = 0.125f;
    public float minDistance = 0.5f;   
    public LayerMask collisionMask;    

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;

        
        Vector3 direction = desiredPosition - player.position;
        float distance = direction.magnitude;

       
        if (Physics.Raycast(player.position, direction.normalized, out RaycastHit hit, distance, collisionMask))
        {
            
            desiredPosition = hit.point - direction.normalized * minDistance;
        }

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}




