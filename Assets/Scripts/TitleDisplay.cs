using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text label1;
    [SerializeField] private TMP_Text label2;

    public void AssignPage(PageData pageData)
    {
        pageData.Name.callback += name => UpdateLabel(name, label1);
        pageData.Name.callback += name => UpdateLabel(name, label2);
        ManualUpdate(pageData);
    }

    private void ManualUpdate(PageData pageData)
    {
        UpdateLabel(pageData.Name.Value, label1);
        UpdateLabel(pageData.Name.Value, label2);
    }
    private void UpdateLabel(string name, TMP_Text label) => label.text = name;
}
