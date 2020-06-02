using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    
    [SerializeField] private GameObject ReloadButton;
    [SerializeField] private Text currentlevelNoText;
    [SerializeField] private Text nextlevelNoText;
    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private GameObject levelFailedPanel;
    [SerializeField] private GameObject playerBlocker;


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
        currentlevelNoText.text = ""+ levelNo;
        var nextLevelNo = levelNo+ 1;
        nextlevelNoText.text = ""+ nextLevelNo;
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
    
    
    
}
