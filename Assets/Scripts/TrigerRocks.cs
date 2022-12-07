using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrigerRocks : MonoBehaviour, IInteractable, IItemTask
{
    public bool completed
    {
        get;
        private set;
    }
    public Task task
    {
        get;
        private set;
    }
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
        GameObject currentItem = secondItem.parent.parent.GetComponent<Inventory>()?.currenItem;
        if (currentItem != null)
        {
            if (Requirement == "nada")
            {
                completed = true;
                Destroy(GetComponent<Collider>());
            }
            else if (currentItem.GetComponent<IInteractable>().Name == Requirement)
            {
                completed = true;
                Destroy(GetComponent<Collider>());
                currentItem.transform.SetParent(currentItem.transform.parent);
                Destroy(currentItem);
            }
        }
        else
        {
            if (Requirement == "nada")
            {
                completed = true;
                Destroy(GetComponent<Collider>());
            }
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = "Poner rocas";
        pressE.gameObject.SetActive(true);
    }

}
