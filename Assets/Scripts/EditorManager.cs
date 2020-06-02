using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class EditorManager : MonoBehaviour
{
    [MenuItem("Ceren/Reset Levels")]
    static void ResetLevels()
    {
        PlayerPrefs.SetInt(PlayerPrefKeyEnums.LEVEL_NO.ToString(), 0);

    }
}
#endif