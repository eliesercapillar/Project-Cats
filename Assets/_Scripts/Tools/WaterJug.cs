using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterJug : MonoBehaviour, ITool
{
    [SerializeField] private InteractionStrategy _strategy;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Performing DoLocalRotate!");
        transform.DORotate(new Vector3(0, 360, 0), 20f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear) // Ensures consistent rotation speed
            .SetLoops(-1, LoopType.Incremental); // Infinite looping
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InteractionStrategy GetStrategy() => _strategy;
}
