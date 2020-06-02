using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Initial Position")] public Vector3 playerInitialPosition;


    [Header("First Platform Position")] public Vector3 firstPlatformPosition;

    public bool levelCompleted;

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
    
    public void OnLevelCompleted()
    {
        levelCompleted = true;
        PlayerController.instance.OnStopPlayer(true);
        GUIManager.instance.ShowLevelCompletedMessage();
    }
    
    public void OnLevelFailed()
    {
        levelCompleted = true;
        PlayerController.instance.OnStopPlayer(true);
        GUIManager.instance.ShowLevelFailedMessage();
    }
    
}
