using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Interact();
    }
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    }
}
