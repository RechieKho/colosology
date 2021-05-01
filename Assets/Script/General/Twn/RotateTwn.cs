using UnityEngine;
using System;

namespace General.Tween
{
    public class RotateTwn
    {
        // variable
        public TwnVector twnData;
        private int _currentTwn;
        private bool _isCurrentTwnAvail;

        #region Method
        // Constructor
        public RotateTwn(TwnVector __twnData)
        {
            twnData = __twnData;
        }

        public void ChangeRotation(string __key)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                _currentTwn = LeanTween.rotate(twnData.target, twnData.GetValue(__key), twnData.time).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
            }
            catch (Exception e)
            {
                _isCurrentTwnAvail = false;
                Debug.Log(e + " while changing rotation");
            }
        }
        #endregion
    }
}
