using UnityEditor;

namespace General.Audio
{
	public class ZonalAudioRegistry_AS
	{
		[MenuItem("Assets/Create/Audio Data/ZonalAudio_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<ZonalAudio_SO>();
		}
	}
}
