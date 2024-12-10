using UnityEngine;

public abstract class InteractionStrategy : ScriptableObject
{
    public abstract void InteractStarted(GameObject target);
    public abstract void Interact(GameObject target);
    public abstract void InteractCancelled(GameObject target);
}
