using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public string Name;
    public Rigidbody rb;

    private void Start()
    {
    }

    public void GrabItem(Transform secondItem)
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(gameObject, secondItem);
        Destroy(gameObject);
    }

}