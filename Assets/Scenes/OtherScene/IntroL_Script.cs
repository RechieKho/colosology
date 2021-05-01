using UnityEngine;
using General.Scene;
using General.Coroutine;

public class IntroL_Script : MonoBehaviour
{
    [Header("Transition")]
    public SceneTrans_SO sceneTransData;
    public string targetScene;
    [Header("Introduction length")]
    public float timeLength;

    void Awake()
    {
        // I am just gonna make a scene transition for now, Procedural animation is for later
        new Timer(Timer.Timing.unscaledTime, timeLength, false, timeOut: () => { 
            SceneDirector.LoadScene(targetScene, sceneTransData);
        });
    }
}
