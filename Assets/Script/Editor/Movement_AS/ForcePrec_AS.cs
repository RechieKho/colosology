using UnityEditor;

namespace General.Movement
{
	public class ForcePrec_AS
	{
		[MenuItem("Assets/Create/Motion/ForcePrec_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ForcePrec_SO>();
		}
	}
}
