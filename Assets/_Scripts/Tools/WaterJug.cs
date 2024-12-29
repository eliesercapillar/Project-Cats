using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterJug : MonoBehaviour, ITool
{
    [SerializeField] private InteractionStrategy _strategy;

    [Header("Properties")]
    [SerializeField] private int _maxUsers = 1;
    [SerializeField] private int _maxUses = 5; // Not necessary?

    private int _currentUsers = 0;

    private MeshRenderer _mr;
    private MeshCollider _mc;

    private void Awake()
    {
        _mr = GetComponent<MeshRenderer>();
        _mc = GetComponent<MeshCollider>();
    }


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

    public InteractionStrategy GetStrategy() 
    {
        if (_currentUsers >= _maxUsers) return null;
        
        _currentUsers++;
        _mr.enabled = false;
        _mc.enabled = false;

        return _strategy;
    }
}
