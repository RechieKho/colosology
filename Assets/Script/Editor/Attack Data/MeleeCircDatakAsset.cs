using General.Data.AttackData.Melee;
using UnityEditor;

public class MeleeCircDataAsset
{
	[MenuItem("Assets/Create/Attack Data/MeleeCircData asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MeleeCircData>();
	}
}