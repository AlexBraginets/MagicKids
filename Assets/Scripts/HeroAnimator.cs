using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    [SerializeField] private HeroAudioPlayer audioPlayer;
    [SerializeField] private HeroAlphaController alphaController;

    private const float AnimationFPS = 30f;
    private float Frames2Duration(int frames) => frames / AnimationFPS;

    public void Appear(int frameDuration)
    {
        float duration = Frames2Duration(frameDuration);
        DOTween.To(() => 0f, alphaController.ApplyAlpha, 1f, duration);
    }

    public void Dissolve(int frameDuration)
    {
        float duration = Frames2Duration(frameDuration);
        DOTween.To(() => 1f, alphaController.ApplyAlpha, 0f, duration);
    }

    public void PlayFirstAudio() => audioPlayer.Play(0);
    public void PlaySecondAudio() => audioPlayer.Play(1);
}