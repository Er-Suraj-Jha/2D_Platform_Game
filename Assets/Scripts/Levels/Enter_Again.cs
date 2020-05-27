using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enter_Again : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

private void OnButtonClick()
  {
      Debug.Log("Button Clicked");
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.buildIndex);
  }
    
}
