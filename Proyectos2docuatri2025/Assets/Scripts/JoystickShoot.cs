using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickShoot : MonoBehaviour, IDragHandler, IEndDragHandler
{

    Vector3 initialPosition;
    [SerializeField] float maxMagnitude = 75;
    public Weapon weapon;
    public Transform player;  // Player a rotar

    Vector2 shootInput;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - (Vector2)initialPosition;
        delta = Vector2.ClampMagnitude(delta, maxMagnitude);

        transform.position = initialPosition + (Vector3)delta;
        shootInput = delta.normalized;

        RotatePlayer();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
        shootInput = Vector2.zero;
    }

    void RotatePlayer()
    {
        if (shootInput.sqrMagnitude < 0.01f) return;

        // Convertimos joystick 2D → dirección en el plano XZ
        Vector3 dir = new Vector3(shootInput.x, 0, shootInput.y);

        Quaternion targetRot = Quaternion.LookRotation(dir);
        player.rotation = Quaternion.Slerp(player.rotation, targetRot, Time.deltaTime * 12f);
    }
}

