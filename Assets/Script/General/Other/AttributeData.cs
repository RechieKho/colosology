/* This namespace is use for:
 * Storing Other data
 */
namespace General.Other 
{
    // This class is use for storing inspector attribute data
    public static class AttributeData
    {
        #region Variable
        #endregion

        #region Struct
        public struct Range
        {
            #region Motion
            // normal
            public const float MaxMotionNorm = 50f;
            public const float MinMotionNorm = 1f;
            // impact
            public const float MaxMotionImp = 50f;
            public const float MinMotionImp = 1f;
            // end multiply
            public const float MaxEndMultiply = 1f;
            public const float MinEndMultiply = 0.01f;
            // gradient
            public const float MaxMotionGrad = 1f;
            public const float MinMotionGrad = -1;
            #endregion

            #region Health system
            public const int MinMaxHealth = 1;
            public const int MaxMaxHealth = 10;
            #endregion
        }
        #endregion
    }
}