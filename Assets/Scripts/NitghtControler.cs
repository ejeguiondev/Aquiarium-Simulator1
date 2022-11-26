using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NitghtControler : MonoBehaviour
{
    public TMP_Text time;
    public Transform list;
    public string[] nigthsTask;
    public GameObject[] taskGameObjects;
    public int nigth = 1;
    string timeNumber;

    private void Start()
    {
        nigthsTask = new string[list.childCount];
        taskGameObjects = new GameObject[1];
    }

    private void Update()
    {
        if (nigth == 1)
        {
            nigth1();
        }

        for (int i = 0; i < list.childCount; i++)
        {
            list.GetChild(i).gameObject.GetComponent<TMP_Text>().text = nigthsTask[i];
        }
    }

    void nigth1()
    {
        nigthsTask[0] = "Limpiar los cristales";
        nigthsTask[1] = "Encender las luces de los tanques/peceras";
        nigthsTask[2] = "Activar el mecanismo de las burbujas";
    }

}
