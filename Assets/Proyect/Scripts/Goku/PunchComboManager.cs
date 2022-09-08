using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchComboManager : MonoBehaviour
{
    public GameObject hitParticles;
    public bool canReciveInput;
    public bool inputReceived;
    public Animator animator;
    public bool firstPunch = true;

    public GameObject attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayerMask;

    public static PunchComboManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.D) && IsCheckGround.IsGrounded && !Charge.isActive)
        {
            inputReceived = true;
            canReciveInput = false;
            if (firstPunch)
            {
                animator.SetTrigger("Punch1");
                InputManagers();
                inputReceived = false;
                firstPunch = false;
            }
        }
    }
    public void HitEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position,attackRange,enemyLayerMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            Destroy(Instantiate(hitParticles, attackPoint.transform.position, attackPoint.transform.rotation),0.5f);
            GetDamage.instance.Damage(Player.instance.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position,attackRange);
    }
    public void InputManagers()
    {
        if (!canReciveInput)
        {
            canReciveInput = true;
        }
        else
        {
            canReciveInput = false;
        }
    }
}
