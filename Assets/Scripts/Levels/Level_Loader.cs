using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
  private Button button;
  public string LevelName;
  private void Awake()
  {
      button = GetComponent<Button>();
      button.onClick.AddListener(onClick);
  }

  private void onClick()
  {
    Level_Status levelStatus = Level_Manager.Instance.GetLevelStatus(LevelName);
    switch(levelStatus)
    {
      case Level_Status.Locked:
      Debug.Log("Can't play this level till you unlock it");
      break;

      case Level_Status.Unlocked:
      SceneManager.LoadScene(LevelName);
      break;

      case Level_Status.Completed:
      SceneManager.LoadScene(LevelName);
      break;
    }
  }
}
