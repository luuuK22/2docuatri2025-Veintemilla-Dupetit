using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.5f;

    private Player movement;
    private bool isSlowed = false;

    private void Awake()
    {
        movement = GetComponent<Player>(); 
    }

    public void ApplySlow(float duration)
    {
        if (!isSlowed)
            StartCoroutine(SlowCoroutine(duration));
    }

    private IEnumerator SlowCoroutine(float duration)
    {
        isSlowed = true;

        float originalSpeed = movement.speed;
        movement.speed *= slowMultiplier;

        yield return new WaitForSeconds(duration);

        movement.speed = originalSpeed;
        isSlowed = false;
    }
}
