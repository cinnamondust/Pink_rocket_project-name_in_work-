using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Shield, Medkit, SpeedBoost, Nuke };
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
                switch(type)
                {
                    case PowerUpType.Shield:
                        player.ActivateShield();
                        break;

                    case PowerUpType.Medkit:
                        player.Heal(1); // przywraca 1 serce
                        break;

                    case PowerUpType.SpeedBoost:
                        player.ActivateSpeedBoost(5f); // boost na 5 sekund
                        break;

                    case PowerUpType.Nuke:
                        player.ActivateNuke(); // niszczy przeciwników
                        break;
                }
            }

            Destroy(gameObject); // power-up znika po zebraniu
        }

        if (collision.CompareTag("Sciana"))
        {
            Destroy(gameObject); // power-up znika przy kolizji ze ścianą
        }
    }
}

