using General.Scene;
using Specific.Location;

namespace Specific.Intra
{
    public static class IntraTransition
    {
        public static void To(string __sceneName, string __markName, SceneTrans_SO __sceneTransition)
        {
            IntroductoryMark.MarkName = __markName;
            SceneDirector.LoadScene(__sceneName, __sceneTransition);
        }
    }
}

