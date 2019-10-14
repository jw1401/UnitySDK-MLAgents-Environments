using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using UnityEngine.UI;

public class CartPole_Academy : Academy
{
    private bool _isInference = false;
    public Text speedText;
    public Button myButton;

    public override void InitializeAcademy()
    {
        myButton.onClick.AddListener(buttonTask);
        Monitor.SetActive(true);
    }

    public override void AcademyReset()
    {
        this.SetIsInference(_isInference);
    }

    public override void AcademyStep()
    {
        this.SetIsInference(_isInference);
        speedText.text = System.Convert.ToString(Time.timeScale) + " x";
    }

    void buttonTask()
    {
        if (_isInference)
        {
            _isInference = false;
            myButton.GetComponentInChildren<Text>().text = "Training";
        }
        else
        {
            _isInference =true;
            myButton.GetComponentInChildren<Text>().text = "Inference";
        }
        
    }
} 
