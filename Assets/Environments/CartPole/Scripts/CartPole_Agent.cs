using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class CartPole_Agent : Agent
{
    private Vector3 cartPos, rbCartPos, polePos, rbPolePos;
    private Quaternion poleRot, rbPoleRot;
    private Rigidbody rbCart;
    private Rigidbody rbPole;

    [Space(10)]
    [Header("Properties")]
    public GameObject Cart;
    public GameObject Pole;
    
    [Space(10)]
    [Header("Settings")]
    public bool useDenseReward = false;
    [Range(10f, 15f)]
    public float angleLimit = 12.5f;
    [Range(1f, 2.4f)]
    public float travelLimit = 2.4f;
    public float maxSpeed;
    public float maxAngularSpeed;

    [Space(10)]
    [Header("Obesrvations")]
    public List<float> obs = new List<float>();

    private float _poleAngle;
    private float poleAngle
    {
        set
        {
            _poleAngle = value;
        }
        get
        {
            _poleAngle = Pole.transform.localRotation.eulerAngles.x;

            if (_poleAngle > 180)
                _poleAngle = _poleAngle - 360;

            return _poleAngle;
        }
    }

    private float _denseReward;
    private float denseReward
    {
        set
        {
            _denseReward = value;
        }
        get
        {
            var min = 1f/travelLimit;
            var max = 1f/0.1f;

            float z = Mathf.Sqrt(Mathf.Pow(Cart.transform.localPosition.z, 2));

            if ( z >= 0.1f)
            {
                _denseReward = 1f / z;
                return normalize(_denseReward, max, min);
            }
            else
            {
                return 1f;
            }

            
        }
    }


    public override void InitializeAgent()
    {
        rbCart = Cart.GetComponent<Rigidbody>();
        rbPole = Pole.GetComponent<Rigidbody>();
        rbPole.maxAngularVelocity = maxAngularSpeed;

        cartPos = Cart.transform.position;
        polePos = Pole.transform.position;
        poleRot = Pole.transform.rotation;

        rbCartPos = rbCart.position;
        rbPolePos = rbPole.position;
        rbPoleRot = rbPole.rotation;
    }


    public override void CollectObservations()
    {
        obs.Clear();
        obs.Add(normalize(Cart.transform.localPosition.z, travelLimit, -travelLimit));
        obs.Add(normalize(rbCart.velocity.z, maxSpeed, -maxSpeed));
        obs.Add(normalize(Ray.DegreeToRadian(poleAngle), Ray.DegreeToRadian(angleLimit), Ray.DegreeToRadian(-angleLimit)));
        obs.Add(normalize(rbPole.angularVelocity.x, maxAngularSpeed, -maxAngularSpeed));

        AddVectorObs(obs);
    }


    private float normalize(float currentValue, float maxValue, float minValue)
    {
        float normalizedValue = (currentValue - minValue) / (maxValue - minValue);
        return normalizedValue;
    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Set actions that come from the RL Agent
        // If Speed is over max then dont act so that speed is not going up any more
        // If Agent is failing on limits set Reward  = -1 otherwise set positive Reward
        // If use dense reward is true the add bonus reward for keeping agent near zero point
        
        int act = Mathf.FloorToInt(vectorAction[0]);
        float speed = Mathf.Sqrt(Mathf.Pow(rbCart.velocity.z, 2));

        if (speed <= maxSpeed)
        {
            switch (act)
            {
                case 0:
                    rbCart.AddForce(new Vector3(0, 0, 10), ForceMode.Force);
                    break;
                case 1:
                    rbCart.AddForce(new Vector3(0, 0, -10), ForceMode.Force);
                    break;
                default:
                    break;
            }
        }
        else
        {
            rbCart.AddForce(0, 0, 0);
        }

        if (poleAngle < -angleLimit || poleAngle > angleLimit || Cart.transform.localPosition.z < -travelLimit || Cart.transform.localPosition.z > travelLimit)
        {
            SetReward(-1.0f);
            Done();
        }
        else
        {
            if (useDenseReward)
            {
                SetReward(1.0f + denseReward);
                Monitor.Log("Dense Reward ", denseReward);
            }
            else
            {
                SetReward(1.0f);
            }
        }
        Monitor.Log("Overall Reward ", GetReward());
    }


    public override void AgentReset()
    {
        // For RigidBody and Gameobject use worldspace positions
        // First set Gameobject position and rotation
        // Second set Rigidbody position and rotation
        // Last set velocities

        var rndRange = Random.Range(-10f, 10f);     // use Angle between -10 and 10 degrees

        Cart.transform.position = cartPos; 
        Pole.transform.position = polePos;
        Pole.transform.rotation = Quaternion.Euler(rndRange, 0, 0);

        rbCart.position = rbCartPos; 
        rbPole.position = rbPolePos;
        rbPole.rotation = Quaternion.Euler(rndRange, 0, 0);

        rbCart.velocity = Vector3.zero;
        rbPole.angularVelocity = Vector3.zero;
    }

}
