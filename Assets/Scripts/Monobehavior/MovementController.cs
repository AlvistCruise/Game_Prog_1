using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movementSpeed = 3.0f;

    Vector2 movement;
    Rigidbody2D rb2D;
    Animator animator;
    string animatorParameter = "AnimationState";

    enum CharacterState
    {
        walk_to_East = 1,
        walk_to_West = 3,
        walk_to_South = 2,
        walk_to_North = 4,
        idle_south = 5
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.y > 0)
        {
            animator.SetInteger(animatorParameter, (int)CharacterState.walk_to_North);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animatorParameter, (int)CharacterState.walk_to_South);
        }
        else if (movement.x > 0)
        {
            animator.SetInteger(animatorParameter, (int)CharacterState.walk_to_East);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animatorParameter, (int)CharacterState.walk_to_West);

        }
        else
        {
            animator.SetInteger(animatorParameter, (int)CharacterState.idle_south);
        }
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        movement.Normalize();
        rb2D.linearVelocity = movement * movementSpeed;
    }

    


}
