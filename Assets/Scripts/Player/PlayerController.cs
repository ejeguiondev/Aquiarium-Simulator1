using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//
public class PlayerController : MonoBehaviour
{
    public Transform SecondItem;
    public Camera playerCam;
    public Vector3 rotateInput = Vector3.zero;
    public float rotacionSensibility;
    public Vector3 moveInput = Vector3.zero;
    private float camVerticalAngle;
    public int rayDistance;

    public Rigidbody rg;
    public bool moveBool;

    float walkSpeed = 8;
    float runSpeed = 15;
    bool run;
    public float jumpSpeed;

    public GameObject List; // Lista

    public Latern latern;

    bool lightOn = true;
    bool onLatern = true;
    bool endListAnim = false;

    public Image staminaUI;
    float stamina = 1;
    float counterStamina = 0;

    private SelectionManager selectionManager;

    // Start is called before the first frame update
    void Start()
    {
        selectionManager = GetComponent<SelectionManager>();

        rotacionSensibility = 700f;
        rg = GetComponent<Rigidbody>();
        moveBool = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Latern()
    {
        if (Input.GetKeyDown(KeyCode.F) && !List.activeInHierarchy)
        {
            latern?.Toggle();
        }
    }

    private void Update()
    {
        Latern();
        Jump();

        // Alternar entre la linterna y lista

        // Al presionar la letra 't'
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Si la linterna esta en uso
            if (onLatern)
            {
                // La animacion de guardado de la lista no ha terminado
                endListAnim = false;
                // Iniciar corotunia del f
                StartCoroutine("EndListAnim");
                // Activar lista
                List.SetActive(true);
                // Activar la animacion del padre de la lista
                List.transform.parent.GetComponent<Animator>().SetBool("List", true);
                // Desactivar la linterna
                latern.gameObject.SetActive(false);
                // La linterna no estara en uso
                onLatern = false;
            }
            // Por el contrario, si la linterna no estaa en uso
            else
            {
                // Si la animacion de guardado de la lista no ha terminado
                if (endListAnim)
                {
                    //
                    List.transform.parent.GetComponent<Animator>().SetBool("List", false);
                    List.transform.parent.GetComponent<Animator>().SetBool("EndList", true);
                    // Iniciar corutina
                    StartCoroutine("EndList");
                }
            }
        }

        detectedItem();
        //orderInventory();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && trigerGrounded.isGrounded)
        {
            rg.velocity = new Vector3(rg.velocity.x, jumpSpeed, rg.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        if (moveBool == true)
        {
            move();
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            rg.velocity = velocity;
            playerCam.GetComponent<Animator>().SetBool("Walk", false);
            playerCam.GetComponent<Animator>().SetBool("Run", false);
        }
        Look();

    }

    void Look()
    {
        // agarrar el angulo X e Y
        rotateInput.x = Input.GetAxis("Mouse X") * rotacionSensibility * Time.fixedDeltaTime;
        rotateInput.y = Input.GetAxis("Mouse Y") * rotacionSensibility * Time.fixedDeltaTime;
        // hacer que no se pase de vista mirando hacia arriba
        camVerticalAngle += rotateInput.y;
        camVerticalAngle = Mathf.Clamp(camVerticalAngle, -70, 70);
        // agregar
        transform.Rotate(Vector3.up * rotateInput.x);
        playerCam.transform.localRotation = Quaternion.Euler(-camVerticalAngle, 0, 0);
    }
    void move()
    {
        if (!moveBool)
        {
            return;
        }

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
        if (hor != 0 || ver != 0)
        {
            if (!run)
            {
                velocity = direction * walkSpeed;
                playerCam.GetComponent<Animator>().SetBool("Walk", true);
                playerCam.GetComponent<Animator>().SetBool("Run", false);
            }
            else
            {
                if (stamina < 0.01f)
                {
                    velocity = direction * walkSpeed;
                    playerCam.GetComponent<Animator>().SetBool("Walk", true);
                    playerCam.GetComponent<Animator>().SetBool("Run", false);

                    Debug.Log("No te queda stamina!");
                }
                else
                {
                    velocity = direction * runSpeed;
                    playerCam.GetComponent<Animator>().SetBool("Run", true);
                    playerCam.GetComponent<Animator>().SetBool("Walk", false);
                }
            }
        }
        else
        {
            playerCam.GetComponent<Animator>().SetBool("Run", false);
            playerCam.GetComponent<Animator>().SetBool("Walk", false);
            run = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && hor != 0 || Input.GetKeyDown(KeyCode.LeftShift) && ver != 0)
            run = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift) && hor != 0 || Input.GetKeyUp(KeyCode.LeftShift) && ver != 0)
            run = false;

        if (run)
        {
            counterStamina += 1 * Time.deltaTime;
            if (counterStamina > 0.05f)
            {
                if (stamina > 0)
                    stamina -= 0.01f;
                counterStamina = 0;
            }
        }
        else
        {
            counterStamina += 1 * Time.deltaTime;
            if (counterStamina > 0.05f)
            {
                if (stamina < 1)
                    stamina += 0.01f;
                counterStamina = 0;
            }
        }

        staminaUI.fillAmount = stamina;

        velocity.y = rg.velocity.y;
        rg.velocity = velocity;
    }

    void detectedItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectionManager.selection?.GetComponent<IInteractable>()?.Interact();
        }
    }

    IEnumerator EndList()
    {
        yield return new WaitForSeconds(1.2f);
        List.transform.parent.GetComponent<Animator>().SetBool("EndList", false);
        List.SetActive(false); // Desactivar lista
        latern.gameObject.SetActive(true); // Activar linterna
        onLatern = true; // La linterna esta en uso
    }

    IEnumerator EndListAnim()
    {
        yield return new WaitForSeconds(1f);
        endListAnim = true;
    }
}
