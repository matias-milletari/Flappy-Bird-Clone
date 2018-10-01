using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        rigidBody2D.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (GameController.instance.gameOver)
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }
}
