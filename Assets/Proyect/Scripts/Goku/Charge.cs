using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public GameObject aura;
    public static bool isActive=false;

    private void Update()
    {
        if (isActive)
        {
            Player.instance.ki += Time.deltaTime * Player.instance.forceCharge; 
            if (Player.instance.ki>=Player.instance.maxKi)
            {
                Player.instance.ki = Player.instance.maxKi;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && IsCheckGround.IsGrounded)
        {
            PlayerMovement.charge = true;
            aura.SetActive(true);
            isActive = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isActive = false;
            PlayerMovement.charge = false;
            aura.SetActive(false);
        }
    }
}
