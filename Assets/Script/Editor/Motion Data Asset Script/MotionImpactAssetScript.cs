using UnityEngine;
using UnityEditor;
using General.Data.Motion.Legacy;

public class MotionImpactAssetScript
{
	[MenuItem("Assets/Create/Motion/MotionImpact asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MotionImpact>();
	}
}