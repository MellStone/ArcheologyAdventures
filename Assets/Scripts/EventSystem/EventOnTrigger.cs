using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnTrigger : MonoBehaviour
{
    public GameEvent gameEventToRaiseOnInteraction;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            gameEventToRaiseOnInteraction.Fire();
    }
}
