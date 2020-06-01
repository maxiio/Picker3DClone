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
    
    [Header("Pool Object")]
    [SerializeField] private GameObject pool;

    [Header("Next Platform Point")]
    [SerializeField] private Transform nextPlatformPoint;
    
    private GameObject _booster;
    private Color32 defaultColor = new Color32(0,0,0,0);

    public void SetPlatform(PlatformData platformData)
    {
        SetPlatformBaseColor(platformData.platformColor);
        SetPoolColor(platformData.poolColor);
        CreateBooster(platformData.boosterPrefab);
    }
    private void SetPlatformBaseColor(Color platformBaseColor)
    {
        if (platformBaseColor != defaultColor)
            platformBase.GetComponent<MeshRenderer>().material.color = platformBaseColor;
    }
    
    private void SetPoolColor(Color poolColor)
    {
        if (pool == null)
            return;

        if (poolColor != defaultColor)
            pool.GetComponent<MeshRenderer>().material.color = poolColor;
    }

    private void CreateBooster(GameObject boosterPrefab)
    {
        if (boosterPosition == null)
         return;
        
        if (boosterPrefab != null)
            _booster = Instantiate(boosterPrefab, boosterPosition.position, boosterPrefab.transform.rotation);
    }

    public Vector3 GetNextTransformPoint()
    {
        return nextPlatformPoint.position;
    }
}
