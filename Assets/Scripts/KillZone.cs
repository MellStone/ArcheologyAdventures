using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameEvent gameEventToRaiseOnInteraction;

    private void OnTriggerEnter(Collider other)
    {
        gameEventToRaiseOnInteraction.Fire();
    }
}
