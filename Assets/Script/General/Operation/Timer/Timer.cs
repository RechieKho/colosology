﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.Operation.Task;

/* This namespace is use for:
 * storing Timer class
 */
namespace General.Operation.Timer 
{
    // This class is use for giving easy interface to count.
    public class Timer
    {
        #region Property
        public bool IsRunning { get { return _timer.Running; } }
        public bool IsPaused { get { return _timer.Paused; } }
        #endregion

        #region Variable
        private Timing _timing;
        private float _count;
        private bool _autoLoop;
        private Tasks _timer;
        #endregion

        #region enum
        public enum Timing
        {
            scaledTime,
            unscaledTime
        }
        #endregion

        #region Delegate sig
        public delegate void TimeOut();
        #endregion

        #region event
        private TimeOut _timeOut;
        #endregion

        #region method
        // constructor
        public Timer(Timing timing, float count, bool autoLoop, bool isAutoStart = true, TimeOut timeOut = null)
        {
            _timing = timing;
            _autoLoop = autoLoop;
            _count = count;
            _timeOut += timeOut;

            if(isAutoStart) StartTimer();
        }

        private IEnumerator Counter()
        {
            do
            {
                // return time
                if (_timing == Timing.scaledTime) yield return new WaitForSeconds(_count); // return in scaled time
                else yield return new WaitForSecondsRealtime(_count); // return in unscaled time

                // call _timeOut
                _timeOut?.Invoke();

            } while (_autoLoop);

            _timer = null;
        }

        public void StartTimer()
        {
            if (_timer != null) return;
            _timer = new Tasks(Counter());
        }

        public void StopTimer()
        {
            if (_timer == null) return;
            Debug.Log("Stop Timer");
            _timer.Stop();
            _timer = null;
        }
        #endregion
    }
}