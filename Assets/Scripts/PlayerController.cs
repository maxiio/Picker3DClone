using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private const float SpeedZ = 15.0f;

    [SerializeField] private List<GameObject> helpers;

    [SerializeField] private MeshRenderer playerRenderer;

    [SerializeField] private Transform endpointTransform;

    private float _speedX = 3.7f;
    private float _speedZ = 8.0f;
    private Rigidbody _rb;
    private float _direction;
    private Vector3 _delta;
    private bool _clickStarted;
    private bool _stopMoving;
    private Vector3 _lastPos;
    private bool _finishLinePassed;

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        MakeInstance();
        _speedZ = SpeedZ;
    }
    public void SetPlayer(Color color)
    {
        Color32 defaultColor = new Color32(0,0,0,0);
        if (color != defaultColor)
            playerRenderer.material.color = color;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            _lastPos = Input.mousePosition;
            _clickStarted = true;
        }
        else if (Input.GetMouseButton(0) )
        {
            if (_clickStarted)
            {
                _delta = Input.mousePosition - _lastPos;
            }

            if (Mathf.Abs(_delta.x) != 0f)
            {
                float h= Input.GetAxis("Mouse X");

                if (h<0)
                {
                    _direction = -1f;
                }
                else
                {
                    _direction = 1f;
                }
            }
            else
            {
                _direction = 0;
            }

            _lastPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _clickStarted = false;
            _direction = 0;
        }

        if (_stopMoving)
            _speedZ = 0;
        
        _rb.velocity = new Vector3(_direction * _speedX, 0, 1.0f * _speedZ) ;

    }

    private void SetHelpersActive(bool isActive)
    {
        foreach (var helper in helpers)
        {
            helper.SetActive(isActive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagEnums.CollectObject.ToString()))
        {
            other.gameObject.layer = (int)LayerEnums.Collected;
        }
        if (!_stopMoving && other.CompareTag(TagEnums.CheckPoint.ToString()))
        {
            other.enabled = false;
            OnStopPlayer(true);
        }
        if (other.CompareTag(TagEnums.Booster.ToString()))
        {
            SetHelpersActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag(TagEnums.FinishLine.ToString()) && !_finishLinePassed)
        {
            _finishLinePassed = true;
            BoostPlayer();
            EventManager.Instance.onInitNextLevel?.Invoke();
        }
        if (other.CompareTag(TagEnums.LevelEndPoint.ToString()) && !GameManager.instance.levelCompleted)
        {
            EventManager.Instance.onLevelCompleted?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagEnums.CollectObject.ToString()))
        {
            other.gameObject.layer = (int)LayerEnums.Default;
        }
    }

    public void OnStopPlayer(bool isStopped)
    {
        if (isStopped)
        {
            _stopMoving = true;
            _speedZ = 0;
            SetHelpersActive(false);
        }
        else
        {
            _stopMoving = false;
            _speedZ = SpeedZ;
        }
    }

    public void BoostPlayer()
    {
        _speedZ += 30f;
    }
}

