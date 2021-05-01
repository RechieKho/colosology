using UnityEngine;

namespace Specific
{
    public static class StartUp
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Run()
        {
            // Run when game start (Load IntroL_Scene)
            //SceneManager.LoadScene("IntroL_Scene"); // I think this can be deleted when build as this is only making my development progress easier
        }
    }
}

