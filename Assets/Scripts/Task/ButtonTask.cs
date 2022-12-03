using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTask : MonoBehaviour, IItemTask, IInteractable
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

    public Transform secondItem;
    public string NameReal;
    public string RequirementReal;
    public Task taskReal;
    public GameObject[] gameObjectsModifieds;

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
        completed = false;
        task = taskReal;
    }

    public void Interact()
    {
        completed = true;
        task.completedTask();
        for (int i = 0; i < gameObjectsModifieds.Length; i++)
        {
            gameObjectsModifieds[i].SetActive(true);
        }

    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name;
        pressE.gameObject.SetActive(true);
    }
}
