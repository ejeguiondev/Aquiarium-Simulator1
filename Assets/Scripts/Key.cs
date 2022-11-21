using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public string Name
    {
        get;
    }
    public string Requirement
    {
        get;
    }

    public Rigidbody rb;
    public Transform secondItem;

    public string NameReal;
    public string RequirementReal;

    public void Interact()
    {
        if (secondItem.childCount == 1)
        {
            foreach (Transform trans in secondItem)
            {
                Transform item = Instantiate(trans, transform.position, Quaternion.identity);
                item.gameObject.AddComponent<Rigidbody>();
                Destroy(trans.gameObject);
            }

        }
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(gameObject, secondItem);
        Destroy(gameObject);
        foreach (Transform trans in secondItem)
        {
            Destroy(trans.gameObject.GetComponent<Rigidbody>());
        }

    }

}
