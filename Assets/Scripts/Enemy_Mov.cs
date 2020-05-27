using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mov : MonoBehaviour
{
   public float speed;
   public bool isRight=true;
   private void movement()
   {
       if(isRight)
       {
       Vector3 position = transform.position;
       position.x += position.x * speed * Time.deltaTime;
        transform.position = position;
       }
       else if(isRight == false)
       {
        Vector3 position = transform.position;
        position.x -= position.x * speed * Time.deltaTime;
        transform.position = position;
       }
   }

   private void Update()
   {
      movement();
   }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground_Tile_Map")
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f * (scale.x);
            transform.localScale = scale;
            isRight =! isRight;
        }

        else if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
            playerController.KillPlayer();
        }
    }
    
    
}
