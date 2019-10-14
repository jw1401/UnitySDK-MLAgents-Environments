using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class data
{
	public string tag;
	public float distance;
	public float[] onehot;

	public data(string tag, float distance, float[] onehot)
	{
		this.tag= tag;
		this.distance= distance;
		this.onehot = onehot;
	}
}

public abstract class Ray : MonoBehaviour {

	protected List<data> perceptionBuffer = new List<data>();

	public virtual List<data> Perceive(float rayDistance, float[] rayAngles, string[] detectableObjects, float startOffset, float endOffset)
	{
		return perceptionBuffer;
	}

	public static float DegreeToRadian(float degree)
	{
		return degree * Mathf.PI / 180f;
	}
	
}
