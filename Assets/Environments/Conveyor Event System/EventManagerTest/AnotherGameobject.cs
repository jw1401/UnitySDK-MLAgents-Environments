using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class AnotherGameobject : MonoBehaviour
{

    void Start()
    {
        // StartCoroutine(Fetch(myCallback));
    }


    void Update()
    {

    }

    // public IEnumerator Fetch(System.Action<bool> callback)
    // {
    //     yield return new WaitForSeconds(1);
    //     callback(true);
    // }

    public void doWithCallback(System.Action<bool> callbackFunc)
    {
        print("do something on " + this.name + " and callback");
        callbackFunc(false);
    }

    // public void myCallback(bool done)
    // {
    //     if (done)
    //         print("successfully fetched something from the web");
    //     else
    //         print("There was an error");
    // }

}
