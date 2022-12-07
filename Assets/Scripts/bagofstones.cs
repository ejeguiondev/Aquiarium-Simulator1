using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bagofstones : MonoBehaviour, IInteractable
{
    public string Name
    {
        get;
        private set;
    }
    public string Requirement
    {
        get;
        private set;
    }


    public Transform secondItem;
    public string NameReal;
    public string RequirementReal;
    public GameObject rock;

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
    }

    public void Interact()
    {
        if (secondItem.childCount != 5)
        {
            GameObject cloneRock = Instantiate(rock);

            cloneRock.GetComponent<Rigidbody>().isKinematic = true;
            cloneRock.GetComponent<Collider>().enabled = false;

            cloneRock.transform.SetParent(secondItem);

            cloneRock.transform.localPosition = Vector3.zero;
            cloneRock.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.Log("sin espacio!");
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        if (Requirement == "nada")
        {
            text.text = Name;
        }
        else
        {
            text.text = Name;
        }
        pressE.gameObject.SetActive(true);
    }

}
