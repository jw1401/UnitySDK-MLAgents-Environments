using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BallSorterAcademy : Academy {

    private bool _isInference = false;

    public override void InitializeAcademy()
    {
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
        if (GUI.Button(new Rect(10,10,200,25),"Speed"))
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
