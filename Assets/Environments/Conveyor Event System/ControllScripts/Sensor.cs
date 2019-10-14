using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Sensor : MonoBehaviour
{
    public GameObject MainHub;
    public Actor[] Actor;
    public string SensorType;
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

    void OnTriggerEnter(Collider col)
    {
        Actor actor = null;
        Object myObject;

        myObject = col.gameObject.GetComponent<Object>();

        if (this.Actor == null || this.Actor.Length <= 0) return;
        if (this.Actor.Length == 1) actor = this.Actor[0];

        hub.SensorSignal(this, actor, myObject);

        if (SensorType == "startAct")
        {
            actor.startAct(myObject);
        }

        if (SensorType == "stopAct")
        {
            actor.stopAct(myObject);
        }

        if (SensorType == "decision")
        {
            this.Actor[myObject.Case].startAct(myObject);

            // switch (myObject.Case)
            // {
            //     case 0:
            //         this.Actor[myObject.Case].startAct(myObject);
            //         break;
            //     case 1:
            //         this.Actor[myObject.Case].startAct(myObject);
            //         break;
            // }
        }
    }
}
