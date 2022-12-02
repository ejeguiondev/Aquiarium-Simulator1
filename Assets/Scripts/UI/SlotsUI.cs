using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotsUI : MonoBehaviour
{
    public Inventory playerScript;

    private void Update()
    {
        int numberItem = playerScript.numberItem;
        GameObject[] array = playerScript.arrayInventory;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == numberItem)
            {
                Outline OutlineItem = transform.GetChild(i).gameObject.GetComponent<Outline>();
                OutlineItem.enabled = true;
            } else
            {
                Outline OutlineItem = transform.GetChild(i).gameObject.GetComponent<Outline>();
                OutlineItem.enabled = false;
            }

            if (array[i] != null)
            {
                Image image = transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>();
                image.sprite = array[i].gameObject.GetComponent<Grabable>().icon;
            } else
            {
                Image image = transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>();
                image.sprite = null;
            }

        }

    }

}
