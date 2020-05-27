using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_tiles_Controller : MonoBehaviour
{

    public Enter_Again enter_Again;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            
            Debug.Log("Player killed by the enemy");
            gameObject.SetActive(false);
            enter_Again.PlayerDied();
        }
    }
}
