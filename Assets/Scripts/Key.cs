using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour, IInteractable
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

    public string NameReal;
    public string RequirementReal;

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
    }

    public void Interact()
    {
        if (secondItem.childCount == 1)
        {
            foreach (Transform trans in secondItem)
            {
                Transform item = Instantiate(trans, transform.position, Quaternion.identity);
                item.gameObject.AddComponent<Rigidbody>();
                Destroy(trans.gameObject);
            }

        }
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(gameObject, secondItem);

        Destroy(gameObject);

        foreach (Transform trans in secondItem)
        {
            Destroy(trans.gameObject.GetComponent<Rigidbody>());
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name;
        pressE.gameObject.SetActive(true);
    }
}
