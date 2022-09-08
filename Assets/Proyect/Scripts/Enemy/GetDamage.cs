using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public Sprite spriteDefault;
    public Sprite[] spritesHurts;
    public float wait = 1;
    private float waitChangeColor;

    public static GetDamage instance;

    private void Awake()
    {
        instance = this;
        waitChangeColor = wait;
    }

    private void Update()
    {
        if (spriteRenderer.sprite!=spriteDefault)
        {
            waitChangeColor -= Time.deltaTime;
        }
        if (waitChangeColor<=0)
        {
            animator.enabled = true;
            spriteRenderer.sprite = spriteDefault;
            waitChangeColor = wait;
        }
    }
    public void Damage(float damage)
    {
        animator.enabled = false;
        Enemy.instance.life-=damage;
        System.Random spriteRandom = new System.Random();
        spriteRenderer.sprite = spritesHurts[spriteRandom.Next(1,4)];
        if (transform.localScale.x==1)
        {
            rigidbody2D.AddForce(new Vector2(Player.instance.force,1),ForceMode2D.Impulse);
        }
        else if (transform.localScale.x==-1)
        {
            rigidbody2D.AddForce(new Vector2(-Player.instance.force, 1), ForceMode2D.Impulse);
        }
    }
}
