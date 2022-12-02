using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Grabable : MonoBehaviour, IInteractable
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

    public Rigidbody rb;
    public Transform secondItem;
    public Sprite icon;

    public string NameReal;
    public string RequirementReal;

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
    }

    public void Interact()
    {
        if (secondItem.childCount != 5)
        {
            GameObject grabable = gameObject;

            grabable.GetComponent<Rigidbody>().isKinematic = true;
            grabable.GetComponent<Collider>().enabled = false;

            grabable.transform.SetParent(secondItem);

            grabable.transform.localPosition = Vector3.zero;
            grabable.transform.localRotation = Quaternion.identity;
        } 
        else
        {
            Debug.Log("sin espacio!");
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name;
        pressE.gameObject.SetActive(true);
    }
}