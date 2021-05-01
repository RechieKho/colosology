using UnityEngine;
using General.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Movement
{
    // motion formed by continuous force
    public class Force_SO : ScriptableObject
    {
        [Range(AttributeData.Range.MinMotionNorm, AttributeData.Range.MaxMotionNorm)] public float maxAcceleration = 1f;
        [Range(AttributeData.Range.MinMotionNorm, AttributeData.Range.MaxMotionNorm)] public float maxVelocity = 1f;
    }
}