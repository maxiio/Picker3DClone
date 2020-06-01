using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformData
{
    [Header("Is it Final Gate ?")]
    public bool isItFinalGate;
    [Header("Booster")]
    public GameObject boosterPrefab;
    [Header("Objects To Collect")]
    public GameObject objectsToCollectPrefab;
    [Header("Platform Color")]
    public Color platformColor;
    [Header("Pool Color")]
    public Color poolColor;
    
}
