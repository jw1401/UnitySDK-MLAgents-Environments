using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;

public class GRPCService : MonoBehaviour
{
    static Channel channel;
    static Controller.ControllerClient client;
    
    public static void start()
    {
        channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
        client = new Controller.ControllerClient(channel);
        Debug.Log("GRPC started");
    }

    public static ObservationResponse getObservations()
    {
        var Res = new ObservationResponse();
        var Req = new Empty();
        Res = client.GetObservations(Req);
        return Res;
    }

    public static ActionsResponse setActions(float[] act)
    {
        var Res = new ActionsResponse();
        var Req = new ActionRequest();
        Req.Actions.AddRange(act);
        Res = client.SetActions(Req);
        return Res;
    }

    public static void stop()
    {
        channel.ShutdownAsync().Wait();
        Debug.Log("GRPC stopped");
    }
}

