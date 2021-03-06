using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance;
    public Vector3 platformPos;
    private GameObject _newPlatform;
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

    public void CreateLevel(Level levelData)
    {
        CreatePlayer(levelData.playerColor);
        CreatePlatforms(levelData);
    }
    
    private void CreatePlatforms(Level levelData)
    {
        var platforms = levelData.platforms;
        if(platformPos == Vector3.zero)
            platformPos = GameManager.instance.firstPlatformPosition;
        var platformPrefab = LevelResources.Instance.platformPrefab;
        var finalGatePrefab = LevelResources.Instance.finalGatePrefab;
        
        for (int i = 0; i < platforms.Count; i++)
        {
            if(platforms[i].isItFinalGate)        
                _newPlatform = Instantiate(finalGatePrefab, new Vector3(platformPos.x, -0.8f, platformPos.z), finalGatePrefab.transform.rotation);
            else
                _newPlatform = Instantiate(platformPrefab, new Vector3(platformPos.x, -0.8f, platformPos.z), platformPrefab.transform.rotation);
            
            var newPlatformComponent = _newPlatform.GetComponent<Platform>();
            newPlatformComponent.SetPlatform(platforms[i]);
            platformPos = newPlatformComponent.GetNextTransformPoint();
        }
        
        EventManager.Instance.onLevelCreated?.Invoke();
        
    }


    private void CreatePlayer(Color color)
    {
        var playerPos = GameManager.instance.playerInitialPosition;
        var playerPrefab = LevelResources.Instance.playerPrefab;
        var player = Instantiate(playerPrefab, playerPos, playerPrefab.transform.rotation);
        player.GetComponent<PlayerController>().SetPlayer(color);
        
        EventManager.Instance.onPlayerInstantiated?.Invoke(player);
    }

    public void LoadNextLevelsPlatforms(Level levelData)
    {
        CreatePlatforms(levelData);
    }
}
