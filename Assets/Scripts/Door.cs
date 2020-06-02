using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int rigtDirection = 1;
    [SerializeField] private Transform rightDoor;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private GameObject messageCanvas;
    [SerializeField] private Text messageText;
    void Start()
    {
        //OpenTheDoor();
    }

    public void OpenTheDoor()
    {
        ShowMessage();
        rightDoor.DORotate(new Vector3(0, 0, -90 * rigtDirection), 0.4f);
        leftDoor.DORotate(new Vector3(0, 0, -90 * -rigtDirection), 0.4f);
    }

    private void ShowMessage()
    {
        messageCanvas.SetActive(true);
    }
}
