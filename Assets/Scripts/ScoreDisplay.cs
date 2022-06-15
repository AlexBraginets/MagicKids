using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel1;
    [SerializeField] private TMP_Text scoreLabel2;
    [SerializeField] private RectTransform scoreLabelsHolder;
    [SerializeField] private RectTransform star;
    private const float RotationDuration = 1f;
    private const float starScale = 1.2f;
    private Tween rotationTween;
    private Tween scoreTween;
    private Sequence scaleSeq;
    private float currentScore;

    public void AssignScoreData(ScoreData scoreData)
    {
        currentScore = scoreData.score.Value;
        scoreData.score.callback += UpdateScore;
        scoreData.score.callback += _ => RotateStar();
        scoreData.score.callback += _ => AnimateScaling();
        UpdateScore(scoreData.score.Value);
    }

    private void UpdateScore(int score)
    {
        if (scoreTween != null) scoreTween.Kill();
        scoreTween = DOTween.To(() => currentScore, x =>
        {
            scoreLabel1.text = ((int)x).ToString();
            scoreLabel2.text = ((int)x).ToString();
            currentScore = x;
        }, score, RotationDuration);
        scoreTween.SetEase(Ease.OutQuad);
        scoreTween.onComplete += () => { scoreTween = null; };

        
    }

    private void AnimateScaling()
    {
        if (scaleSeq != null) return;
        scaleSeq = DOTween.Sequence();
        var scaleTween = scoreLabelsHolder.transform.DOScale(Vector3.one * starScale, RotationDuration);
        scaleTween.SetEase(Ease.OutBack);
        scaleSeq.Append(scaleTween);
        scaleTween = scoreLabelsHolder.transform.DOScale(Vector3.one , RotationDuration*.25f);
        scaleTween.SetEase(Ease.OutBack);
        scaleSeq.Append(scaleTween);
        scaleSeq.onComplete += () => scaleSeq = null;
        scaleSeq.Play();
    }

    private void RotateStar()
    {
        if (rotationTween != null) return;
        rotationTween = star.DORotate(new Vector3(0, 0, 360), RotationDuration, RotateMode.FastBeyond360);
        rotationTween.SetEase(Ease.Linear);
        rotationTween.onComplete = () => { rotationTween = null;};
    }
}