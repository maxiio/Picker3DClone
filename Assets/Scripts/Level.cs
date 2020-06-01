using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Level : ScriptableObject
{

    [Header("Player Color")] 
    public Color playerColor;
    [Header("Platforms")]
    public List<PlatformData> platforms;


}
