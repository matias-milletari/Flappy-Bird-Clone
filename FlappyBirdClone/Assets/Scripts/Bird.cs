using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead;
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    public delegate void BirdCollision();
    public static event BirdCollision OnBirdCollided;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            rigidBody2D.velocity = Vector2.zero;

            rigidBody2D.AddForce(new Vector2(0, upForce));

            animator.SetTrigger("Flap");
        }
    }

    private void OnCollisionEnter2D()
    {
        rigidBody2D.velocity = Vector2.zero;

        isDead = true;

        animator.SetTrigger("Die");

        if (OnBirdCollided != null) OnBirdCollided();
    }
}