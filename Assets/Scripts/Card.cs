using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float m_CardData;
    public float CardData { get => m_CardData;}

    public void Interact()
    {
        
    }
}
