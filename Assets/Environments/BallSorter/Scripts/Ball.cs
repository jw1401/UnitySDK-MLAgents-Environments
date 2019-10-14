using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallColor
{
    public enum EnumColors
    {
        Red = 1,
        Green = 2,
        Blue = 3
    }

    private EnumColors enumColor;
    private static Color Red = new Color(1, 0, 0);
    private static Color Green = new Color(0, 1, 0);
    private static Color Blue = new Color(0, 0, 1);

    public Color GetRandomColor()
    {
        this.enumColor = BallColor.GetRandomEnumColor<EnumColors>();

        switch (enumColor)
        {
            case EnumColors.Red:
                return Red;

            case EnumColors.Green:
                return Green;

            case EnumColors.Blue:
                return Blue;

            default:
                return new Color(0, 0, 0);
        }
    }

    public EnumColors GetColorEnum()
    {
        return this.enumColor;
    }
    
    public string GetColorString()
    {
        return this.enumColor.ToString();
    }

    public static T GetRandomEnumColor<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(Random.Range(0, A.Length));
        return V;
    }
}


public class Ball : MonoBehaviour
{
    private BallColor BallColor;
    private BallSorterAgent BallSorterAgent;

    void Start()
    {
        BallSorterAgent = this.GetComponentInParent<BallSorterAgent>();
        BallColor = new BallColor();
    }

    public void Reset()
    {
        // Reset Transform and Physics
        this.transform.localPosition = new Vector3(0, 6, 1.5f);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        // Reset Random Color
        this.GetComponent<Renderer>().material.color = BallColor.GetRandomColor();
    }

    void OnCollisionEnter(Collision col)
    {
        BallSorterAgent.collisionDetected(this, col);
    }

    public string GetColor()
    {
        return this.BallColor.GetColorString();
    }

    public BallColor.EnumColors GetColorEnum()
    {
        return this.BallColor.GetColorEnum();
    }
}
