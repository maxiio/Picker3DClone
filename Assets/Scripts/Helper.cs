using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public float duration = 0.2f;
    public int direction = 1;
    public float rotationAngle=360;
    // Start is called before the first frame update
    void Start()
    {
        PlayRotateAnimation();
    }

    private void PlayRotateAnimation()
    {
        transform.DOLocalRotate(new Vector3(0, 0, rotationAngle*direction), duration, RotateMode.Fast)
            .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
