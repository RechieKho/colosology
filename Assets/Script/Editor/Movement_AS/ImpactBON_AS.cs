using UnityEditor;

namespace General.Movement
{
	public class ImpactBON_AS
	{
		[MenuItem("Assets/Create/Motion/ImpactBON_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ImpactBON_SO>();
		}
	}
}
