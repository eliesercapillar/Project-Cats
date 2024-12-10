using UnityEngine;

[CreateAssetMenu(fileName = "MilkInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Milk Interaction Strategy")]
public class MilkInteractionStrategy : InteractionStrategy
{
    public override void InteractStarted()
    {
        Debug.Log("Milk Interaction has started.");
    }

    public override void Interact()
    {
        Debug.Log("Milk Interaction is continuing.");
    }

    public override void InteractCancelled()
    {
        Debug.Log("Milk Interaction has ended.");
    }
}
