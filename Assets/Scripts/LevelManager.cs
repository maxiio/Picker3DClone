using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    [HideInInspector]
    public int levelNo=1;
    
    private List<Level> _levels;

    [HideInInspector] 
    public Level level;



    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {        
        MakeInstance();
        
        _levels = Levels.Instance.levels;

        levelNo = PlayerPrefs.GetInt(PlayerPrefKeyEnums.LEVEL_NO.ToString());
        levelNo = levelNo == 0 ? 1 : levelNo;

        CheckLevelNo();

    }

    private void Start()
    {
        LoadCurrentLevelData();
        Debug.LogWarning("START Level No : " +levelNo);
    }
    

    public void LoadCurrentLevelData()
    {
        CheckLevelNo();
        level = _levels[levelNo - 1];
        GUIManager.instance.SetLevelText(levelNo);
        LevelCreator.instance.CreateLevel(level);

    }    
    
    public Level GetNextLevelData(int nextLevelNo)
    {
        nextLevelNo = nextLevelNo >= _levels.Count ? 0 : nextLevelNo;
        return _levels[nextLevelNo];
    }


    private void CheckLevelNo()
    {
        if (levelNo <= 0 || levelNo >= _levels.Count+1 )
            levelNo = 1;
    }
    
    public void LoadNextLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnInitNextLevel()
    {
        LevelCreator.instance.LoadNextLevelsPlatforms(GetNextLevelData(levelNo));
    }
    public void OnLevelCompleted()
    {
        Debug.Log("LevelManager.cs OnLevelCompleted()");
        levelNo++;
        CheckLevelNo();

        SaveGameData();
    }

    public void OnLevelFailed()
    {
        Debug.Log("LevelManager.cs OnLevelFailed()");
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt(PlayerPrefKeyEnums.LEVEL_NO.ToString(), levelNo);
    }
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}