using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour
{
    // Serduszka
    public int hearts = 3;
    public int maxHearts = 3;

    // Tarcza
    private bool shieldActive = false;

    // SpeedBoost
    private bool speedBoostActive = false;
    public float normalSpeed = 5f;
    public float boostedSpeed = 10f;

    // Tarcza
    public void ActivateShield()
    {
        if (!shieldActive)
            StartCoroutine(ShieldTimer());
    }

    private IEnumerator ShieldTimer()
    {
        shieldActive = true;
        Debug.Log("Tarcza włączona!");
        // Tutaj możesz włączyć grafikę tarczy
        yield return new WaitForSeconds(5f); // tarcza trwa 5 sekund
        shieldActive = false;
        Debug.Log("Tarcza wyłączona!");
    }

    // Apteczka
    public void Heal(int amount)
    {
        hearts += amount;
        if (hearts > maxHearts) hearts = maxHearts;
        Debug.Log("Leczenie: " + amount + " serce/a. Aktualne serca: " + hearts);
    }

    // Obrażenia
    public void TakeDamage(int amount)
    {
        if (!shieldActive)
        {
            hearts -= amount;
            if (hearts < 0) hearts = 0;
            Debug.Log("Gracz stracił " + amount + " serce/a. Aktualne serca: " + hearts);
        }
    }

    // SpeedBoost
    public void ActivateSpeedBoost(float duration)
    {
        if (!speedBoostActive)
            StartCoroutine(SpeedBoostTimer(duration));
    }

    private IEnumerator SpeedBoostTimer(float duration)
    {
        speedBoostActive = true;
        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null)
            controller.moveSpeed = boostedSpeed;

        Debug.Log("SpeedBoost włączony!");
        yield return new WaitForSeconds(duration);

        if (controller != null)
            controller.moveSpeed = normalSpeed;
        speedBoostActive = false;
        Debug.Log("SpeedBoost wyłączony!");
    }

    public void ActivateNuke()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Debug.Log("Nuke aktywowany! Wszyscy przeciwnicy zniszczoni.");
    }
}
