using UnityEditor;

namespace General.Audio
{
	public class MinorAudioRegistry_AS
	{
		[MenuItem("Assets/Create/Audio Data/MinorAudio_SO asset")]
		public static void CreateAsset()
		{
			ScriptableObjectUtility.CreateAsset<MinorAudio_SO>();
		}
	}
}
