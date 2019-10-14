using System;
using System.Collections.Generic;
using UnityEngine;

namespace RayCast
{
    public class Ray3D : Ray
    {
        Vector3 endPosition;
        RaycastHit hit;

        public override List<data> Perceive(float rayDistance, float[] rayAngles, string[] detectableObjects, float startOffset, float endOffset)
        {

            perceptionBuffer.Clear();
            perceptionBuffer.Capacity = rayAngles.Length;

            int counter = 0;

            foreach (float angle in rayAngles)
            {

                float[] oneHot = new float[detectableObjects.Length];
                Array.Clear(oneHot, 0, oneHot.Length);

                perceptionBuffer.Add(new data("", 0f, oneHot));

                endPosition = transform.TransformDirection(PolarToCartesian(rayDistance, angle));
                endPosition.y = endOffset;

                if (Application.isEditor)
                {
                    Debug.DrawRay(transform.position + new Vector3(0f, startOffset, 0f), endPosition, Color.black, 0.01f, true);
                }

                if (Physics.SphereCast(transform.position + new Vector3(0f, startOffset, 0f), 0.5f, endPosition, out hit, rayDistance))
                {
                    for (int i = 0; i < detectableObjects.Length; i++)
                    {
                        if (hit.collider.gameObject.CompareTag(detectableObjects[i]))
                        {
                            perceptionBuffer[counter].tag = detectableObjects[i];
                            perceptionBuffer[counter].distance = hit.distance / rayDistance;

                            int iter = 0;

                            foreach (string tag in detectableObjects)
                            {
                                if (tag == detectableObjects[i])
                                {
                                    oneHot[iter] = 1f;

                                }
                                else
                                {
                                    oneHot[iter] = 0f;
                                }

                                iter++;
                            }
                            perceptionBuffer[counter].onehot = oneHot;

                            break;
                        }
                    }
                }

                counter++;
            }

            return perceptionBuffer;
        }

        public static Vector3 PolarToCartesian(float radius, float angle)
        {
            float x = radius * Mathf.Cos(DegreeToRadian(angle));
            float z = radius * Mathf.Sin(DegreeToRadian(angle));
            return new Vector3(x, 0f, z);
        }

    }
}
