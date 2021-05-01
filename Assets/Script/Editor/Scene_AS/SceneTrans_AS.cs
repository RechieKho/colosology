using UnityEditor;

namespace General.Scene
{
	public class SceneTrans_AS
	{
		[MenuItem("Assets/Create/Scene Transition Data asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<SceneTrans_SO>();
		}
	}
}


