using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    public GameObject ReloadButton;
    public Text levelNoText;
    public Text HintText;
    public GameObject levelCompletedPanel;
    public GameObject levelFailedPanel;
    public GameObject playerBlocker;
    public GameObject tutorialText;

    private bool _isItTutorial = false;
    
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
    
    
    public void SetLevelText(int levelNo)
    {
        levelNoText.text = "LEVEL " + levelNo;
    }
    
    public void HideInGameCanvasElements()
    {
        var inGameCanvasItems = GameObject.FindGameObjectsWithTag(TagEnums.InGameCanvas.ToString());
        foreach (var item in inGameCanvasItems)
        {
            item.SetActive(false);
        }
    }
    
    public void ShowLevelCompletedMessage()
    {
        HideInGameCanvasElements();
        levelCompletedPanel.SetActive(true);
    }

    public void ShowLevelFailedMessage()
    {
        HideInGameCanvasElements();
        levelFailedPanel.SetActive(true);
    }

    public void OnTapToContinueButtonClicked()
    {
        LevelManager.instance.LoadNextLevel();
    }

    public void OnTapToReplayButtonClicked()
    {
        LevelManager.instance.LoadCurrentLevel();
    }
    
    public void BlockPlayerMove(bool block)
    {
        playerBlocker.SetActive(block);
    }

    public void OnReloadButtonClicked()
    {
        LevelManager.instance.LoadCurrentLevel();
    }

    public void OnHintDataIsReady(string hintText)
    {
        HintText.text = "";
        HintText.DOText(hintText, 1.0f);
    }
    
    
}
