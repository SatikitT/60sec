using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Transform target;
    private bool hasCollided = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            // Flip the sprite based on the direction
            if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            collision.gameObject.GetComponent<Clock>().ReduceTime(5f);
            Destroy(gameObject);
        }
    }
}
