using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public bool completed;
    public string Name;
    public GameObject[] usingGameObject;
    public GameObject completedTaskList;


    private void Update()
    {
        for (int i = 0; i < usingGameObject.Length; i++)
        {
            usingGameObject[i].SetActive(true);
        }
        if (completed)
            completedTaskList.SetActive(true);
    }
    public void completedTask()
    {
        for (int i = 0; i < usingGameObject.Length; i++)
        {
            IItemTask itemTask = usingGameObject[i].GetComponent<IItemTask>();
            if (itemTask != null)
            {
                if (itemTask.completed)
                {
                    completed = true;
                }
                else
                {
                    completed = false;
                    break;
                }
            }
        }

        if (completed)
            completedTaskList.SetActive(true);

    }

}
