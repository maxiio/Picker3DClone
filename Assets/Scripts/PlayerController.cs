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
    private float editorSpeed = 100.0f;
    private float speedX = 2.0f;
    private float speedZ = 8.0f;
    private Rigidbody rb;
    private float direction;
    private Vector3 delta;
    private bool clickStarted = false;
    

    public Vector3 lastPos;
    
    private void FixedUpdate()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            lastPos = Input.mousePosition;
            clickStarted = true;
        }
        else if ( Input.GetMouseButton(0) )
        {
            if (clickStarted)
            {
                delta = Input.mousePosition - lastPos;
            }

            if (Mathf.Abs(delta.x) > 2f)
            {
                float h= Input.GetAxis("Mouse X");

                if (h<0)
                {
                    direction = -1f;
                }
                else
                {
                    direction = 1f;
                }
            }
            
            Debug.Log( "delta X : " + delta.x );

            lastPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            clickStarted = false;
            direction = 0;
        }
        
        rb.velocity = new Vector3(direction * speedX, 0, 1.0f * speedZ) ;

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

