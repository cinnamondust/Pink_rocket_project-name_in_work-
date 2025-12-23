using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Shield, Medkit };
    public PowerUpType type;

    public float fallSpeed = 0.25f;

    void Update()
    {
        // Power-up spada w dół
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Logika dla gracza
            PlayerPowerUps player = collision.GetComponent<PlayerPowerUps>();
            if (player != null)
            {
                if (type == PowerUpType.Shield)
                    player.ActivateShield();
                if (type == PowerUpType.Medkit)
                    player.Heal(20);
            }

            Destroy(gameObject);
        }

        if (collision.CompareTag("Sciana"))
        {
            Destroy(gameObject);
        }
    }
}
