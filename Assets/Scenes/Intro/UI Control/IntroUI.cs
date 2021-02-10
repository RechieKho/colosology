using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using General.Operation.Timer;
using General.Data.TwnDest;
using General.Operation.Twn;
using General.Operation.Scene;
using General.Data.Scene;
using General.Data.Audio;
using Game.Core;

// Animations and setup
namespace Scene.UI
{
    // This is not that good... IntroUI become very important because it becomes the setup of the game
    public class IntroUI : MonoBehaviour
    {
        // Task: Update all value from storage, Checking all required value is setted

        // musics
        public AudioMixer audioMixer;
        public MinorAudioRegistry audioRegistry;
        public string bgmName;
        [Space]

        // Tweenings
        public GameObject twnTarget;
        public float timeStayOnScreen;
        public float twnTime;
        public LeanTweenType tweenType;
        public RectTransform startRef;
        public RectTransform EndRef;

        public SceneTransData sceneTransition;

        private delegate void OnIntroEnd();


        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Setup());

            // Start animation
            StartCoroutine(IntroAnimation(EndOfIntro));

        }

        private IEnumerator IntroAnimation(OnIntroEnd __onIntroEnd)
        {
            yield return new WaitForEndOfFrame();
            // setup twner
            TwnNormData twnData = new TwnNormData(
                    twnTarget,
                    startRef.position,
                    "OnScreen",
                    EndRef.position,
                    twnTime,
                    tweenType
                );
            OverallPosTwn twner = new OverallPosTwn(twnData);

            twner.ChangePosition("OnScreen");


            // Set Callbacks
            Timer timer = new Timer(Timer.Timing.unscaledTime, timeStayOnScreen, false, timeOut: () => {
                twnData.SetCallBack(() => {
                    SceneDirector.LoadScene("Menu", sceneTransition); // this will need to change as we need to direct to first time set if user is first time
                    __onIntroEnd?.Invoke();
                    twnData.SetCallBack(null);
                });
                twner.ChangePosition("origin");
            });
        }

        private void EndOfIntro()
        {
            // Play BGM
            Audio.InsertAudio(audioRegistry, bgmName);
        }

        private IEnumerator Setup()
        {
            yield return new WaitForEndOfFrame();
            // Get Setting data
            Setting.LoadData();

            // Setup Audio
            Audio.SetAudioMixer(audioMixer);
            Audio.UpdateAll();

            // Setup Detail
            QualitySettings.SetQualityLevel(Mathf.RoundToInt(Setting.Detail * 6), false);
        }
    }

}
