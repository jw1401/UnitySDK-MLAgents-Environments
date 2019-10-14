using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AgentDiscrete : Agent
{
    Rigidbody rBody;
    public Transform Target;
    public float speed = 10;
    public float maxValue = 4, minValue = -4;
    public float helperValue;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        helperValue = 2 * maxValue;
    }

    public override void CollectObservations()
    {

        // Target and Agent positions
        AddVectorObs(normalize(Target.localPosition.x));
        AddVectorObs(normalize(Target.localPosition.z));
        AddVectorObs(normalize(this.transform.localPosition.x));
        AddVectorObs(normalize(this.transform.localPosition.z));

        // Agent velocity
        AddVectorObs(rBody.velocity.x / 10);
        AddVectorObs(rBody.velocity.z / 10);

    }


    private float normalize(float currentValue)
    {
        float normalizedValue = (currentValue - minValue) / (maxValue - minValue);
        return normalizedValue;
    }

    public override void AgentAction(float[] act, string textAction)
    {

        int action = Mathf.FloorToInt(act[0]);

        Vector3 controlSignal = Vector3.zero;

        switch (action)
        {
            case 0:
                // Default Action in Player mode
                break;

            case 1:
                rBody.AddForce(new Vector3(0, 0, 1) * speed);
                break;

            case 2:
                rBody.AddForce(new Vector3(0, 0, -1) * speed);
                break;

            case 3:
                rBody.AddForce(new Vector3(1, 0, 0) * speed);
                break;

            case 4:
                rBody.AddForce(new Vector3(-1, 0, 0) * speed);
                break;
            // any other case:
            default:
                break;
        }



        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            Done();
        }

        // Fell off platform
        if (this.transform.localPosition.y < 0)
        {
            SetReward(-1.0f);
            Done();
        }

        // SetReward(-0.01f);

    }


    public override void AgentReset()
    {

        if (this.transform.localPosition.y < 0)
        {
            // If the Agent fell, zero its momentum
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.value * maxValue * 2 - maxValue, 0.5f, Random.value * maxValue * 2 - maxValue);
    }
}
