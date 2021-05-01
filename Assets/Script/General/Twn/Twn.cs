using System.Collections.Generic;
using UnityEngine;

namespace General.Tween
{
    // These classes will act as a Dictionary to save destinations

    public abstract class Twn
    {
        #region Variable
        public GameObject target;
        public float time;
        public LeanTweenType tweenType; // it is better to unify tween type
        public bool ignoreTimeScale;
        public delegate void CallBack();
        public CallBack callBack;
        #endregion
    }

    // For Color and speacially made for leantween 
    public class TwnColor : Twn
    {
        /// <summary>
        /// TwnColor is use to store color for sprites (3D object is not included)
        /// canvasGroup can only tween alpha
        /// </summary>

        #region Enum
        public enum TargetType
        {
            gameObject,
            imgComp, // also can be use for button and etc.
            canvasGroup,
            txtComp,
            tmpComp // text mesh pro
        }
        #endregion

        #region Variable
        private IDictionary<string, Vector4> destDict = new Dictionary<string, Vector4>(); // a dest mean a destination, a marked point that will be the destination
        public TargetType targetType;
        #endregion

        #region Methods
        // constructor
        public TwnColor(GameObject __target, Color __origin, string __key, Color __color, TargetType __targetType, float __time, LeanTweenType __tweenType, bool __ignoreTimeScale = true, CallBack __callback = null)
        {
            callBack = __callback;
            ignoreTimeScale = __ignoreTimeScale;
            SetTargetType(__targetType);
            target = __target;
            time = __time;
            tweenType = __tweenType;
            AddDest("origin", __origin);
            AddDest(__key, __color);
        }

        #region Manage destDict
        // Add Dest
        public bool AddDest(string __key, Color __color) // return true if add successfully
        {
            if (HaveDest(__key) || HaveDest(__color)) return false;
            destDict.Add(__key, __color);
            return true;
        }

        // Remove Dest
        public void RemoveDest(string __key)
        {
            if (!HaveDest(__key)) return;
            destDict.Remove(__key);
        }

        // Update Color
        public bool UpdateDestValue(string __key, Color __color) // return true if something changed
        {
            if (!HaveDest(__key)) return false;
            destDict[__key] = __color;
            return true;
        }

        // Update Key ** Not advisable to change key
        public bool UpdateDestKey(Color __color, string __key) // return ture if something changed
        {
            string oldKey = GetKey(__color);
            if (oldKey == null) return false;
            RemoveDest(oldKey);
            AddDest(__key, __color);
            return true;
        }
        #endregion

        #region Getter
        // Check if have Dest
        public bool HaveDest(string __key)
        {
            return destDict.ContainsKey(__key);
        }
        public bool HaveDest(Color __color)
        {
            string key = GetKey(__color);
            if (key != null) return true;
            else return false;
        }

        // Get Color
        public Vector4 GetValue(string __key)
        {
            return destDict[__key];
        }

        // Get Key
        public string GetKey(Color __color)
        {
            foreach (var dest in destDict)
            {
                if (dest.Value == (Vector4)__color) return dest.Key;
            }
            return null;
        }

        public void SetTargetType(TargetType __targetType)
        {
            targetType = __targetType;
        }
        #endregion



        // set Callback
        public void SetCallBack(CallBack __callBack)
        {
            callBack = __callBack;
        }

        #endregion
    }

    // For Vector3 (or 2) (position, size and etc.) and speacially made for leantween 
    public class TwnVector : Twn
    {
        /// <summary>
        /// TwnVector is use to store Vector2 points
        /// </summary>

        #region Variable
        private IDictionary<string, Vector3> destDict = new Dictionary<string, Vector3>(); // a dest mean a destination, a marked point that will be the destination
        #endregion

        #region Methods
        // constructor
        public TwnVector(GameObject __target, Vector3 __origin, string __key, Vector3 __vector2, float __time, LeanTweenType __tweenType, bool __ignoreTimeScale = true, CallBack __callBack = null)
        {
            callBack = __callBack;
            ignoreTimeScale = __ignoreTimeScale;
            target = __target;
            time = __time;
            tweenType = __tweenType;
            AddDest("origin", __origin);
            AddDest(__key, __vector2);
        }

        #region Manage destDict
        // Add Dest
        public bool AddDest(string __key, Vector3 __vector2) // return true if add successfully
        {
            if (HaveDest(__key) || HaveDest(__vector2)) return false;
            destDict.Add(__key, __vector2);
            return true;
        }

        // Remove Dest
        public void RemoveDest(string __key)
        {
            if (!HaveDest(__key)) return;
            destDict.Remove(__key);
        }

        // Update Value
        public bool UpdateDestValue(string __key, Vector3 __vector2) // return true if something changed
        {
            if (!HaveDest(__key)) return false;
            destDict[__key] = __vector2;
            return true;
        }

        // Update Key ** Not advisable to change key
        public bool UpdateDestKey(Vector3 __vector2, string __key) // return ture if something changed
        {
            string oldKey = GetKey(__vector2);
            if (oldKey == null) return false;
            RemoveDest(oldKey);
            AddDest(__key, __vector2);
            return true;
        }
        #endregion

        #region Getter
        // Check if have Dest
        public bool HaveDest(string __key)
        {
            return destDict.ContainsKey(__key);
        }
        public bool HaveDest(Vector3 __vector2)
        {
            string key = GetKey(__vector2);
            if (key != null) return true;
            else return false;
        }

        // Get Value
        public Vector3 GetValue(string __key)
        {
            return destDict[__key];
        }

        // Get Key
        public string GetKey(Vector3 __vector2)
        {
            foreach (var dest in destDict)
            {
                if (dest.Value == __vector2) return dest.Key;
            }
            return null;
        }
        #endregion

        // set Callback
        public void SetCallBack(CallBack __callBack)
        {
            callBack = __callBack;
        }

        #endregion
    }
}

