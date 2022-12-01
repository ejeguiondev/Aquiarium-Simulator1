using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IItemTask
{
    bool completed { get; }
    Task task { get; }
}

public class PlayerControler : MonoBehaviour
{
    public TMP_Text textItem;
    public TMP_Text textPressE;
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

    public GameObject List;
    public GameObject Lanter;
    public GameObject ligthLanter;
    bool ligth = true;
    bool lanter = true;
    bool endListAnim = false;

    public Image staminaUI;
    float stamina = 1;
    float counterStamina = 0;

    public GameObject[] arrayInventory;
    public GameObject currenItem;
    public int numberItem = 0;
    public int numberSlots = 5;

    // Start is called before the first frame update
    void Start()
    {
        rotacionSensibility = 700f;
        rg = GetComponent<Rigidbody>();
        arrayInventory = new GameObject[5];
        moveBool = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Latern ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ligth == true)
            {
                ligthLanter.SetActive(false);
                ligth = false;
            }
            else
            {
                ligthLanter.SetActive(true);
                ligth = true;
            }
        }
    }

    private void Update()
    {
        Latern();
        Drop();
        Jump();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (lanter)
            {
                endListAnim = false;
                StartCoroutine("EndListAnim");
                List.SetActive(true);
                List.transform.parent.GetComponent<Animator>().SetBool("List", true);
                Lanter.SetActive(false);
                lanter = false;
            }
            else
            {
                if (endListAnim)
                {
                    List.transform.parent.GetComponent<Animator>().SetBool("List", false);
                    List.transform.parent.GetComponent<Animator>().SetBool("EndList", true);
                    StartCoroutine("EndList");
                }
            }
        }
        

        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                numberItem = i;
            }
        }

        for (int i = 0; i < arrayInventory.Length; i++)
        {
            if (arrayInventory[i] == arrayInventory[numberItem])
            {
                currenItem = arrayInventory[i];
            }
        }

        detectedItem();
        orderInventory();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && trigerGrounded.isGrounded)
        {
            rg.velocity = new Vector3(rg.velocity.x, jumpSpeed, rg.velocity.z);
        }
    }

    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SecondItem.childCount > 0)
        {
            if (currenItem != null)
            {
                GameObject item = Instantiate(currenItem.gameObject, transform.position + transform.forward, Quaternion.identity);
                item.gameObject.AddComponent<Rigidbody>();

                for (int i = 0; i < arrayInventory.Length; i++)
                {
                    arrayInventory[i] = null;
                }

                foreach (Transform trans in SecondItem.transform)
                {
                    if (trans.gameObject == currenItem)
                    {
                        trans.SetParent(SecondItem.parent);
                        Destroy(trans.gameObject);
                        break;
                    }
                }
            }

        }
    }

    private void FixedUpdate()
    {
        if (moveBool == true)
        {
            move();
        } else
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
        rotateInput.x = Input.GetAxis("Mouse X") * rotacionSensibility * Time.deltaTime;
        rotateInput.y = Input.GetAxis("Mouse Y") * rotacionSensibility * Time.deltaTime;
        // hacer que no se pase de vista mirando hacia arriba
        camVerticalAngle += rotateInput.y;
        camVerticalAngle = Mathf.Clamp(camVerticalAngle, -70, 70);
        // agregar
        transform.Rotate(Vector3.up * rotateInput.x);
        playerCam.transform.localRotation = Quaternion.Euler(-camVerticalAngle, 0, 0);
    }
    void move()
    {
        if(!moveBool)
        {
            return;
        }

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        Vector3 direccion = (transform.forward * ver + transform.right * hor).normalized;
        if (hor != 0 || ver != 0)
        {
            if (!run)
            {
                velocity = direccion * walkSpeed;
                playerCam.GetComponent<Animator>().SetBool("Walk", true);
                playerCam.GetComponent<Animator>().SetBool("Run", false);
            }
            else
            {
                if (stamina < 0.01f)
                {
                    velocity = direccion * walkSpeed;
                    playerCam.GetComponent<Animator>().SetBool("Walk", true);
                    playerCam.GetComponent<Animator>().SetBool("Run", false);

                    Debug.Log("No te queda stamina!");
                }
                else
                {
                    velocity = direccion * runSpeed;
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
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, rayDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<IInteractable>()?.Interact();
            }
            hit.collider.GetComponent<IInteractable>()?.UI(textItem, textPressE);
            Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * rayDistance, Color.red);

        }

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null)
            {
                textItem.text = "";
                textPressE.gameObject.SetActive(false);
            }
        }

    }
    void orderInventory()
    {
        for (int i = 0; i < SecondItem.childCount; i++)
        {
            if (SecondItem.GetChild(i).gameObject != currenItem)
            {
                SecondItem.GetChild(i).gameObject.SetActive(false);
            } else
            {
                SecondItem.GetChild(i).gameObject.SetActive(true);
            }

            if (arrayInventory[i] == null)
            {
                GameObject item = SecondItem.GetChild(i).gameObject;
                arrayInventory[i] = item;
            }

        }

    }
    IEnumerator EndList()
    {
        yield return new WaitForSeconds(1.2f);
        List.transform.parent.GetComponent<Animator>().SetBool("EndList", false);
        List.SetActive(false);
        Lanter.SetActive(true);
        lanter = true;
    }

    IEnumerator EndListAnim()
    {
        yield return new WaitForSeconds(1f);
        endListAnim = true;
    }
}