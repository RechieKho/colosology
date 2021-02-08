using UnityEngine;
using UnityEditor;
using General.Data.Motion.SecondGen;

public class MotionNormalPrecAssetScript
{
	[MenuItem("Assets/Create/Motion/MotionNormalPrec asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MotionNormalPrec>();
	}
}