using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Test : MonoBehaviour
{
    public GameObject MainHub;
    
    void Start()
    {
        ExecuteEvents.Execute<ICustomMessageTarget>(MainHub, null, (x, y) => 
        {
            x.Message1();
        });

        ExecuteEvents.Execute<ICustomMessageTarget>(MainHub, null, (x, y) =>
        {
            var msg = x.Message2("jw1401");
            print(msg);
        });

        ExecuteEvents.Execute<ICustomMessageTarget>(MainHub, null, (x, y) =>
        {
            x.doOnAnotherGameObject(GameObject.Find("AnotherGameobject"));
        });

        MainHub.GetComponent<Hub>().doOnHub();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }

        if (Input.GetKeyDown("o"))
        {
            EventManager.TriggerEvent("Spawn");
        }

        if (Input.GetKeyDown("p"))
        {
            EventManager.TriggerEvent("Destroy");
        }

        if (Input.GetKeyDown("x"))
        {
            EventManager.TriggerEvent("Junk");
        }
    }

}
