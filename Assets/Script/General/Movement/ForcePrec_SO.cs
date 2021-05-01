using UnityEngine;
using General.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Movement
{
    // MotionNormal with precision
    public class ForcePrec_SO : Force_SO
    {
        [Range(AttributeData.Range.MinEndMultiply, AttributeData.Range.MaxEndMultiply)] public float endMultiply = 0.1f;
    }
}