using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed = 3.0f;

    private Vector2 movement;
    private Rigidbody2D rb2D;
    private Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Ambil Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Tentukan Angka State berdasarkan arah
        int currentState = 5; // Default 5 = Idle

        // Pakai if-else agar kalau jalan diagonal, ada satu animasi yang diprioritaskan (Horizontal dulu)
        if (movement.x < 0) 
        {
            currentState = 1; // Kiri
        }
        else if (movement.x > 0) 
        {
            currentState = 2; // Kanan
        }
        else if (movement.y > 0) 
        {
            currentState = 3; // Atas
        }
        else if (movement.y < 0) 
        {
            currentState = 4; // Bawah
        }

        // 3. Kirim angka state tersebut ke Animator
        animator.SetInteger("State", currentState);
    }

    private void FixedUpdate()
    {
        // 4. Gerakkan Karakter
        rb2D.linearVelocity = movement.normalized * movementSpeed;
    }
}