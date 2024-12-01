using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator; // Animator bileşenini bağlayın
    public float speed = 5f;
    public float jumpForce = 10f; // Zıplama kuvveti

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private SpriteRenderer spriteRenderer; // Sprite yönünü kontrol etmek için

    private bool isJumping = false; // Zıplama durumunu kontrol etmek için

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Hareket girişlerini al
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0; // Yatay hareket için sadece x ekseni kullanılıyor

        // Hareket ediyor mu kontrolü
        bool isMoving = Mathf.Abs(movement.x) > 0.1f;

        // Zıplama kontrolü
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Zıplama kuvveti uygula
            animator.SetBool("IsJump", true); // Zıplama animasyonu başlat
            animator.SetBool("IsWalk", false); // Walk animasyonunu durdur
        }

        // Zıplama yoksa yürüyüş veya idle kontrolü
        if (!isJumping)
        {
            animator.SetBool("IsWalk", isMoving);
        }

        // Sprite yönlendirme (flipX)
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Sola dön
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Sağa dön
        }
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettir
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zıplama durumunu sıfırla (karakter yere indiğinde)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJump", false);
        }
    }
}
