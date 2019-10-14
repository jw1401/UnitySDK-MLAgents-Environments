using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    int width = 320;
    int height = 240;

    Camera camera;
    RenderTexture renderTexture;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Tools/My Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.autoRepaintOnSceneChange = true;
        window.Show();
    }

    public void Awake()
    {
        renderTexture = new RenderTexture((int)width, (int)height, (int)RenderTextureFormat.ARGB32);
    }

    public void OnEnable()
    {
        camera = Camera.main;
    }

    public void Update()
    {
        if (camera != null)
        {
            camera.targetTexture = renderTexture;
            camera.Render();
            camera.targetTexture = null;
        }

        if (renderTexture == null)
            renderTexture = new RenderTexture((int)width, (int)height, (int)RenderTextureFormat.ARGB32);
        
        if (renderTexture.width != width || renderTexture.height != height)
            renderTexture = new RenderTexture((int)width,(int)height,(int)RenderTextureFormat.ARGB32);
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();

        if (renderTexture != null)
            GUI.DrawTexture(new Rect((Screen.width / 2) - (width/2), (Screen.height / 2) - (height/2), width, height), renderTexture);
    }
}