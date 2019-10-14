using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Actor : MonoBehaviour
{
    public GameObject MainHub;
    public Transform[] targets;
    public float speed;

    private Hub hub;

    void Awake()
    {
        hub = MainHub.GetComponent<Hub>();
    }

    void Start()
    {
    }

    void Update()
    {
    }


    public void startAct(Object myObject)
    {
        myObject.Targets = this.targets;
        myObject.Speed = this.speed;
        myObject.setUpdate(true);
    }

    public void stopAct(Object myObject)
    {
        myObject.setUpdate(false);
    }
}
