using UnityEngine;
using General.Data.TwnDest;
using System;

namespace General.Operation.Twn
{
    public class OverallScaleTwn
    {
        // variable
        public TwnNormData twnData;
        private int _currentTwn;
        private bool _isCurrentTwnAvail;

        #region Method
        // Constructor
        public OverallScaleTwn(TwnNormData __twnData)
        {
            twnData = __twnData;
        }

        public void ChangeScale(string __key)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                _currentTwn = LeanTween.scale(twnData.target, twnData.GetValue(__key), twnData.time).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
            }
            catch (Exception e)
            {
                _isCurrentTwnAvail = false;
                Debug.Log(e + " while changing scale");
            }
        }
        #endregion
    }

}
