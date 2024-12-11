using UnityEngine;

public abstract class InteractionStrategy : ScriptableObject
{
    public abstract void InteractStarted(GameObject player, GameObject target);
    public abstract void Interact(GameObject player, GameObject target);
    public abstract void InteractCancelled(GameObject player, GameObject target);
}
