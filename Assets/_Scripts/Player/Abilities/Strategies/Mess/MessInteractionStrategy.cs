using UnityEngine;

[CreateAssetMenu(fileName = "MessInteractionStrategy", menuName = "Scriptable Objects/Interaction Strategies/Mess Interaction Strategy")]
public class MessInteractionStrategy : InteractionStrategy
{
    [Header("Properties")]
    [SerializeField] private float _sweepRate = 20f;
    
    public override void InteractStarted(GameObject player, GameObject target)
    {
        var mess = target.GetComponent<Mess>();
        if (mess != null) 
        {
            mess.StartInteract(player, _sweepRate);
            return;
        }

        Debug.Log("Mess Interaction has started.");
    }

    public override void Interact(GameObject player, GameObject target)
    {
    }

    public override void InteractCancelled(GameObject player, GameObject target)
    {
        var mess = target.GetComponent<Mess>();
        if (mess != null) 
        {
            mess.StopInteract();
            return;
        }

        Debug.Log("Mess Interaction has ended.");
    }
}
