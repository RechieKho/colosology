using UnityEngine;
using UnityEditor;
using General.Data.HealthSystem;

public class HealthDataAssetScript
{
	[MenuItem("Assets/Create/Health Data asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<HealthData>();
	}
}