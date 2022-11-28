using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float sinusHeight;
    [SerializeField] private float sinusSpeed;

    private float xRotation;
    private float yRotation;
    private float zRotation;

    private float zTargetRotation;

    private float velocity;

    private float runningElapsedTime;

    private Vector3 movementInput;

    private Vector3 GetMovementInput()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private Vector3 GetRotationInput()
    {
        return new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Transform camera = Camera.main.transform;
        Transform body = transform;

        //camera.localPosition = offset;

        Vector3 cameraRight = camera.right;
        Vector3 cameraForward = camera.forward;

        cameraForward.y = 0;
        cameraRight.y = 0;

        movementInput = GetMovementInput();
        Vector3 movementInputModified = movementInput.x * cameraRight + movementInput.z * cameraForward;

        Vector3 movement = movementInputModified * movementSpeed;
        Vector3 rotation = GetRotationInput() * rotationSpeed;

        xRotation = Mathf.Clamp(xRotation - rotation.y, -90f, 90f);
        yRotation = yRotation + rotation.x;

        body.rotation = Quaternion.Euler(0, yRotation, 0);

        characterController.Move(movement * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Transform camera = Camera.main.transform;


        zTargetRotation = (Mathf.Sin(Time.time * sinusSpeed) * sinusHeight);
        Debug.Log(zTargetRotation);
        zRotation = Mathf.Lerp(0, zTargetRotation, runningElapsedTime);

        if (movementInput.magnitude > 0)
        {
            runningElapsedTime += Time.fixedDeltaTime;
            runningElapsedTime = Mathf.Clamp(runningElapsedTime, 0, 1);
            //zRotation = (Mathf.Sin(runningElapsedTime * sinusSpeed) * sinusHeight);
        }
        else
        {
            runningElapsedTime = 0;
            //zRotation = Mathf.SmoothDamp(zRotation, 0, ref velocity, 0.5f);
        }

        camera.localRotation = Quaternion.Euler(xRotation, 0, zRotation);
    }
}
