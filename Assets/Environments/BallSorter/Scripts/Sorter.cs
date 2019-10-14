using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    public float speed = 0;       // bei 0.01 s fixed time step = 1 s for 360 degrees
    
    void Start()
    {}

    public void TurnCounterClockwise()
    {
        this.transform.Rotate(Vector3.down * Time.fixedDeltaTime * speed);
    }

    public void TurnClockwise()
    {
        this.transform.Rotate(Vector3.up * Time.fixedDeltaTime * speed);
    }

    public void Reset()
    {
        this.transform.rotation = new Quaternion();
    }
}
