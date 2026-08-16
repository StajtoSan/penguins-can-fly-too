using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBarrel;
    public GameObject cannonBarrelExit;
    public GameObject penguin; 

    public Vector3 mousePosition;
    private float rotation;
    private Vector3 cannonMouseAngle;

    private Camera mainCam;
    public InputActionReference fire;
    private float debugTimer=3;
    void Start()
    {
        mainCam = Camera.main;
    }
    private void OnEnable()
    {
        fire.action.started += Fire;
    }
    private void OnDisable()
    {
        fire.action.started -= Fire;
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(penguin, cannonBarrelExit.transform.position, cannonBarrelExit.transform.rotation);
    }

    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        cannonMouseAngle = new Vector3 (cannonBarrel.transform.position.x - mousePosition.x, cannonBarrel.transform.position.y - mousePosition.y,0);
        
        rotation = (Mathf.Atan2(cannonMouseAngle.y, cannonMouseAngle.x) * Mathf.Rad2Deg - 180);
        cannonBarrel.transform.rotation = Quaternion.Euler(0,0,rotation);

        if (debugTimer <= 0)
        {
            DebuggingLog();
            debugTimer = 3;
        }
        debugTimer -= Time.deltaTime;

    }
    public void DebuggingLog()
    {
        Debug.Log("cannonMouseAngle  "  + cannonMouseAngle);
        Debug.Log("mousePosition  "  + mousePosition);
        Debug.Log("cannonBarrel rotation  " + cannonBarrel.transform.rotation);
    }

}


    
