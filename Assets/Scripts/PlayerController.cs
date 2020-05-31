using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public List<GameObject> helpers;

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
        SetHelpersActive(true);
    }
    
    private void Update()
    {
        
    }

    private void SetHelpersActive(bool isActive)
    {
        foreach (var helper in helpers)
        {
            helper.SetActive(isActive);
        }
    }
}
