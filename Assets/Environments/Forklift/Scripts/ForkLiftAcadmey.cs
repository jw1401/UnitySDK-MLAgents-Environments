using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;


public class ForkLiftAcadmey : Academy
{
    [Space(10)]
    public GameObject RobotAgent;
    private bool _isInference = true;

    public override void InitializeAcademy()
    {
        if (RobotAgent.GetComponent<RobotAgent>().usePlayerBrain)
        {
            MLAgents.PlayerBrain playerBrain = (MLAgents.PlayerBrain)Resources.Load("_RobotPlayerBrain");
            GetComponent<Academy>().broadcastHub.Clear();
            GetComponent<Academy>().broadcastHub.broadcastingBrains.Add(playerBrain);
        }

        Monitor.SetActive(true);
        this.SetIsInference(_isInference);
    }

    public override void AcademyReset()
    {
        this.SetIsInference(_isInference);
    }

    public override void AcademyStep()
    {
        this.SetIsInference(_isInference);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 25), "Speed"))
        {
            if (_isInference)
            {
                _isInference = false;
            }
            else
            {
                _isInference = true;
            }
            this.SetIsInference(_isInference);
        }
    }
}
