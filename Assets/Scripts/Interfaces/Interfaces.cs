using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer { }
public interface IInteractable
{
    void Interact(InteractionComponent interaction);
}
