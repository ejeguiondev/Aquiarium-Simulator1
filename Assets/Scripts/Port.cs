using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Port : MonoBehaviour, IInteractable
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

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
    }

    public void Interact()
    {
        GameObject currentItem = secondItem.parent.parent.GetComponent<PlayerControler>()?.currenItem;
        if (currentItem != null)
        {
            if (Requirement == "nada")
            {
                GetComponent<Animator>().SetBool("Open", true);
                currentItem.transform.SetParent(currentItem.transform.parent);
                Destroy(currentItem);
            }
            else if (currentItem.GetComponent<IInteractable>().Name == Requirement)
            {
                GetComponent<Animator>().SetBool("Open", true);
                currentItem.transform.SetParent(currentItem.transform.parent);
                Destroy(currentItem);
            }
        } else
        {
            if (Requirement == "nada")
            {
                GetComponent<Animator>().SetBool("Open", true);
            }
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        if (Requirement == "nada")
        {
            text.text = Name;
        } else
        {
            text.text = Name + " requiere para abrirse: " + Requirement;
        }
        pressE.gameObject.SetActive(true);
    }
}
