using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float rotationSpeed = 100f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleRotation();
        HandleShooting();
    }

    void HandleRotation()
    {
        float rotationInput = Input.GetAxis("Horizontal"); // A and D keys

        if (rotationInput != 0)
        {
            animator.SetBool("isWalking", true);
            transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);

            if (rotationInput > 0 && !isFlipped)
            {
                FlipTurret(true);
            }
            else if (rotationInput < 0 && isFlipped)
            {
                FlipTurret(false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    void FlipTurret(bool flip)
    {
        isFlipped = flip;
        spriteRenderer.flipX = flip;
    }
}
