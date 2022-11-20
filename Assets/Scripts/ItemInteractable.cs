using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    public string Name;
    public string Use;
    public GameObject objetc;
    public Quaternion rotation;

    public void MoveObject()
    {
        if (objetc.GetComponent<Animator>())
        {
            objetc.GetComponent<Animator>().SetBool("Open", true);
        }
        else
        {
            objetc.transform.rotation = rotation;
        }

    }
}
