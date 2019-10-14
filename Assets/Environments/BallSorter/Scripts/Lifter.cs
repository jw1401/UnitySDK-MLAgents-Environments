using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    public float Speed = 20;
    public float upperLimit = 7.0f;
    public float lowerLimit = 4.0f;
    private Vector3 resetPosition;


    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    public void MoveUp()
    {
        if (this.transform.localPosition.y <= upperLimit - 0.1)
        {
            this.transform.Translate(Vector3.up * Time.fixedDeltaTime * Speed);
        }
    }

    public void MoveDown()
    {
        if (this.transform.localPosition.y >= lowerLimit + 0.1)
        {
            this.transform.Translate(Vector3.down * Time.fixedDeltaTime * Speed);
        }
    }

    public void Reset()
    {
        this.transform.localPosition = resetPosition;
    }


}
