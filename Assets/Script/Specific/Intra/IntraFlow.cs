using UnityEngine;
using General.Scene;
using General.Other;
using Specific.Location;

namespace Specific.Intra
{
    public class IntraFlow : MonoBehaviour
    {
        #region enum
        public enum FlowState
        {
            Started,
            Stopped,
            Paused
        }
        #endregion

        // Resources.Load("Assets/Scene Transition/Fade.asset");

        private static FlowState state = FlowState.Stopped;
        public static FlowState State { get; }

        public static void StartFlow(SceneTrans_SO __sceneTrans) // initiate flow only
        {
            // start flow
            if (state != FlowState.Stopped) return;

            // check whether have save point
            if (SavePointManager.IsSavePointSaved())
            {
                // load to save point
                SavePoint savePoint = SavePointManager.GetSavedSavePoint();
                IntraTransition.To(savePoint.scene, savePoint.markName, __sceneTrans);
            }
            else
            {
                // load to preface
                SceneDirector.LoadScene("Preface_Scene", __sceneTrans);
            }
            
        }

        public static void PauseFlow()
        {
            // Pause Flow
            if (state != FlowState.Started) return;
            Freezer.Freeze();
            state = FlowState.Paused;
        }

        public static void UnpauseFlow()
        {
            // unpause flow
            if (state != FlowState.Paused) return;
            Freezer.Unfreeze();
            state = FlowState.Started;
        }

        public static void StopFlow(SceneTrans_SO __sceneTrans)
        {
            if (state == FlowState.Stopped) return;
            // save data
            SavePointManager.SaveSavePoint();
            SceneDirector.LoadScene("Main_Scene", __sceneTrans);
            state = FlowState.Stopped;
        }
    }
}
