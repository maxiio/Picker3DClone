using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public List<GameObject> helpers;
    private Rigidbody rb;
    private Vector3 inputVector;

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
        rb = GetComponent<Rigidbody>();
        SetHelpersActive(true);
    }

    private void SetHelpersActive(bool isActive)
    {
        foreach (var helper in helpers)
        {
            helper.SetActive(isActive);
        }
    }

    private void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"),rb.velocity.y,0.5f);
        rb.velocity = inputVector*5;
    }
}
