using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Game Event", menuName = "Archeology Adventures/Game Events/New Game Event")]
public class GameEvent : ScriptableObject
{

    private List<IGameEventListener> eventListeners = new List<IGameEventListener>();

    public void Fire()
    {
        for (int i = 0; i < eventListeners.Count; i++)
        {
            IGameEventListener listener = eventListeners[i];
            listener.outOfBounce();
        }
    }

    public void RegisterListener(IGameEventListener gameEventListener)
    {
        if (gameEventListener == null)
            return;
        if (eventListeners.Contains(gameEventListener))
            return;

        eventListeners.Add(gameEventListener);
    }

    public void UnregisterListener(IGameEventListener gameEventListener)
    {
        if (gameEventListener == null)
            return;
        if (eventListeners.Contains(gameEventListener) == false)
            return;

        eventListeners.Remove(gameEventListener);
    }
}