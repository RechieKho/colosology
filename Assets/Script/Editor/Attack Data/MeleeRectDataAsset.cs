using General.Data.AttackData.Melee;
using UnityEditor;

public class MeleeRectDataAsset
{
	[MenuItem("Assets/Create/Attack Data/MeleeRectData asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MeleeRectData>();
	}
}