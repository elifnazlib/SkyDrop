using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Parrot") || collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }
}
