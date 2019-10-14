
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using RayCast;

public class RobotAgent : Agent
{
    // Set GameObjects in Unity Editor
    public GameObject MainBody;
    public GameObject Palette;
    Rigidbody rbMainBody;
    Rigidbody rbPalette;

    [Header("Settings")]
    public bool usePlayerBrain = false;
    
    [Header("Fork Settings")]
    public GameObject forks;
    public float forkMin = -0.2f;
    public float forkMax = 1f;
    float forkPosition;

    [Header("Speed Settings")]
    public float rpm = 1;
    public float maxSpeed = 0;
    float maxAngularVelocity = 0;

    [Header("Inspect")]
    public List<float> obs = new List<float>();
    public float maxPositionValue = 10, minPositionValue = -10;
    public string hitOneHot = "0 0 0";

    // RayCast Settings
    float[] rayAngles = { 90f, 70f, 110f};
    string[] detectableObjects = { "goal", "palette", "wall" };
    float rayDistance = 12f;
    Ray3D rayPer;


    public override void InitializeAgent()
    {
        if (usePlayerBrain)
        {
            MLAgents.PlayerBrain playerBrain = (MLAgents.PlayerBrain)Resources.Load("_RobotPlayerBrain");
            this.brain = playerBrain;
            print("Brain loaded");
        }

        rbMainBody = MainBody.GetComponent<Rigidbody>();
        rbPalette = Palette.GetComponent<Rigidbody>();
        rayPer = MainBody.GetComponent<Ray3D>();

        forkPosition = forkMin;
        maxAngularVelocity = Ray.DegreeToRadian(360) * rpm / 60;
        rbMainBody.maxAngularVelocity = maxAngularVelocity;

        GameObject ground = GameObject.Find("Ground");
        var transform = ground.GetComponent<Transform>();
        maxPositionValue = transform.lossyScale.x * 10 / 2;
        minPositionValue = -maxPositionValue;
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 50, 200, 25), hitOneHot);
    }

    public override void CollectObservations()
    {
        var res = rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0.4f, 0f);
        hitOneHot  = string.Join(", ", res[0].onehot) + " | " + res[0].tag;

        obs.Clear();
        obs.Add(normalize(Palette.transform.position.x, maxPositionValue, minPositionValue));
        obs.Add(normalize(Palette.transform.position.z, maxPositionValue, minPositionValue));
        obs.Add(normalize(MainBody.transform.position.x, maxPositionValue, minPositionValue));
        obs.Add(normalize(MainBody.transform.position.z, maxPositionValue, minPositionValue));
        obs.Add(normalize(Ray.DegreeToRadian(MainBody.transform.rotation.eulerAngles.y), 2 * Mathf.PI, 0));
        obs.Add(normalize(rbMainBody.velocity.x, maxSpeed, -maxSpeed));
        obs.Add(normalize(rbMainBody.velocity.z, maxSpeed, -maxSpeed));
        obs.Add(normalize(rbMainBody.angularVelocity.y, maxAngularVelocity, -maxAngularVelocity));

        AddVectorObs(obs);
    }

    private float normalize(float currentValue, float maxValue, float minValue)
    {
        float normalizedValue = (currentValue - minValue) / (maxValue - minValue);
        return normalizedValue;
    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        var act = (int)vectorAction[0];

        switch (act)
        {
            case 1:     // Forward
                rbMainBody.velocity = rbMainBody.transform.forward * maxSpeed;
                break;
            case 2:     // Backward
                rbMainBody.velocity = -rbMainBody.transform.forward * maxSpeed;
                break;
            case 3:     // Left
                rbMainBody.angularVelocity = -rbMainBody.transform.up * maxAngularVelocity;
                break;
            case 4:     // Right
                rbMainBody.angularVelocity = rbMainBody.transform.up * maxAngularVelocity;
                break;
            case 5:     // Forks up
                if (forkPosition < forkMax)
                {
                    forkPosition += 0.01f;
                    forks.transform.localPosition = new Vector3(0, forkPosition, 0);
                }
                break;
            case 6:     // Forks down
                if (forkPosition > forkMin)
                {
                    forkPosition -= 0.01f;
                    forks.transform.localPosition = new Vector3(0, forkPosition, 0);
                }
                break;
            default:    // print("default case 0");
                break;
        }

        if (Palette.transform.localPosition.y < -2f || MainBody.transform.localPosition.x < -2f)
        {
            Done();
        }
    }

    private Vector3 rndPosition(float maxValue, float yOffset = 1f)
    {
        // Move the target to a new spot
        return new Vector3(Random.value * maxValue * 2 - maxValue, yOffset, Random.value * maxValue * 2 - maxValue);
    }

    public override void AgentReset()
    {
        // Physics stability with setting all to zero positon and rotation
        // Set Physics time in Unity up from 0.02 to 0.04 and Solver Iterations down to get more stable physics e.g. to 1

        rbMainBody.transform.localRotation = new Quaternion(0, 0, 0, 0);
        rbMainBody.transform.localPosition = Vector3.zero;
        rbMainBody.angularVelocity = Vector3.zero;
        rbMainBody.velocity = Vector3.zero;

        Palette.transform.localRotation = new Quaternion(0, 0, 0, 0);
        Palette.transform.localPosition = rndPosition(maxPositionValue, 0.2f);
        rbPalette.angularVelocity = Vector3.zero;
        rbPalette.velocity = Vector3.zero;
    }

    public void PaletteCollisionDetected(PaletteCollisionDetection colDect, Collider col)
    {
        if (col.gameObject.name == "Goal")
        {
            SetReward(1f);
            Monitor.Log("Reward Yaeh !!!", GetReward());
            Done();
        }
    }

    public void CollisionDetected(CollisionDetection colDect, Collider col)
    {
        // Collider with Trigger
        if (col.gameObject.name == "Palette")
        {
            // SetReward(1f);
            Monitor.Log("Collided with Palette", 0);
            // Done();
        }

        if (col.gameObject.name == "Fence")
        {
            SetReward(-1f);
            Monitor.Log("Collided with Fence", GetReward());
            Done();
        }
    }
}
