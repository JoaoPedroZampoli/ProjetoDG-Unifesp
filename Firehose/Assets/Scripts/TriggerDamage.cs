using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && (collision.gameObject.tag == "Musgo" || collision.gameObject.tag == "Mosquinha"))
        {
            heart.vida--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.tag=="Musgo")
        {
            heart.vida--;
        }
    }
}
