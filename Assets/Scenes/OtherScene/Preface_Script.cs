using UnityEngine;
using General.Scene;
using General.Coroutine;
using Specific.Intra;
using Specific.Location;

// Preface only run on first time
public class Preface_Script : MonoBehaviour
{
    [Header("Transition")]
    public SceneTrans_SO sceneTrans;
    public string sceneName;
    public string markName;
    [Header("Preface length")]
    public float timeLength;

    // Start is called before the first frame update
    void Start()
    {
        SavePointManager.LastSavePoint = new SavePoint(sceneName, markName);
        new Timer(Timer.Timing.unscaledTime, timeLength, false, timeOut: () => {
            IntraTransition.To(sceneName, markName, sceneTrans);
        });
    }
}
