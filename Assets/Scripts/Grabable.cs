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
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GameObject newKey = Instantiate(gameObject, secondItem);
            Destroy(newKey.GetComponent<Rigidbody>());

            Destroy(gameObject);

            foreach (Transform trans in secondItem)
            {
                Destroy(trans.gameObject.GetComponent<Rigidbody>());
            }
        } else
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
