using UnityEditor;

namespace General.Movement
{
	public class Force_AS
	{
		[MenuItem("Assets/Create/Motion/Force_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<Force_SO>();
		}
	}
}

