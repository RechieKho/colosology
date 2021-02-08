using UnityEngine;
using UnityEditor;
using General.Data.Motion.Legacy;

public class MotionNormalAssetScript
{
	[MenuItem("Assets/Create/Motion/MotionNormal asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MotionNormal>();
	}
}