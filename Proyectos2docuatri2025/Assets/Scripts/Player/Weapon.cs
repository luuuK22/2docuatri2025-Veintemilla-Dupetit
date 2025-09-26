using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // Asigna el prefab de la bala en el inspector
    [SerializeField] Transform firePoint;     // Asigna el punto de disparo en el inspector

    public void Shoot(Vector3 direction)
    {
        if (bulletPrefab == null || firePoint == null) return;

        // Instancia la bala en la posici�n y rotaci�n del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));

        // Si tu bala tiene un script para moverse, p�sale la direcci�n
        ProyectPlayer bulletScript = bullet.GetComponent<ProyectPlayer>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }
    }
}


