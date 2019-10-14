using System;
using UnityEngine;
using UnityEditor;
using System.Net.Http;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class PlayMode : WebSocketBehavior
    {
        public static bool bRun = false;

        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;

            if (msg == "RUN")
            {
                bRun = true;
            }
            else
            {
                bRun = false;
            }

            Send(msg);
        }
    }
}

public class StartUnity : EditorWindow
{
    private static readonly HttpClient client = new HttpClient();

    static StartUnity()
    {
        EditorApplication.playModeStateChanged += ModeChanged;
    }

    static void ModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            Debug.Log("Restart Server");
            var wssv = new WebSocketServer("ws://localhost:8765");
            wssv.AddWebSocketService<Server.PlayMode>("/Playmode");
            wssv.Start();
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Stop"))
        {
            EditorApplication.ExitPlaymode();
        }

        if (Server.PlayMode.bRun == true)
        {
            EditorApplication.EnterPlaymode();
        }
    }

    [MenuItem("Tools/Start-Unity")]
    static async void start()
    {
        StartUnity window = (StartUnity)EditorWindow.GetWindow(typeof(StartUnity));
        window.autoRepaintOnSceneChange = true;
        window.Show();

        var wssv = new WebSocketServer("ws://localhost:8765");
        wssv.AddWebSocketService<Server.PlayMode>("/Playmode");
        wssv.Start();
        // wssv.Stop();

        Task<int> myTask = OperationsAsync(1000000000);
        int result = await myTask;
        Debug.Log(result.ToString());
    }

    static int count(int countTo)
    {
        int counter = 0;

        for (int i = 0; i < countTo; i++)
        {
            counter++;
        }
        return counter;
    }

    public static async Task<int> OperationsAsync(int countTo = 0)
    {
        int counter = await Task.Run(() => count(countTo));
        return counter;
    }

}

