using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int rigtDirection = 1;
    public Transform rightDoor;
    public Transform leftDoor;
    void Start()
    {
        //OpenTheDoor();
    }

    public void OpenTheDoor()
    {
        
        rightDoor.DORotate(new Vector3(0, 0, -90 * rigtDirection), 0.4f);
        leftDoor.DORotate(new Vector3(0, 0, -90 * -rigtDirection), 0.4f);
    }
}
