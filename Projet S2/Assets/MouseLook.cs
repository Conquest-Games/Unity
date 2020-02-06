using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MouseLook : MonoBehaviour
{

    public float Sensitivity = 100f;

    public Transform CamController;

    private float xRotation; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        /*xRotation -= Y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   -> censé bouger la cam verticalement
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);*/

        CamController.Rotate(Vector3.up * X);
    }
}
