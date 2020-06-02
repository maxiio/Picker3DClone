using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager _instance;


    public Action onLevelCreated;
    public Action<GameObject> onPlayerInstantiated;
    public Action onLevelCompleted;
    public static EventManager Instance
    {
        //todo: check this implementation
        get
        {
            if (_instance == null)
            {
                var manager = GameObject.Find("EventManager");
                manager = manager == null ? new GameObject("EventManager") : manager;
                _instance = manager.GetComponent<EventManager>();
            }

            return _instance;
        }
    }
    private void Start()
    {
        onLevelCreated += GameManager.instance.OnLevelCreated;
        onPlayerInstantiated += CameraController.instance.OnPlayerInstantiate;
        onLevelCompleted += GameManager.instance.OnLevelCompleted;
        onLevelCompleted += LevelManager.instance.OnLevelCompleted;
    }
}
