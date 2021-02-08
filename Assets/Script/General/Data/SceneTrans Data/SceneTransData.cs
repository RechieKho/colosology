using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace General.Data.Scene
{
    public class SceneTransData : ScriptableObject
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