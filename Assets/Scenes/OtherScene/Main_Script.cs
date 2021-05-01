using UnityEngine;
using General.Scene;
using Specific.Intra;

public class Main_Script : MonoBehaviour
{
    [Header("Trasition")]
    public SceneTrans_SO sceneTransData;

    public void StartGame()
    {
        IntraFlow.StartFlow(sceneTransData);
    }

}
