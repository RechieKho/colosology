using UnityEngine;
using General.Data.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Data.Motion.Legacy
{
    // motion formed by continuous force
    public class MotionNormal : ScriptableObject
    {
        [Range(AttributeData.Range.MinMotionNorm, AttributeData.Range.MaxMotionNorm)] public float maxAcceleration = 1f;
        [Range(AttributeData.Range.MinMotionNorm, AttributeData.Range.MaxMotionNorm)] public float maxVelocity = 1f;
    }
}