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
    [SerializeField] private Text currentTokenCounterText;
    [SerializeField] private Text currentlevelNoText;
    [SerializeField] private Text nextLevelNoText;
    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private GameObject levelFailedPanel;
    [SerializeField] private GameObject playerBlocker;


    private int _currentTokenCount = 0;
    private float _duration = 0.5f;
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

    private void Start()
    {   
        SetTokenCountText();
    }

    private void SetTokenCountText()
    {
        currentTokenCounterText.text = ""+ GameManager.instance.totalTokenCount;
    }
    public void SetLevelText(int levelNo)
    {
        currentlevelNoText.text = ""+ levelNo;
        var nextLevelNo = levelNo+ 1;
        nextLevelNoText.text = ""+ nextLevelNo;
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

    public void CollectTokens(int tokenCount)
    {
        StartCoroutine(CountTo(GameManager.instance.totalTokenCount + tokenCount));
    }
    
    IEnumerator CountTo (int target) {
        int start = GameManager.instance.totalTokenCount;
        for (float timer = 0; timer < _duration; timer += Time.deltaTime) {
            float progress = timer / _duration;
            _currentTokenCount = (int)Mathf.Lerp (start, target, progress);
            currentTokenCounterText.text = "" + _currentTokenCount;
            yield return null;
        }
        
        GameManager.instance.totalTokenCount = target;
        SetTokenCountText();
    }
}
