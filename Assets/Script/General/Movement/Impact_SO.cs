using UnityEngine;
using General.Other;

/* This namespace is use for:
 * storing motion datatype
 */
namespace General.Movement
{
    // motion formed by sudden single push
    public class Impact_SO : ScriptableObject
    {
        [Range(AttributeData.Range.MinMotionImp, AttributeData.Range.MaxMotionImp)] public float thrust = 1f;
    }
}