using UnityEditor;


namespace General.Movement
{
	public class Impact_AS
	{
		[MenuItem("Assets/Create/Motion/Impact_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<Impact_SO>();
		}
	}
}
