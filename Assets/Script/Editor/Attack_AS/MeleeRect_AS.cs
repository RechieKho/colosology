using UnityEditor;

namespace General.Attack
{
	public class MeleeRect_AS
	{
		[MenuItem("Assets/Create/Attack Data/MeleeRect_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<MeleeRect_SO>();
		}
	}
}
