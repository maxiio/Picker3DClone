using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        OpenTheDoor();
    }

    private void OpenTheDoor()
    {
        transform.DORotate(new Vector3(0, 0, -90 * direction), 0.4f);
    }
}
