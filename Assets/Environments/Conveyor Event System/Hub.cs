using System;
using UnityEngine;
using Newtonsoft.Json;

public class jsonTest
{
    public string name;
    public int iNumber;

    public jsonTest(string name, int iNumber)
    {
        this.name = name;
        this.iNumber = iNumber;
    }
}

public class Hub : MonoBehaviour, ICustomMessageTarget
{
    public GameObject Prefab;
    public int SpawnTime = 2;
 
    void Awake()
    {
    }

    void Start()
    {
        Invoke("Spawn", 5);
    }

    void Update()
    {
    }

    public void Message1()
    {
        Debug.Log("Message 1 received");
        jsonTest jt = new jsonTest("Hallo", 999);

        string strJson = JsonConvert.SerializeObject(jt);
        print(strJson);
    }

    public string Message2(string str)
    {
        Debug.Log("Message 2 received");

        return "Hello " + str;
    }

    public void doOnAnotherGameObject(GameObject gObject)
    {
        gObject.GetComponent<AnotherGameobject>().doWithCallback(callbackFunc);
    }

    public void doOnHub()
    {
        print("Done on hub!");
    }

    public void callbackFunc(bool done)
    {
        if (done)
            print("Call Back On Hub == true");
        else
            print("Call Back On Hub == false");
    }

    public void SensorSignal(Sensor sensor, Actor actor, Object myObject)
    {
        Debug.Log("Sensor " + sensor.gameObject.name + " collided with " + gameObject.name);
    }

    void Spawn()
    {
        Instantiate(Prefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
        Invoke("Spawn", SpawnTime);
    }


    public void objectClicked(GameObject go)
    {
        print(go.name);
        GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = go.name;
        GameObject canvas = GameObject.Find("Canvas");
        
    }
}
