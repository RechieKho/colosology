using UnityEngine;
using General.Data.AttackData;
using System.Collections.Generic;

/* This namespace is use for:
 * store general operation
 */
namespace General.Operation 
{
    // This class is use for storing general static method
    public class GTM
    {
        public static Vector2 CalculateRotatedDirection(Vector2 direction, float radiens)
        {
            Vector2 calculatedDirection = new Vector2();
            calculatedDirection.x = direction.x * Mathf.Cos(radiens) - direction.y * Mathf.Sin(radiens);
            calculatedDirection.y = direction.y * Mathf.Cos(radiens) + direction.x * Mathf.Sin(radiens);
            return calculatedDirection;
        }

        public static int LayermaskToLayer(LayerMask layerMask)
        {
            int layerNumber = 0;
            int layer = layerMask.value;
            while (layer > 0)
            {
                layer >>= 1;
                layerNumber++;
            }
            return layerNumber - 1;
        }

        public static float CalculateDistanceBetweenPoint(Vector2 point1, Vector2 point2)
        {
            return Mathf.Sqrt(Mathf.Pow(point2.x - point1.x, 2) + Mathf.Pow(point2.y - point1.y, 2));
        }

        // Make this MORE FRIENDLY TO ME!!!
        public static GameObject GetClosestGameObject(List<GameObject> targets, Vector2 currentPos)
        {
            GameObject tMin = null;
            float minDist = Mathf.Infinity;
            foreach (GameObject t in targets)
            {
                float dist = Vector2.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }
    }
}