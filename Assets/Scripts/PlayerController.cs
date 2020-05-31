using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private List<GameObject> helpers;

    [SerializeField] private Transform endpointTransform;
    public Vector2 direction;
    private float editorSpeed = 100.0f;
    private float speed = 5.0f;
    private Rigidbody rb;
    private float velocityX;
    

    public Vector2 lastPos;
    
    private void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0))
        {
            float h= Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            Vector3 movement = new Vector3(h, 0 , 0);
            rb.AddForce(movement * 500);
            if (h<0)
            {
                velocityX = -1f;
            }
            else
            {
                velocityX = 1f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            velocityX = 0;
        }


        rb.velocity = new Vector3(velocityX * 3, 0, 1.0f * 10) ;
        
    }
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
       // transform.DOMoveZ(endpointTransform.position.z, 15f).SetEase(Ease.Linear);
        SetHelpersActive(true);
    }

    private void SetHelpersActive(bool isActive)
    {
        foreach (var helper in helpers)
        {
            helper.SetActive(isActive);
        }
    }


}

