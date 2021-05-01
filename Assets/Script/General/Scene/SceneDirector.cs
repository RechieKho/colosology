using UnityEngine;
using UnityEngine.SceneManagement;
using General.Tween;

namespace General.Scene
{
    public class SceneDirector : MonoBehaviour
    {
        #region Variable
        private static SceneDirector _singleton;
        private static Canvas _canvas;
        private static bool _isBusy = false;
        public delegate void OnLoadEnd(params string[] __parameter);
        public static OnLoadEnd onLoadEnd;
        #endregion

        #region Method
        public static void LoadScene(string __target,SceneTrans_SO __data, params string[] __parameter)
        {
            if (_isBusy) return;
            _isBusy = true;

            #region singleton
            if (_singleton == null)
            {
                _singleton = CreateCanvas().AddComponent<SceneDirector>();
                _canvas = _singleton.GetComponent<Canvas>();
            }
            #endregion

            // create transition object
            Trans trans = null;
            switch (__data.twnProperty)
            {
                case SceneTrans_SO.TwnProperty.alpha:
                    trans = new TransAlpha(__data);
                    break;
                case SceneTrans_SO.TwnProperty.position:
                    trans = new TransPos(__data);
                    break;
                case SceneTrans_SO.TwnProperty.rotation:
                    trans = new TransRot(__data);
                    break;
                case SceneTrans_SO.TwnProperty.scale:
                    trans = new TransScale(__data);
                    break;
            }



            // Init Load Scene
            trans.StartTransition(() => {
                SceneManager.LoadSceneAsync(__target).completed += (asyncOperation) =>
                {
                    onLoadEnd?.Invoke(__parameter);
                    trans.ExitTransition(()=> {
                        trans.Clear();
                        _isBusy = false;
                    });
                };
            });
        }

        private static GameObject CreateCanvas()
        {
            GameObject canvas = new GameObject("canvas");
            Canvas comp = canvas.AddComponent<Canvas>();
            comp.renderMode = RenderMode.ScreenSpaceOverlay;
            comp.sortingOrder = 10; // MAKE THIS HIGHEST VALUE TO ENSURE COVER COVERS EVERTHING
            DontDestroyOnLoad(canvas);
            return canvas;
        }
        #endregion

        #region sub class
        private abstract class Trans
        {
            public GameObject _cover;
            public TwnColor _twnColorData;
            public TwnVector _twnNormData;
            

            public abstract void StartTransition(Twn.CallBack __callBack = null);
            public abstract void ExitTransition(Twn.CallBack __callBack = null);
            public void Clear()
            {
                _twnColorData?.SetCallBack(null);
                _twnNormData?.SetCallBack(null);
                Destroy(_cover);
            }
        }

        private class TransAlpha : Trans
        {
            private ColorTwn _twner;
            public TransAlpha(SceneTrans_SO __data)
            {
                // Now we have cover prefab, so we need to spawn it
                _cover = Instantiate(__data.cover, _canvas.transform);

                _twnColorData = new TwnColor(
                    __target: _cover, 
                    __origin: new Color(0,0,0, __data.refStart.GetComponent<CanvasGroup>().alpha), 
                    __key: "cover", 
                    __color: new Color(0,0,0, __data.refEnd.GetComponent<CanvasGroup>().alpha), 
                    __targetType: TwnColor.TargetType.canvasGroup,
                    __time: __data.twnTime, 
                    __tweenType: __data.leanTweenType);
                _twner = new ColorTwn(_twnColorData);
            }

            public override void StartTransition(Twn.CallBack __callBack = null)
            {
                _twnColorData.SetCallBack(__callBack);
                _twner.ChangeAlpha("cover");
            }

            public override void ExitTransition(Twn.CallBack __callBack = null)
            {
                _twnColorData.SetCallBack(__callBack);
                _twner.ChangeAlpha("origin");
            }
        }

        private class TransPos : Trans
        {
            private PositionTwn _twner;
            public TransPos(SceneTrans_SO __data)
            {
                // Now we have cover prefab, so we need to spawn it
                _cover = Instantiate(__data.cover, _canvas.transform);

                _twnNormData = new TwnVector(
                    __target: _cover,
                    __origin: __data.refStart.GetComponent<RectTransform>().position,
                    __key: "cover",
                    __vector2: __data.refEnd.GetComponent<RectTransform>().position,
                    __time: __data.twnTime,
                    __tweenType: __data.leanTweenType);
                _twner = new PositionTwn(_twnNormData);

            }

            public override void StartTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangePosition("cover");
            }

            public override void ExitTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangePosition("origin");
            }
        }

        private class TransRot : Trans
        {
            private RotateTwn _twner;

            public TransRot(SceneTrans_SO __data)
            {
                // Now we have cover prefab, so we need to spawn it
                _cover = Instantiate(__data.cover, _canvas.transform);

                _twnNormData = new TwnVector(
                    __target: _cover,
                    __origin: __data.refStart.GetComponent<RectTransform>().eulerAngles,
                    __key: "cover",
                    __vector2: __data.refEnd.GetComponent<RectTransform>().eulerAngles,
                    __time: __data.twnTime,
                    __tweenType: __data.leanTweenType);
                _twner = new RotateTwn(_twnNormData);

            }

            public override void StartTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangeRotation("cover");
            }

            public override void ExitTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangeRotation("origin");
            }
        }

        private class TransScale : Trans
        {
            private ScaleTwn _twner;
            public TransScale(SceneTrans_SO __data)
            {
                // Now we have cover prefab, so we need to spawn it
                _cover = Instantiate(__data.cover, _canvas.transform);

                _twnNormData = new TwnVector(
                    __target: _cover,
                    __origin: __data.refStart.GetComponent<RectTransform>().localScale,
                    __key: "cover",
                    __vector2: __data.refEnd.GetComponent<RectTransform>().localScale,
                    __time: __data.twnTime,
                    __tweenType: __data.leanTweenType);
                _twner = new ScaleTwn(_twnNormData);

            }

            public override void StartTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangeScale("cover");
            }

            public override void ExitTransition(Twn.CallBack __callBack = null)
            {
                _twnNormData.SetCallBack(__callBack);
                _twner.ChangeScale("origin");
            }
        }
        #endregion
    }
}