using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    private void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackGround();   
        }
    }

    private void RepositionBackGround()
    {
        Vector2 offset = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2) transform.position + offset;
    }
}
