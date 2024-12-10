using UnityEngine;

[CreateAssetMenu(fileName = "FoodInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Food Interaction Strategy")]
public class FoodInteractionStrategy : InteractionStrategy
{
    public override void InteractStarted(GameObject target)
    {
        Debug.Log("Food Interaction has started.");
    }

    public override void Interact(GameObject target)
    {
        Debug.Log("Food Interaction is continuing.");
    }

    public override void InteractCancelled(GameObject target)
    {
        Debug.Log("Food Interaction has ended.");
    }
}
