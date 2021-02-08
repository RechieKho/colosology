using General.Data.Audio;
using UnityEditor;

public class ZonalAudioRegistryAsset
{
	[MenuItem("Assets/Create/Audio Data/Zonal Audio Registry asset")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<ZonalAudioRegistry>();
	}
}