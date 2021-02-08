using UnityEngine;
using UnityEditor;
using General.Data.Motion.SecondGen;

public class MotionImpactPrecAssetScript
{
	[MenuItem("Assets/Create/Motion/MotionImpactPrec asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MotionImpactPrec>();
	}
}