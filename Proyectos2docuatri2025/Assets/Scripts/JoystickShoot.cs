using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickShoot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    Vector3 initialPosition;
    [SerializeField] float maxMagnitude = 75;
    public Weapon weapon; // Asigna el arma desde el inspector

    Vector3 shootDir;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        shootDir = Vector3.ClampMagnitude((Vector3)eventData.position - initialPosition, maxMagnitude);
        transform.position = initialPosition + shootDir;

        // Si el stick se mueve, dispara en esa dirección
        if (shootDir.magnitude > 0.1f && weapon != null)
        {
            Vector3 dir = new Vector3(shootDir.x, 0, shootDir.y).normalized;
            weapon.Shoot(dir); // Asegúrate que tu método Shoot acepte una dirección
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
        shootDir = Vector3.zero;
    }
}

