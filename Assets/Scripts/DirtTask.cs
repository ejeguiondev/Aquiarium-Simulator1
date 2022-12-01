using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirtTask : MonoBehaviour, IItemTask, IInteractable
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

    private void Start()
    {
        Name = NameReal;
        Requirement = RequirementReal;
        completed = false;
        task = taskReal;
    }
    
    public void Interact()
    {
        GameObject currentItem = secondItem.parent.parent.GetComponent<PlayerControler>()?.currenItem;
        if (currentItem != null)
        {
            if (currentItem.GetComponent<IInteractable>().Name == Requirement)
            {
                completed = true;
                task.completedTask();
                Destroy(GetComponent<MeshRenderer>());
                Destroy(GetComponent<Collider>());
            }
        }
    }

    public void UI(TMP_Text text, TMP_Text pressE)
    {
        text.text = Name + " limpialo con " + Requirement;
        pressE.gameObject.SetActive(true);
    }

}
