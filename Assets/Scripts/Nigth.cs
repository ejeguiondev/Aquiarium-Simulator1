using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nigth : MonoBehaviour
{
    public bool active = true;
    public GameObject[] gameObjects;
    public GameObject[] gameObjectsInactive;
    int counter = 0;

    private void Update()
    {
        if (active)
        {
            if (counter == 0)
            {
                for (int i = 0; i < gameObjectsInactive.Length; i++)
                {
                    gameObjectsInactive[i].SetActive(false);
                }
                counter = 1;
            }
        }

        if (!active)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
        } else
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }

    }
}
