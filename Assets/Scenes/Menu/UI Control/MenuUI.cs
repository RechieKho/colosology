using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.Data.Scene;
using General.Operation.Scene;

namespace Scene.UI
{
    public class MenuUI : MonoBehaviour
    {
        public SceneTransData sceneTransition;
        public void ToPlay() // Play Button
        {
            Debug.Log(QualitySettings.GetQualityLevel());
            Debug.Log("Play");
        }

        public void ToSetting() // Setting Button
        {
            SceneDirector.LoadScene("Setting", sceneTransition);
        }

        public void ToExit() // Exit Button
        {
            Application.Quit();
            Debug.Log("Exit");
        }
    }

}
