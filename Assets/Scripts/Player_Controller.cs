using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    public bool isGrounded = false;
    private Rigidbody2D rigid;
    public Score_Controller scoreController;
    public Health_Controller healthController;

     //Pickup_Key
    public void PickUpKey()
    {  
        Debug.Log("Player picked up the key");

        scoreController.Increase_Score(10);
    }
    

    //Enemy_Collision
    public void KillPlayer()
    {   
        Debug.Log("Player killed by the enemy");
        animator.SetBool("Death",true);
        healthController.Enemy_Collision();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground_Tile_Map")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
            Debug.Log("Inside collision isgrounded :" + isGrounded);
        }
        else if (collision.gameObject.name == "Death_Tiles")
        {
            KillPlayer();
        }
    }

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        PlayerMovementAnimator(horizontal);
        MoveCharacter(horizontal);
        player_jump();



        // ATTACK FUNCTION(Attack = Left_Control)

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attack", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Attack", false);
        }

        //CROUCH(Crouch = LeftShift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }

        //PUSH(Push = P)
        if (Input.GetKey(KeyCode.P))
        {
            animator.SetBool("Push", true);
        }
        else
        {
            animator.SetBool("Push", false);
        }

        //HURT(Hurt = H)
        if (Input.GetKey(KeyCode.H))
        {
            animator.SetBool("Hurt", true);
        }
        else
        {
            animator.SetBool("Hurt", false);
        }

        //DEATH(Death = D)
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Death", true);
        }
        else
        {
            animator.SetBool("Death", false);
        }

    }

    //JUMP
    private void player_jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            animator.SetBool("Jump", true);
            Debug.Log("isGrounded made false");
            rigid.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    //Movement

    private void PlayerMovementAnimator(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
}