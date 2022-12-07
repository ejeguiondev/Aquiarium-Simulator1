using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripttrigerpepe : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             aparecerEnemigo();
        }
    }

    void aparecerEnemigo()
    {
        Enemy.SetActive(true);
    }
}
