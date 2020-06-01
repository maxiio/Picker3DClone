using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class LevelResources : ScriptableObject
{
    [Header("Player Prefab")]
    public GameObject playerPrefab;
    [Header("Platform Prefab")]
    public GameObject platformPrefab;
    [Header("Final Gate Prefab")]
    public GameObject finalGatePrefab;

    private static LevelResources _instance;
    
    public static LevelResources Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load("LevelResources") as LevelResources;
#if UNITY_EDITOR
                if (_instance == null)
                {
                    _instance = CreateInstance<LevelResources>();               
                    AssetDatabase.CreateAsset(_instance, "Assets/Resources/LevelResources.asset");
                    AssetDatabase.SaveAssets();    
                }
#endif              
            }
            
            return _instance;
        }
    }
}