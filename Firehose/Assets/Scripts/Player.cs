using UnityEngine;

public class Player : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private Vector3 moveDelta;
    public float moveSpeed = 5f;

    private void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);
        
        // Swap sprite direction, if moving left or right
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Move player
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
