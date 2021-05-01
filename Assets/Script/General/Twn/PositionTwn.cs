using UnityEngine;
using System;

namespace General.Tween
{
    public class PositionTwn
    {
        // variable
        public TwnVector twnData;
        private int _currentTwn;
        private bool _isCurrentTwnAvail;

        #region Method
        // Constructor
        public PositionTwn(TwnVector __twnData)
        {
            twnData = __twnData;
        }

        public void ChangePosition(string __key)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                _currentTwn = LeanTween.move(twnData.target, twnData.GetValue(__key), twnData.time).setEase(twnData.tweenType).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack?.Invoke(); }).id;
            } 
            catch(Exception e)
            {
                _isCurrentTwnAvail = false;
                Debug.Log(e + " while changing position");
            }
        }
        #endregion
    }
}
