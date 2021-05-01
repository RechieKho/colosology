using UnityEngine;

namespace General.Scene
{
    public class SceneTrans_SO : ScriptableObject
    {
        public enum TwnProperty
        {
            position,
            rotation,
            scale,
            alpha
        }

        public GameObject cover; // always disable cover's image first
        public RectTransform refStart; // a ref which only need Rect Transform
        public RectTransform refEnd; // a ref which only need Rect Transform
        public TwnProperty twnProperty;
        public float twnTime;
        public LeanTweenType leanTweenType;
    }
}