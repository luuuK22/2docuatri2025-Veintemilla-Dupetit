using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCannon : MonoBehaviour
{
    [SerializeField] private Transform handPoint;
    [SerializeField] private LineRenderer line;
    [SerializeField] private JoystickScript aimJoystick;
    [SerializeField] private float range = 15f;
    [SerializeField] private float tickRate = 0.1f;

    private Weapon weapon;
    private float timer;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
        line.enabled = false;
    }

    void Update()
    {
        // Lectura del joystick
        Vector3 joy3D = aimJoystick.GetMovementInput();
        Vector2 aim = new Vector2(joy3D.x, joy3D.z);

        // Si no está apuntando, apagamos el beam
        if (aim.magnitude < 0.2f)
        {
            line.enabled = false;
            return;
        }

        // Botón de ataque presionado
        if (Input.GetMouseButton(0))
        {
            Fire(aim);
        }
        else
        {
            line.enabled = false;
        }
    }

    private void Fire(Vector2 aim)
    {
        line.enabled = true;

        // Dirección del rayo según joystick
        Vector3 dir = new Vector3(aim.x, 0, aim.y).normalized;

        Vector3 start = handPoint.position;
        Vector3 end = start + dir * range;

        // Dibujar línea
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        // Hacer daño a enemigos
        Ray ray = new Ray(start, dir);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.5f, out hit, range))

        {
            end = hit.point;
            line.SetPosition(1, end);
            Debug.Log("Impacto con: " + hit.collider.name);

            Enemy e = hit.collider.GetComponent<Enemy>();
            if (e != null)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    weapon.Attack(e);
                    timer = tickRate;
                }
            }
        }
    }
}
