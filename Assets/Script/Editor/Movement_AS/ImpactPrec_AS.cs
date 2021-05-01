using UnityEditor;

namespace General.Movement
{
	public class ImpactPrec_AS
	{
		[MenuItem("Assets/Create/Motion/ImpactPrec_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ImpactPrec_SO>();
		}
	}
}
