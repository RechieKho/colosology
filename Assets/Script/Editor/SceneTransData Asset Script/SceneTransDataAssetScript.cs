using UnityEditor;
using General.Data.Scene;

public class SCeneTransDataAssetScript
{
	[MenuItem("Assets/Create/Scene Transition Data asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<SceneTransData>();
	}
}