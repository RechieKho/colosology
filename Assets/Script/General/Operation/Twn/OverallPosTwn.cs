﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.Data.TwnDest;
using System;

namespace General.Operation.Twn
{
    public class OverallPosTwn
    {
        // variable
        public TwnNormData twnData;
        private int _currentTwn;
        private bool _isCurrentTwnAvail;

        #region Method
        // Constructor
        public OverallPosTwn(TwnNormData __twnData)
        {
            twnData = __twnData;
        }

        public void ChangePosition(string __key)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                _currentTwn = LeanTween.move(twnData.target, twnData.GetValue(__key), twnData.time).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
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
