using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mov1 : MonoBehaviour
{
   public float speed;
   private bool isRight=true;
   private Rigidbody2D rigid;
   private void movement()
   {
       if(isRight)
       {
          rigid.AddForce(new Vector2(speed, 0f), ForceMode2D.Force);
       }
       else if(isRight == false)
       {
           rigid.AddForce(new Vector2(-1f*speed, 0f), ForceMode2D.Force);
       }
   }

   private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
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
