using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public interface IInteractable
{
    public string Name { get; }
    public string Requirement { get; }
    void Interact();
    void UI(TMP_Text text, TMP_Text pressE);
}
public class Interactable : MonoBehaviour, IInteractable
{
    public string Name
    {
        get;

        private set;
    }
    public string Requirement
    {
        get;

        private set;
    }

    public void Interact()
    {

    }
    public void UI(TMP_Text text, TMP_Text pressE)
    {

    }
}
