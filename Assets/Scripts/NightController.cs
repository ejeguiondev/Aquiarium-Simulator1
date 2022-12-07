using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//
public class NightController : MonoBehaviour
{
    public TMP_Text time;
    public Transform list;
    public Transform nigthsGameObject;
    public GameObject player;

    GameObject[] nightArray;
    GameObject[] currentNightTasks;

    int nigth = 0;
    string[] nightTasksString;

    private void Start()
    {
        nightTasksString = new string[list.childCount];
        nigth = 1;

        nightArray = new GameObject[nigthsGameObject.childCount];
        currentNightTasks = new GameObject[10];

        for (int i = 0; i < nightArray.Length; i++)
        {
            nightArray[i] = nigthsGameObject.GetChild(i).gameObject;
        }

        for (int i = 0; i < nightArray.Length; i++)
        {
            if (nightArray[i].gameObject == nightArray[nigth - 1].gameObject)
            {
                nightArray[i].gameObject.GetComponent<Nigth>().active = true;
            }
            else
            {
                nightArray[i].gameObject.GetComponent<Nigth>().active = false;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < nightArray[nigth - 1].transform.childCount; i++)
        {
            currentNightTasks[i] = nightArray[nigth - 1].transform.GetChild(i).gameObject;
        }

        Nigth();

    }

    void Nigth()
    {
        bool completedNigth = false;

        for (int i = 0; i < nightArray.Length; i++)
        {
            if (nightArray[i].gameObject == nightArray[nigth - 1].gameObject)
            {
                nightArray[i].gameObject.GetComponent<Nigth>().active = true;
            }
            else
            {
                nightArray[i].gameObject.GetComponent<Nigth>().active = false;
            }
        }

        for (int i = 0; i < currentNightTasks.Length; i++)
        {
            if (currentNightTasks[i] != null)
            {
                nightTasksString[i] = currentNightTasks[i].GetComponent<Task>().Name;
                list.GetChild(i).GetComponent<TMP_Text>().text = nightTasksString[i];
            }

        }

        for (int i = 0; i < currentNightTasks.Length; i++)
        {
            if (currentNightTasks[i] == null)
                break;
            if (currentNightTasks[i].GetComponent<Task>().completed)
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
            player.transform.position = new Vector3(0f, 1f, 0f);
            return;
        }

    }
}
