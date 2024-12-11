using UnityEngine;

[CreateAssetMenu(fileName = "FoodInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Food Interaction Strategy")]
public class FoodInteractionStrategy : InteractionStrategy
{
    public override void InteractStarted(GameObject player, GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(GameObject player, GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void InteractCancelled(GameObject player, GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
