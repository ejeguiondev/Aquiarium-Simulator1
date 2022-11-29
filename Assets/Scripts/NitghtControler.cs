using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NitghtControler : MonoBehaviour
{
    public TMP_Text time;
    public Transform list;
    public Transform nigthsGameObject;

    int nigth = 0;
    string[] nigthsTask;
    GameObject[] nigths;

    private void Start()
    {
        nigthsTask = new string[list.childCount];
        nigths = new GameObject[nigthsGameObject.childCount];
        nigth = 1;
    }

    private void Update()
    {
        for (int i = 0; i < nigths.Length; i++)
        {
            nigths[i] = nigthsGameObject.GetChild(0).gameObject;
        }

    }
}
