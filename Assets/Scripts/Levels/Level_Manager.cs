using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Level_Manager : MonoBehaviour
{   
    private static Level_Manager instance;
    public static Level_Manager Instance{get{return instance;}}
    //public string Level1;
    public string[] Levels;
    public string Lobby;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            }

    }
    public Level_Status GetLevelStatus(string level)
    {
        Level_Status levelStatus = (Level_Status)PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }

    public void SetLevelStatus(string level,Level_Status levelStatus)
    {
        PlayerPrefs.SetInt(level,(int)levelStatus);
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        int currentSceneIndex = Array.FindIndex(Levels,level => level == currentScene.name);
        int nextSceneIndex =currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex],Level_Status.Unlocked);
        }
    }


   private void update()
   {
       if(GetLevelStatus(Lobby) == Level_Status.Locked)
       {
            SetLevelStatus(Lobby,Level_Status.Unlocked);
       }
   }

   private void Start()
    {
       /*
        if(GetLevelStatus(Levels[0]) == Level_Status.Locked)
        {
            SetLevelStatus(Levels[0],Level_Status.Unlocked);
        }
        */
         SetLevelStatus(Levels[0],Level_Status.Unlocked);
        SetLevelStatus(Levels[1],Level_Status.Locked);
       SetLevelStatus(Levels[2],Level_Status.Locked);
       SetLevelStatus(Levels[3],Level_Status.Locked);


    }
    
}
