using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Base")]
    [SerializeField] private GameObject platformBase;

    [Header("Booster Position")]
    [SerializeField] private Transform boosterPosition;
    
    [Header("Objects to Collect Position")]
    [SerializeField] private Transform objectsToCollectPosition;
    [Header("Pool Object")]
    [SerializeField] private Pool pool;

    [Header("Next Platform Point")]
    [SerializeField] private Transform nextPlatformPoint;
    
    private GameObject _booster;
    private Color32 _defaultColor = new Color32(0,0,0,0);

    public void SetPlatform(PlatformData platformData)
    {
        SetPlatformBaseColor(platformData.platformColor); 
        SetPool(platformData);
        CreateBooster(platformData.boosterPrefab);
        CreateObjectsToCollect(platformData.objectsToCollectPrefab);
    }
    private void SetPlatformBaseColor(Color platformBaseColor)
    {
        if (platformBaseColor != _defaultColor)
            platformBase.GetComponent<MeshRenderer>().material.color = platformBaseColor;
    }

    private void SetPool(PlatformData platformData)
    {
        if (!pool)
            return;
        pool.InitCollectedCount(platformData.collectionGoal);
        pool.InitPoolColor(platformData.poolColor);
    }

    private void CreateBooster(GameObject boosterPrefab)
    {
        if (!boosterPosition)
         return;
        
        if (boosterPrefab)
            _booster = Instantiate(boosterPrefab, boosterPosition.position, boosterPrefab.transform.rotation);
    }

    private void CreateObjectsToCollect(GameObject objectsToCollectPrefab)
    {
        if (!objectsToCollectPosition)
            return;
        
        if (objectsToCollectPrefab)
            _booster = Instantiate(objectsToCollectPrefab, objectsToCollectPosition.position, objectsToCollectPrefab.transform.rotation);
    }

    public Vector3 GetNextTransformPoint()
    {
        return nextPlatformPoint.position;
    }
    
}
