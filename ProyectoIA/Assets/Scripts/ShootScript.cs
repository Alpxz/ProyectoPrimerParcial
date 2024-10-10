using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;          // El punto desde donde se dispara (puede ser la mano del personaje)
    public float projectileSpeed = 10f;  // Velocidad del proyectil
    public float nextFireTime = 0f;
    public float shootDelay = 0.5f;


    void FixedUpdate()
    {
        // Llamar a la funci�n de disparo si alguna flecha est� presionada
        Vector2 shootDirection = GetShootDirection();

        if (shootDirection != Vector2.zero && Time.time >= nextFireTime)
        {
            Shoot(shootDirection);
            nextFireTime = Time.time + shootDelay;
        }
    }

    // Detecta la direcci�n de disparo bas�ndose en las flechas de direcci�n
    Vector2 GetShootDirection()
    {
        int horizontal = 0;
        int vertical = 0;

        // Detectar si las teclas de flecha est�n presionadas
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }

        // Combinaci�n de la direcci�n para permitir disparar en diagonales
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        return direction;
    }

    // Instanciar el proyectil y asignarle una direcci�n
    void Shoot(Vector2 direction)
    {
        // Instanciar el proyectil en el punto de disparo (firePoint)
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Obtener el Rigidbody2D del proyectil para aplicarle la velocidad
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Establecer la velocidad del proyectil en la direcci�n adecuada
        rb.velocity = direction * projectileSpeed;
    }
}
