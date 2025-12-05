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

        Vector3 moveDir = (player.position - transform.position);
        moveDir.y = 0;

        float dist = moveDir.magnitude;

      
        if (dist > 0.5f)
            transform.position += moveDir.normalized * speed * Time.deltaTime;

      
        if (dist > 0.2f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }
    }

}