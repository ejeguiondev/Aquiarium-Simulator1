using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Palanca : MonoBehaviour, IInteractable
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


    public string NameReal;
    public string RequirementReal;
    public Animator Port;
    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
    }

    public void Interact()
    {
        Port.SetBool("Open", true);
    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name;
        pressE.gameObject.SetActive(true);
    }

}
