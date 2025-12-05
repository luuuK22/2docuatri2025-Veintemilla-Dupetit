using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public float speed = 2f;
    public float rotationSpeed = 6f;

    private void Start()
    {
        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        if (player == null)
            return;

       
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0;

        
        if (lookDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }

      
        float dist = lookDir.magnitude;
        if (dist > 0.5f)
            transform.position += transform.forward * speed * Time.deltaTime;
    }

}