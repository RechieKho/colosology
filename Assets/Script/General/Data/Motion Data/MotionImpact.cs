using UnityEngine;
using General.Data.Other;

/* This namespace is use for:
 * storing motion datatype
 */
namespace General.Data.Motion.Legacy
{
    // motion formed by sudden single push
    public class MotionImpact : ScriptableObject
    {
        [Range(AttributeData.Range.MinMotionImp, AttributeData.Range.MaxMotionImp)] public float thrust = 1f;
    }
}