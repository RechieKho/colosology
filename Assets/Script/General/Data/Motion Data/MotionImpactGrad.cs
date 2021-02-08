using UnityEngine;
using General.Data.Motion.Legacy;
using General.Data.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Data.Motion.BranchOut
{
    // MotionImpact with gradient (value that control how large the motion is distributed to the direction perpendicular to motion)
    public class MotionImpactGrad : MotionImpact
    {
        [Tooltip("+1 means all motion is redirected to the right\n-1 means all motion is redirected to the left\n0 means motion's direction remain the same")]
        [Range(AttributeData.Range.MinMotionGrad, AttributeData.Range.MaxMotionGrad)] public float gradient = 1f;
        /* description of gradient:
         * 
         * +1 means all motion is redirected to the right
         * -1 means all motion is redirected to the left
         * 0 means motion's direction remain the same
         */
    }
}
