using System.Collections;
using UnityEngine;
using General.Other;

/* This namespace is use for:
 * storing Timer class
 */
namespace General.Coroutine 
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
        private bool _isFreezing = false;
        private bool _isFreezable;
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
        public Timer(Timing timing, float count, bool autoLoop, bool isAutoStart = true, TimeOut timeOut = null, bool isFreezable = false)
        {
            _timing = timing;
            _autoLoop = autoLoop;
            _count = count;
            _timeOut += timeOut;

            _isFreezable = isFreezable;
            if (isFreezable) Freezer.trigger += Freeze;
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
            if (_timer != null || _isFreezing) return;
            _timer = new Tasks(Counter(), isFreezable: _isFreezable);
        }

        public void StopTimer()
        {
            if (_timer == null || _isFreezing) return;
            Debug.Log("Stop Timer");
            _timer.Stop();
            _timer = null;
        }

        private void Freeze(bool __freeze)
        {
            _isFreezing = __freeze;
        }
        #endregion
    }
}