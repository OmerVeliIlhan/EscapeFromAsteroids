using System.Collections;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public static DamageHandler instance;
    public SpriteRenderer spriteRenderer;
    public Color originColor;
    public Color damageColor;
    public float unvulnerable = 0;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;
        damageColor = Color.red;
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(unvulnerable <= 0 && collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(DamageEffect());
            unvulnerable = 1;
        }
        else
        {
            if(HealthHandler.instance.health < 3)
            {
                HealthHandler.instance.health += 1;
                Destroy(collision.gameObject);
            }
        }
    }


    IEnumerator DamageEffect()
    {
        spriteRenderer.color = damageColor;
        HealthHandler.instance.health -= 1;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originColor;
    }
}   
