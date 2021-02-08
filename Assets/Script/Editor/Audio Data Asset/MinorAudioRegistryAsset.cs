using General.Data.Audio;
using UnityEditor;

public class MinorAudioRegistryAsset
{
	[MenuItem("Assets/Create/Audio Data/Minor Audio Registry asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<MinorAudioRegistry>();
	}
}