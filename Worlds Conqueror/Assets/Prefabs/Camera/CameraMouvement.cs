using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{


    public float ScrollSpeed = 15;

    public float ScrollEdge = 0.1f;

    public float PanSpeed = 100;

    public Vector2 zoomRange = new Vector2(-10, 100);

    public float CurrentZoom = 0;

    public float ZoomZpeed = 1;

    public float ZoomRotation = 1;

    public Vector2 zoomAngleRange = new Vector2(20, 70);

    public float rotateSpeed = 1;

    private Vector3 initialPosition;

    private Vector3 initialRotation;

    private int i = 0;
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
    }


    void Update()
    {

        //move the camera
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * PanSpeed, Space.Self);
        }
        else if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * -PanSpeed, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            //if 
        }

        if (Input.GetKey("z") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed, Space.Self);
        }
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -PanSpeed, Space.Self);
        }

        //rotate the camera
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotateSpeed, Space.World);
            i += 1;
        }
        else if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
            i -= 1;
        }

        //reset the rotation
        if (Input.GetKey(KeyCode.Mouse2))
        {
            while ( i != 0)
            {
                if (i > 0)
                {
                    i -= 1;
                    transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
                }
                else
                {
                    i += 1;
                    transform.Rotate(Vector3.up * Time.deltaTime * -rotateSpeed, Space.World);
                }
            }
        }

        // zoom in/out
            CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

        CurrentZoom = Mathf.Clamp(CurrentZoom, zoomRange.x, zoomRange.y);

        transform.position = new Vector3(transform.position.x, transform.position.y - (transform.position.y - (initialPosition.y + CurrentZoom)) * 0.1f, transform.position.z);

        
        float x = transform.eulerAngles.x - (transform.eulerAngles.x - (initialRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;
        x = Mathf.Clamp(x, zoomAngleRange.x, zoomAngleRange.y);
        
        transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
        
    }
}
