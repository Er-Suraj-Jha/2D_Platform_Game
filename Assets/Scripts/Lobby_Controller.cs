using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby_Controller : MonoBehaviour
{
    public Button button;
    public GameObject Level_Selection_Popup;
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

private void OnButtonClick()
  {
      Debug.Log("Player entered the game");
      //SceneManager.LoadScene("Master_Scene");
      Level_Selection_Popup.SetActive(true);
  }
    
}
