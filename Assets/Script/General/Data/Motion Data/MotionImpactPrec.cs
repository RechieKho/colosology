using UnityEngine;
using General.Data.Motion.Legacy;
using General.Data.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Data.Motion.SecondGen
{
    // MotionImpact with precision
    public class MotionImpactPrec : MotionImpact
    {
        [Range(AttributeData.Range.MinEndMultiply, AttributeData.Range.MaxEndMultiply)] public float endMultiply = 0.1f;
    }
}