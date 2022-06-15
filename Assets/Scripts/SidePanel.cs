using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    [SerializeField] private Button whatsTheMagicButton;
    [SerializeField] private Button restorePurchaseButton;
    [SerializeField] private TestDataCenter dataCenter;
    [SerializeField] private ClearProgressPopup clearProgressPopup;

    private void Awake()
    {
        whatsTheMagicButton.onClick.AddListener(() =>
        {
            clearProgressPopup.Show();
            DOVirtual.DelayedCall(1.5f, clearProgressPopup.Hide);
        });
        restorePurchaseButton.onClick.AddListener(dataCenter.ClearProgressAnimated);
    }
}
