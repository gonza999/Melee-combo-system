using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float life;
    public bool isPlayer = false;
    private void Update()
    {
        if (isPlayer)
        {
            life = 12 * (Player.instance.life / Player.instance.maxLife);
        }
        else
        {
            life = 12 * (Enemy.instance.life / Enemy.instance.maxLife);
        }
        if (life <= 0)
        {
            life = 0;
        }
        if (life >= 12.3f)
        {
            life = 12.3f;
        }
        spriteRenderer.size = new Vector2(life, spriteRenderer.size.y);

    }
}
