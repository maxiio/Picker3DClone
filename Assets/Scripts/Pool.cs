using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
   public Text collectedCount;
   private int _collectionCount;
   private int _collectedCount;
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
      _collectionCount = collectionGoal;
      SetCollectedCount();
   }

   public void InitPoolColor(Color poolColor)
   {
      if (poolColor != _defaultColor)
         GetComponent<MeshRenderer>().material.color = poolColor;
   }
   
   public void SetCollectedCount()
   {
      collectedCount.text = _collectedCount + "/" + _collectionCount;
   }
   
}
