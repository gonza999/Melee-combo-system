using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    private bool walk = false;
    private bool back = false;
    private bool jump = false;
    private bool fall = false;
    public static bool punch1 = false;
    public static bool punch2 = false;
    public static bool punch3 = false;
    public static bool charge = false;
    private void Update()
    {
        Walk();
        Back();
        if (IsCheckGround.IsGrounded)
        {
            fall = false;
            Jump();
        }
        else
        {
            Fall();
        }
        if (Input.GetKeyDown(KeyCode.D) && IsCheckGround.IsGrounded)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.A) && IsCheckGround.IsGrounded)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void Fall()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            fall = true;
        }
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.S) && !Charge.isActive )
        {
            walk = false;
            back = false;
            jump = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Player.instance.forceJump);
        }
        else
        {
            jump = false;
        }
        if (Input.GetKeyUp(KeyCode.S) && !Charge.isActive)
        {
            jump = false;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
    private void Back()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Charge.isActive)
        {
            if (transform.localScale.x > 0)
            {
                if (jump || fall)
                {
                    back = false;
                }
                else
                {
                    back = true;
                    walk = false;
                }
            }
            else
            {
                if (jump || fall)
                {
                    walk = false;
                }
                else
                {
                    walk = true;
                }
            }
            

            rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Player.instance.speed, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !Charge.isActive)
        {
            if (transform.localScale.x > 0)
            {
                back = false;

            }
            else
            {
                walk = false;
            }
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !Charge.isActive)
        {
            if (transform.localScale.x > 0)
            {
                if (jump || fall)
                {
                    walk = false;
                }
                else
                {
                    walk = true;
                }
            }
            else
            {
                if (jump || fall)
                {
                    back = false;
                }
                else
                {
                    back = true;
                    walk = false;
                }
            }
            rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Player.instance.speed, rigidbody2D.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !Charge.isActive)
        {
            if (transform.localScale.x > 0)
            {
                walk = false;

            }
            else
            {
                back = false;
            }
            rigidbody2D.velocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        animator.SetBool("Walk", walk);
        animator.SetBool("Back", back);
        animator.SetBool("Fall", fall);
        animator.SetBool("Jump", jump);
        animator.SetBool("Punch1", punch1);
        animator.SetBool("Punch2", punch2);
        animator.SetBool("Punch3", punch3);
        animator.SetBool("Charge",charge);
    }
}
