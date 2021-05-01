using UnityEngine;
using General.Other;

/* this namespace is used for: 
 * storing motion datatype
 */
namespace General.Movement
{
    // MotionImpact with precision
    public class ImpactPrec_SO : Impact_SO
    {
        [Range(AttributeData.Range.MinEndMultiply, AttributeData.Range.MaxEndMultiply)] public float endMultiply = 0.1f;
    }
}