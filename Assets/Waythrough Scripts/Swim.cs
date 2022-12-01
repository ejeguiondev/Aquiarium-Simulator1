using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControler playerControler;

    [SerializeField] private CharacterController characterController;

    [SerializeField] private Transform cam;

    [SerializeField] private float sinusHeight;
    [SerializeField] private float sinusSpeed;

    [SerializeField] private float sideBySideSpeed;
    [SerializeField] private float sideBySideHeight;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float swingSpeed;

    private void Start ()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update ()
    {
        if(!characterController.enabled)
        {
            return;
        }

        Vector3 p = (Mathf.Sin(Time.time * sinusSpeed) * Vector3.up) * sinusHeight;


        cam.localPosition = offset + p;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 newDirection = direction.x * transform.right + direction.z * cam.forward.normalized;

        cam.localRotation = Quaternion.Euler(cam.localRotation.eulerAngles.x, cam.localRotation.eulerAngles.y, Mathf.Sin(Time.time * sideBySideSpeed) * sideBySideHeight);
        characterController.Move(newDirection * swingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter (Collider collider)
    {
        if(collider.transform.tag != "Water")
        {
            return;
        }

        characterController.enabled = true;
        playerControler.moveBool = false;
        playerControler.rg.isKinematic = true;
        playerControler.rg.useGravity = false;
        animator.enabled = false;
    }

    private void OnTriggerExit (Collider collider)
    {
        if(collider.transform.tag != "Water")
        {
            return;
        }

        characterController.enabled = false;
        playerControler.moveBool = true;
        playerControler.rg.isKinematic = false;
        playerControler.rg.useGravity = true;
        animator.enabled = true;
    }
}
