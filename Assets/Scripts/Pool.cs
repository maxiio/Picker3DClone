using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
   
   [Header("Pool Cover")]
   [SerializeField] private GameObject poolCover;
   
   [Header("Collected Count Text")]
   [SerializeField] private Text collectedCountText;
   
   [Header("Door")]
   public Door door;
   
   private int _collectionGoal;
   private int _collectedCount;
   private bool _collectionCompleted;
   private Color32 _defaultColor = new Color32(0,0,0,0);

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(TagEnums.CollectObject.ToString()))
      {
         other.GetComponent<BoxCollider>().enabled = false;
         _collectedCount++;
         SetCollectedCount();
      }
   }

   public void InitCollectedCount(int collectionGoal)
   {
      _collectionGoal = collectionGoal;
      SetCollectedCount();
   }

   public void InitPoolColor(Color poolColor)
   {
      if (poolColor != _defaultColor)
         GetComponent<MeshRenderer>().material.color = poolColor;
   }
   
   public void SetCollectedCount()
   {
      collectedCountText.text = _collectedCount + "/" + _collectionGoal;
      CheckCollectedCount();
   }

   private void CheckCollectedCount()
   {
      if (_collectionCompleted)
         return;
      
      if (_collectedCount != 0 &&_collectedCount >= _collectionGoal)
      {
         _collectionCompleted = true;
         StartCoroutine(CoverThePoolRoutine());
      }
   }

   IEnumerator CoverThePoolRoutine()
   {
      yield return new WaitForSeconds(0.2f);
      door.OpenTheDoor();
      GUIManager.instance.CollectTokens(_collectedCount);
      poolCover.transform.DOMoveY(transform.parent.transform.position.y, 0.5f).SetDelay(0.5f)
         .OnComplete(
            () =>
            {
               PlayerController.instance.OnStopPlayer(false);
               ProgressBarController.instance.AddProgress();
            });

   }
   
}
