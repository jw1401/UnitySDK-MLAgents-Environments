using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteCollisionDetection : MonoBehaviour
{
     public void OnTriggerEnter(Collider col)
     {
         // Debug.Log("MyCollision :" + col.gameObject.name);
         // gameObject.GetComponentInParent<RobotAgent>().CollisionDetected(this, col);
         GameObject mb = GameObject.Find("MainBody");
         mb.GetComponentInParent<RobotAgent>().PaletteCollisionDetected(this, col);
     }
}
