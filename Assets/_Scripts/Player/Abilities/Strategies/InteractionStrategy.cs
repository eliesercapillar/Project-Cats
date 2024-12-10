using UnityEngine;

public abstract class InteractionStrategy : ScriptableObject
{
    public abstract void InteractStarted();
    public abstract void Interact();
    public abstract void InteractCancelled();
}
