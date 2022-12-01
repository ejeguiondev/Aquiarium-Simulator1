using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform body;
    
    [SerializeField] private float sensibility = 2f;

    private float xAngle;
    private float yAngle;

    private void Start ()
    {
        xAngle = cam.localRotation.eulerAngles.x;
        yAngle = body.rotation.eulerAngles.y;
    }

    private void Update ()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        float minXAngle = -90f;
        float maxXAngle = 90f;

        xAngle = Mathf.Clamp(xAngle - (vertical * sensibility), minXAngle, maxXAngle);
        yAngle = yAngle + (horizontal * sensibility);

        cam.localRotation = Quaternion.Euler(xAngle, 0, 0);
        body.rotation = Quaternion.Euler(0, yAngle, 0);
    }
}
