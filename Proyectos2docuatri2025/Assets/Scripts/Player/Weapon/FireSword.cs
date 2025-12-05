using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSword : MonoBehaviour
{
    [SerializeField] private Transform handPoint;
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private float attackCooldown = 0.4f;

    [Header("Joystick de ataque")]
    [SerializeField] private JoystickScript aimJoystick;

    private float timer;
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Dirección del joystick
        Vector3 joyDir3D = aimJoystick.GetMovementInput();
        Vector2 aim = new Vector2(joyDir3D.x, joyDir3D.z);

        // si no está moviendo el stick → no atacar
        if (aim.magnitude < 0.2f)
            return;

        // atacar continuamente si arrastra el joystick
        if (timer <= 0)
        {
            DoSlash(aim);
            timer = attackCooldown;
        }
    }

    private void DoSlash(Vector2 aim)
    {
        Vector3 dir = new Vector3(aim.x, 0, aim.y).normalized;

        GameObject slash = Instantiate(
            slashPrefab,
            handPoint.position,
            Quaternion.LookRotation(dir)
        );

        FireSash dmg = slash.GetComponent<FireSash>();
        dmg.weapon = weapon;
    }
}
