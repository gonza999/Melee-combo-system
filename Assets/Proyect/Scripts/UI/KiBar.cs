using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float ki;
    public bool isPlayer = false;
    private void Update()
    {
        if (isPlayer)
        {
            ki = 12 * (Player.instance.ki / Player.instance.maxKi);
        }
        else
        {
            ki = 12 * (Enemy.instance.ki / Enemy.instance.maxKi);
        }
        if (ki <= 0)
        {
            ki = 0;
        }
        if (ki>=12.3f)
        {
            ki = 12.3f;
        }
        spriteRenderer.size = new Vector2(ki, spriteRenderer.size.y);

    }
}
