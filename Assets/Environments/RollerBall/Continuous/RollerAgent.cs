using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class RollerAgent : Agent
{
    Rigidbody rBody;
    public Transform Target;
    public float speed = 10;
    public float maxValue = 4, minValue = -4;
    public bool useVisual = false;
    public float helperValue;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        helperValue = 2 * maxValue;
    }

    public override void CollectObservations()
    {
        if (!useVisual)
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
    }

    
    private float normalize(float currentValue)
    {
        float normalizedValue = (currentValue - minValue) / (maxValue - minValue);
        return normalizedValue;
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rBody.AddForce(controlSignal * speed);

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
