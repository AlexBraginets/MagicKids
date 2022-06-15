using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesContainer : MonoBehaviour
{
    [SerializeField] private PageView[] pageViews;

    public void Inject(PagesData pagesData)
    {
        if (pagesData.pages.Value.Count != pageViews.Length)
        {
            throw new ArgumentException("Parameter pagesData does not have the same number of elements as there are views.");
        }

        for (int i = 0; i < pagesData.pages.Value.Count; i++)
        {
            var view = pageViews[i];
            var pageData = pagesData.pages.Value[i];
            view.AssignPage(pageData);
        }
    }
}
