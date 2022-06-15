using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform leftArrows;
    [SerializeField] private RectTransform rightArrows;
    [SerializeField] private Image leftArrowsImage;
    [SerializeField] private Image rightArrowsImage;
    [SerializeField] private ScrollRect scrollRect;

    private Tween leftArrowsTween;
    private Tween rightArrowsTween;
    private const float fadeDuration = .2f;
    private void Awake()
    {
        scrollRect.onValueChanged.AddListener(AnimateArrows);
    }

    private void AnimateArrows(Vector2 arg0)
    {
        float x = arg0.x;
        float threshold = .02f;
        float tolerance = .0001f;
        if (x < threshold)
        {
            if (leftArrowsImage.color.a != 0)
                leftArrowsTween = leftArrowsImage.DOFade(0, fadeDuration);
        }
        else
        {
            if (Math.Abs(leftArrowsImage.color.a - 1f) > tolerance) ;
                leftArrowsTween = leftArrowsImage.DOFade(1, fadeDuration);
        }

        if (x > (1-threshold))
        {
            if (rightArrowsImage.color.a != 0)
                rightArrowsTween = rightArrowsImage.DOFade(0, fadeDuration);
        }
        else
        {
            if (Math.Abs(rightArrowsImage.color.a - 1) > tolerance)
                rightArrowsTween = rightArrowsImage.DOFade(1, fadeDuration);
        }
    }
}
