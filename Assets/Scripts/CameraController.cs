using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private GameObject _player;
    private Vector3 _offset;
    private Vector3 _temp;
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

    public void OnPlayerInstantiate(GameObject player)
    {
        _player = player;
        _offset = transform.position - _player.transform.position;
    }

    private void Update()
    {
        if (_player)
        {
            _temp= transform.position;
            _temp.z = _player.transform.position.z + _offset.z;
            transform.position = _temp;
        }

    }
}
