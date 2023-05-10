using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string m_Description;
    public string Description { get => m_Description;}

    public void Interact()
    {
        
    }
}
