using UnityEngine;

public class Column : MonoBehaviour
{
    public delegate void ColumnPassed();
    public static event ColumnPassed OnColumnPassed;

    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.GetComponent<Bird>() == null) return;

        if (OnColumnPassed != null) OnColumnPassed();
    }
}
