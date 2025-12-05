using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricStaff : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform handPoint;
    [SerializeField] private JoystickScript aimJoystick;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private GameObject boltPrefab;

    [Header("Ajustes")]
    [SerializeField] private float pointerDistance = 3f;

    private GameObject pointerInstance;
    private Weapon weapon;

    private bool isAiming = false;

    private Vector3 pointerPosition;
    private Vector3 aimDirection;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Start()
    {
      
        pointerInstance = Instantiate(pointerPrefab);
        pointerInstance.SetActive(false);

        pointerPosition = handPoint.position;
    }

    private void Update()
    {
        Vector3 joyDir3D = aimJoystick.GetMovementInput();
        Vector2 joy2D = new Vector2(joyDir3D.x, joyDir3D.z);

     
        if (joy2D.magnitude < 0.1f)
        {
            if (isAiming)
                ReleaseBolt();

            isAiming = false;
            pointerInstance.SetActive(false);
            return;
        }

     
        isAiming = true;

 
        if (!pointerInstance.activeSelf)
        {
            pointerInstance.SetActive(true);

            pointerPosition = handPoint.position;
            pointerInstance.transform.position = pointerPosition;
        }

        aimDirection = new Vector3(joy2D.x, 0, joy2D.y).normalized;

        pointerPosition = handPoint.position + aimDirection * pointerDistance;
        pointerInstance.transform.position = pointerPosition;
    }


    private void ReleaseBolt()
    {
        
        GameObject bolt = Instantiate(boltPrefab, pointerPosition, Quaternion.LookRotation(aimDirection));

        ElectricBolt b = bolt.GetComponent<ElectricBolt>();
        b.weapon = weapon;

        b.direction = aimDirection;

        pointerInstance.SetActive(false);
    }

}
