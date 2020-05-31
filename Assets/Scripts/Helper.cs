using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public float speed = 500f;
    public int direction = 1;

    void Update()
    {
        PlayRotateAnimation();
    }

    private void PlayRotateAnimation()
    {
        transform.Rotate(new Vector3(0,0,1 * speed * direction) * Time.deltaTime);
    }
}
