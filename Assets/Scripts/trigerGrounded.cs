using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerGrounded : MonoBehaviour
{
    public static bool isGrounded = true;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

}
