using UnityEngine;

[CreateAssetMenu(fileName = "MilkInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Milk Interaction Strategy")]
public class MilkInteractionStrategy : InteractionStrategy
{
    [Header("Properties")]
    [SerializeField] private float _fillRate = 10f;
    [SerializeField] private float _pourRate = 20f;

    public override void InteractStarted(GameObject target)
    {
        var milkBowl = target.GetComponent<MilkBowl>();
        if (milkBowl != null) 
        {
            milkBowl.StartInteract(_pourRate);
            return;
        }

        var milkSource = target.GetComponent<MilkSource>();
        if (milkSource != null) 
        {
            milkSource.StartInteract(_fillRate);
            return;
        }

        Debug.Log("Milk Interaction has started.");
    }

    public override void Interact(GameObject target)
    {
    }

    public override void InteractCancelled(GameObject target)
    {
        var milkBowl = target.GetComponent<MilkBowl>();
        if (milkBowl != null) 
        {
            milkBowl.StopInteract();
            return;
        }

        var milkSource = target.GetComponent<MilkSource>();
        if (milkSource != null) 
        {
            milkSource.StopInteract();
            return;
        }

        Debug.Log("Milk Interaction has ended.");
    }
}
