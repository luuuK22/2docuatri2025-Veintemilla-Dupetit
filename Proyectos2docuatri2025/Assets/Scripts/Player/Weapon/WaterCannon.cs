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
    public AudioSource waterSound;

    private Weapon weapon;
    private float timer;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
        line.enabled = false;
    }

    void Update()
    {
        Vector3 joy3D = aimJoystick.GetMovementInput();
        Vector2 aim = new Vector2(joy3D.x, joy3D.z);

        if (aim.magnitude < 0.2f)
        {
            line.enabled = false;
            StopSound();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            PlaySound();
            Fire(aim);
        }
        else
        {
            line.enabled = false;
            StopSound();
        }
    }

    private void PlaySound()
    {
        if (!waterSound.isPlaying)
            waterSound.Play();
    }

    private void StopSound()
    {
        if (waterSound.isPlaying)
            waterSound.Stop();
    }

    private void Fire(Vector2 aim)
    {
        
        line.enabled = true;

   
        Vector3 dir = new Vector3(aim.x, 0, aim.y).normalized;

        Vector3 start = handPoint.position;
        Vector3 end = start + dir * range;

      
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        
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
