using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NitghtControler : MonoBehaviour
{
    public TMP_Text time;
    public Transform list;
    public Transform nigthsGameObject;

    GameObject[] nigthsArray;
    GameObject[] currentTasksNigth;

    int nigth = 0;
    string[] nigthsTaskString;

    private void Start()
    {
        nigthsTaskString = new string[list.childCount];
        nigth = 1;

        nigthsArray = new GameObject[nigthsGameObject.childCount];
        currentTasksNigth = new GameObject[10];

        for (int i = 0; i < nigthsArray.Length; i++)
        {
            nigthsArray[i] = nigthsGameObject.GetChild(i).gameObject;
        }

        for (int i = 0; i < nigthsArray.Length; i++)
        {
            if (nigthsArray[i].gameObject == nigthsArray[nigth - 1].gameObject)
            {
                nigthsArray[i].gameObject.SetActive(true);
            }
            else
            {
                nigthsArray[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < nigthsArray[nigth - 1].transform.childCount; i++)
        {
            currentTasksNigth[i] = nigthsArray[nigth - 1].transform.GetChild(i).gameObject;
        }

        Nigth();

    }

    void Nigth()
    {
        bool completedNigth = false;

        for (int i = 0; i < nigthsArray.Length; i++)
        {
            if (nigthsArray[i].gameObject == nigthsArray[nigth - 1].gameObject)
            {
                nigthsArray[i].gameObject.SetActive(true);
            }else
            {
                nigthsArray[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < currentTasksNigth.Length; i++)
        {
            if (currentTasksNigth[i] != null)
            {
                nigthsTaskString[i] = currentTasksNigth[i].GetComponent<Task>().Name;
                list.GetChild(i).GetComponent<TMP_Text>().text = nigthsTaskString[i];
            }

        }

        for (int i = 0; i < currentTasksNigth.Length; i++)
        {
            if (currentTasksNigth[i] == null)
                break;
            if (currentTasksNigth[i].GetComponent<Task>().completed)
                completedNigth = true;
            else
            {
                completedNigth = false;
                return;
            }
        }

        if (completedNigth)
        {
            nigth += 1;
            return;
        }

    }
}
