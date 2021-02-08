using UnityEngine;
using UnityEditor;
using General.Data.Motion.BranchOut;

public class MotionImpactGradAssetScript
{
	[MenuItem("Assets/Create/Motion/MotionImpactGrad asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MotionImpactGrad>();
	}
}