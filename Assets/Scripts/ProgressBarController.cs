using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public static ProgressBarController instance;
    [SerializeField] private Color fillColor;
    [SerializeField] private List<Image> barFillAreas;

    private int _progressIndex = 0;

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        MakeInstance();
    }

    public void AddProgress()
    {
        _progressIndex = _progressIndex >= barFillAreas.Count ? barFillAreas.Count-1 : _progressIndex;
        barFillAreas[_progressIndex].color = fillColor;
        _progressIndex++;
    }
}
