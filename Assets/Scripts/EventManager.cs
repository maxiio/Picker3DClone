using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;


    public Action onLevelCreated;
    public Action<GameObject> onPlayerInstantiated;
    public Action onLevelCompleted;
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
        onLevelCreated += GameManager.instance.OnLevelCreated;
        onPlayerInstantiated += CameraController.instance.OnPlayerInstantiate;
        onLevelCompleted += GameManager.instance.OnLevelCompleted;
        onLevelCompleted += LevelManager.instance.OnLevelCompleted;
    }
}
