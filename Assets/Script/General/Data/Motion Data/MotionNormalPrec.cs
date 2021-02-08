using UnityEngine;
using General.Data.Motion.Legacy;
using General.Data.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Data.Motion.SecondGen
{
    // MotionNormal with precision
    public class MotionNormalPrec : MotionNormal
    {
        [Range(AttributeData.Range.MinEndMultiply, AttributeData.Range.MaxEndMultiply)] public float endMultiply = 0.1f;
    }
}