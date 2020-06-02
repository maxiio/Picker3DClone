using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;


    public Action onLevelCreated;
    public Action<GameObject> onPlayerInstantiated;
    public Action<Level> onLevelDataReady;
    public Action<bool> onStopPlayer;
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
        onLevelDataReady += LevelCreator.instance.CreateLevel;
        onLevelCreated += GameManager.instance.OnLevelCreated;
        onPlayerInstantiated += CameraController.instance.OnPlayerInstantiate;
        onStopPlayer += PlayerController.instance.OnStopPlayer;
    }
}
