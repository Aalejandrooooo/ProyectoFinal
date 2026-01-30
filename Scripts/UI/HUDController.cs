using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController: MonoBehaviour
{
    [Header("Vida")]
    public Image lifeFill;
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Munición")]
    public TMP_Text ammoText;
    public int currentAmmo = 30;
    public int reserveAmmo = 90;

    [Header("Daño")]
    public Image damageOverlay;
    public float damageFadeSpeed = 2f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateLife();
        UpdateAmmo();
    }

    void Update()
    {
        // Fade del daño
        if (damageOverlay.color.a > 0)
        {
            Color c = damageOverlay.color;
            c.a -= Time.deltaTime * damageFadeSpeed;
            damageOverlay.color = c;
        }
    }

    // VIDA
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateLife();
        ShowDamage();
    }

    void UpdateLife()
    {
        lifeFill.fillAmount = currentHealth / maxHealth;
    }

    void ShowDamage()
    {
        Color c = damageOverlay.color;
        c.a = 0.6f;
        damageOverlay.color = c;
    }

    // MUNICIÓN
    public void UpdateAmmo()
    {
        ammoText.text = currentAmmo + " | " + reserveAmmo;
    }

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmo();
        }
    }

    public void Reload()
    {
        int needed = 30 - currentAmmo;
        int toReload = Mathf.Min(needed, reserveAmmo);

        currentAmmo += toReload;
        reserveAmmo -= toReload;

        UpdateAmmo();
    }
}

    

