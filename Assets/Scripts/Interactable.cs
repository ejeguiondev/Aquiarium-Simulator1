using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{
    public string Name { get; }
    public string Requirement { get; }
    void Interact();
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
}
