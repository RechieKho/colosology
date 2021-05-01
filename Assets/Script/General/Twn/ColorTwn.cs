using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Dependency: 
/// LeanTween (Modified)
/// 
/// Notes:
/// CanvasGroup can only change alpha due to technical issues
/// </summary>
namespace General.Tween
{
    public class ColorTwn
    {
        // variable
        public TwnColor twnData;
        private int _currentTwn;
        private bool _isCurrentTwnAvail = false;
        
        public bool isTweening { get { return _isCurrentTwnAvail ? false: LeanTween.isTweening(_currentTwn); } }

        #region Method
        // Constructor 
        public ColorTwn(TwnColor __twnData)
        {
            twnData = __twnData;
            #region Set To origin
            try
            {
                switch (twnData.targetType)
                {
                    case TwnColor.TargetType.gameObject:
                        twnData.target.GetComponent<Renderer>().material.color = twnData.GetValue("origin");
                        break;
                    case TwnColor.TargetType.imgComp:
                        twnData.target.GetComponent<Image>().color = twnData.GetValue("origin");
                        break;
                    case TwnColor.TargetType.canvasGroup:
                        twnData.target.GetComponent<CanvasGroup>().alpha = twnData.GetValue("origin").w;
                        break;
                    case TwnColor.TargetType.txtComp:
                        twnData.target.GetComponent<Text>().color = twnData.GetValue("origin");
                        break;
                    case TwnColor.TargetType.tmpComp:
                        twnData.target.GetComponent<TMP_Text>().color = twnData.GetValue("origin");
                        break;
                    default:
                        Debug.LogError("invalid target type");
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e + " during changing color");
            }
            #endregion
        }

        public void ChangeColor(string __destKey, float __delay = 0)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                switch (twnData.targetType)
                {
                    case TwnColor.TargetType.gameObject:
                        // Leantween method
                        _currentTwn = LeanTween.color(twnData.target, twnData.GetValue(__destKey), twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(()=> { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.imgComp:
                        // Leantween method
                        _currentTwn = LeanTween.color(twnData.target.GetComponent<RectTransform>(), twnData.GetValue(__destKey), twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.canvasGroup:
                        // LeanTween method
                        _currentTwn = LeanTween.alphaCanvas(twnData.target.GetComponent<CanvasGroup>(), twnData.GetValue(__destKey).w, twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.txtComp:
                        // Leantween method
                        _currentTwn = LeanTween.colorText(twnData.target.GetComponent<RectTransform>(), twnData.GetValue(__destKey), twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.tmpComp:
                        // Leantween method
                        _currentTwn = LeanTween.colorTMP_Text(twnData.target.GetComponent<RectTransform>(), twnData.GetValue(__destKey), twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    default:
                        Debug.LogError("invalid target type");
                        _isCurrentTwnAvail = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e + " during changing color");
                _isCurrentTwnAvail = false;
            }
        }

        public void ChangeAlpha(string __destKey, float __delay = 0)
        {
            if (_isCurrentTwnAvail && LeanTween.isTweening(_currentTwn)) return;
            _isCurrentTwnAvail = true;
            try
            {
                switch (twnData.targetType)
                {
                    case TwnColor.TargetType.gameObject:
                        // LeanTween method
                        _currentTwn = LeanTween.alpha(twnData.target, twnData.GetValue(__destKey).w, twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.imgComp:
                        // LeanTween method
                        _currentTwn = LeanTween.alpha(twnData.target.GetComponent<RectTransform>(), twnData.GetValue(__destKey).w, twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.canvasGroup:
                        // LeanTween method
                        _currentTwn = LeanTween.alphaCanvas(twnData.target.GetComponent<CanvasGroup>(), twnData.GetValue(__destKey).w, twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.txtComp:
                        // LeanTween method
                        _currentTwn = LeanTween.alphaText(twnData.target.GetComponent<RectTransform>(), twnData.GetValue(__destKey).w, twnData.time).setEase(twnData.tweenType).setDelay(__delay).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    case TwnColor.TargetType.tmpComp:
                        // Leantween method
                        _currentTwn = twnData.target.GetComponent<TMPro.TMP_Text>().LeanAlphaText(twnData.GetValue(__destKey).w, twnData.time).setIgnoreTimeScale(twnData.ignoreTimeScale).setOnComplete(() => { twnData.callBack(); }).id;
                        break;
                    default:
                        _isCurrentTwnAvail = false;
                        Debug.Log("Invalid target type");
                        break;
                }
            }
            catch (Exception e)
            {
                _isCurrentTwnAvail = false;
                Debug.Log(e + " during changing alpha");
            }
        }
        #endregion
    }
}