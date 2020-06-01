using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Levels : ScriptableObject
{

    [Header("Levels")]
    public List<Level> levels;

    public static Levels instance;
    
    public static Levels Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load("Levels") as Levels;
#if UNITY_EDITOR
                if (instance == null)
                {
                    instance = CreateInstance<Levels>();               
                    AssetDatabase.CreateAsset(instance, "Assets/Resources/Levels.asset");
                    AssetDatabase.SaveAssets();    
                }
#endif              
            }
            
            return instance;
        }
    }
}
