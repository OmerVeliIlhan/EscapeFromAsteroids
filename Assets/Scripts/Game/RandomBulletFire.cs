using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletFire : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * -1, Screen.height * -1,Camera.main.transform.position.z * -1));
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if(transform.position.y < screenBounds.y + 9.5f)
        {
            Destroy(this.gameObject);
            ScoreCounter.scoreCounter.scoreValue += 10;
        }
    }
}
