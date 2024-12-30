using UnityEngine;

[CreateAssetMenu(fileName = "FoodInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Food Interaction Strategy")]
public class FoodInteractionStrategy : InteractionStrategy
{
    [Header("Properties")]
    [SerializeField] private float _fillRate = 10f;
    [SerializeField] private float _pourRate = 20f;
    
    public override void InteractStarted(GameObject player, GameObject target)
    {
        var foodBowl = target.GetComponent<FoodBowl>();
        if (foodBowl != null) 
        {
            foodBowl.StartInteract(player, _pourRate);
            return;
        }

        var foodSource = target.GetComponent<FoodSource>();
        if (foodSource != null) 
        {
            foodSource.StartInteract(player, _fillRate);
            return;
        }

        Debug.Log("Food Interaction has started.");
    }

    public override void Interact(GameObject player, GameObject target)
    {
    }

    public override void InteractCancelled(GameObject player, GameObject target)
    {
        var foodBowl = target.GetComponent<FoodBowl>();
        if (foodBowl != null) 
        {
            foodBowl.StopInteract();
            return;
        }

        var foodSource = target.GetComponent<FoodSource>();
        if (foodSource != null) 
        {
            foodSource.StopInteract();
            return;
        }

        Debug.Log("Food Interaction has ended.");
    }
}
