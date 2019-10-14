using System;
using System.Collections;
using UnityEngine;
using MLAgents;


public class BallSorterAgent : Agent
{
    public Ball Ball;
    public Sorter Sorter;
    public Lifter Lifter;
    public bool useVisual = false;
    private string agentName;


    public override void InitializeAgent()
    {
        Physics.gravity = new Vector3(0, -981.0f, 0);   // Set gravity for cm/sec**2  
        agentName = this.gameObject.name;
    }

    public override void CollectObservations()
    {
        if (!this.useVisual)                            // No Vector Obs if use Visual checked
        {
            foreach (int co in System.Enum.GetValues(typeof(BallColor.EnumColors)))
            {
                AddVectorObs((int)Ball.GetColorEnum() == co ? 1.0f : 0.0f);
            }

            AddVectorObs(normalize(Ray.DegreeToRadian(Sorter.transform.rotation.eulerAngles.y), 2 * Mathf.PI, 0));
            AddVectorObs(normalize(Lifter.transform.localPosition.y, Lifter.upperLimit, Lifter.lowerLimit));
        }
    }

    public override void AgentAction(float[] act, string textAction)
    {
        int action = Mathf.FloorToInt(act[0]);

        switch (action)
        {
            case 0:                                     // Default Action in Player mode
                break;

            case 1:
                Lifter.MoveUp();
                break;
                
            case 2:
                Lifter.MoveDown();
                break;

            case 3:
                Sorter.TurnCounterClockwise();
                break;

            case 4:
                Sorter.TurnClockwise();
                break;

            default:                                    // any other case:
                break;
        }
    }

    public void collisionDetected(Ball ball, Collision col) 
    {   
        /**************************************************
            Acts as callback called from ball that collided
            with target.
         **************************************************/

        var target = col.gameObject.name;

        if (target == ball.GetColor())
        {
            SetReward(1f);
            Monitor.Log("Reward for " + agentName, GetReward());
            Done();
        }
        
        if (target == "Cardboard")
        {
            SetReward(0f);
            Monitor.Log("Reward for " + agentName, GetReward());
            Done();
        }
    }

    public override void AgentReset()
    {
        Ball.Reset();
        Sorter.Reset();
        Lifter.Reset();
    }

    private float normalize(float currentValue, float maxValue, float minValue)
    {
        float normalizedValue = (currentValue - minValue) / (maxValue - minValue);
        return normalizedValue;
    }
}

