using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using General.Operation.Timer;
using General.Data.TwnDest;
using General.Operation.Twn;
using General.Operation.Scene;
using General.Data.Scene;
using Game.Data;

// Animations and setup
namespace Scene.UI
{
    public class IntroUI : MonoBehaviour
    {
        // Task: Update all value from storage, Checking all required value is setted

        // Tweenings
        public GameObject twnTarget;
        public float timeStayOnScreen;
        public float twnTime;
        public LeanTweenType tweenType;
        public RectTransform startRef;
        public RectTransform EndRef;

        public SceneTransData sceneTransition;


        // Start is called before the first frame update
        void Start()
        {
            // Start animation
            StartCoroutine(IntroAnimation());

            // Setups
            Setting.LoadData();

        }

        private IEnumerator IntroAnimation()
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
                    twnData.SetCallBack(null);
                });
                twner.ChangePosition("origin");
            });
        }
    }

}
