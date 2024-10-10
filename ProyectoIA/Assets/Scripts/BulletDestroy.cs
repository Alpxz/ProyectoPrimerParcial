using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo antes de destruir el proyectil autom�ticamente
    void Start()
    {
        // Destruir el proyectil autom�ticamente despu�s de 5 segundos
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