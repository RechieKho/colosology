using UnityEditor;

namespace General.Attack
{
	public class MeleeCirc_AS
	{
		[MenuItem("Assets/Create/Attack Data/MeleeCirc_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<MeleeCirc_SO>();
		}
	}
}
