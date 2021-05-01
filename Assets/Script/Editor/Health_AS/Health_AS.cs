using UnityEditor;

namespace General.Health
{
	public class Health_AS
	{
		[MenuItem("Assets/Create/Health Data asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<Health_SO>();
		}
	}
}
