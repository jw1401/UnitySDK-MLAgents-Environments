using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Grpc.Core;


public class TestGRPC : MonoBehaviour
{
    void Start()
    {
        print("started");
        grpcServiceV1.start();
    }

    void Update()
    {
        grpcServiceV1.Main();
    }

    private void OnApplicationQuit()
    {
        grpcServiceV1.stop();
    }
}

class grpcServiceV1
{
    static Channel channel;
    static Controller.ControllerClient client;

    public static void start()
    {
        channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
        client = new Controller.ControllerClient(channel);
    }

    public static void Main()
    {
        var oRes = new ObservationResponse();
        var oReq = new Empty();
        oRes = client.GetObservations(oReq);
        Debug.Log("Observations: " + oRes.Observations);
        var aRes = new ActionsResponse();
        var aReq = new ActionRequest();
        aReq.Actions.Add(1f);
        aReq.Actions.Add(2f);
        aRes = client.SetActions(aReq);
        Debug.Log(aRes.ActionsPerformed);
    }

    public static ObservationResponse getObservations()
    {
        var oRes = new ObservationResponse();
        var oReq = new Empty();
        oRes = client.GetObservations(oReq);
        Debug.Log("Observations: " + oRes.Observations);
        return oRes;
    }

    public static ActionsResponse setActions(float[] act)
    {
        var aRes = new ActionsResponse();
        var aReq = new ActionRequest();
        aReq.Actions.Add(act[0]);
        aReq.Actions.Add(act[1]);
        aRes = client.SetActions(aReq);
        Debug.Log(aRes.ActionsPerformed);
        return aRes;
    }

    public static void stop()
    {
        channel.ShutdownAsync().Wait();
        Debug.Log("GRPC stopped");
    }
}

