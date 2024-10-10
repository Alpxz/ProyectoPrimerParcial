using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo antes de destruir el proyectil automáticamente
    void Start()
    {
        // Destruir el proyectil automáticamente después de 5 segundos
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}