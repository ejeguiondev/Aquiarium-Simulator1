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
        foreach(Transform trans in secondItem)
        {
            if (trans.GetComponent<IInteractable>()?.Name == Requirement)
            {
                GetComponent<Animator>().SetBool("Open", true);
            }
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name + " requiere para abrirse: " + Requirement;
        pressE.gameObject.SetActive(true);
    }
}
