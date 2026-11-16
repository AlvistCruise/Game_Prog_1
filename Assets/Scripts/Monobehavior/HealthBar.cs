using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    // 2
    public HealthPoints healthPoints;
  
    [HideInInspector]
    public Player character;

    // 4
    public Image meterImage;

    // 5
    public TextMeshProUGUI hpText;

    // 6
    float maxHealthPoints;

    void Start()
    {
if (character == null)
        {
            character = FindFirstObjectByType<Player>(); // Gunakan FindObjectOfType<Player>() jika menggunakan Unity versi lama
        }

        // 2. Simpan nilai maxHealthPoints secara aman
        if (character != null)
        {
            maxHealthPoints = character.maxHealthPoint;
        }
        else
        {
            Debug.LogWarning("HealthBar: Ref character (Player) tidak ditemukan di Start!", this);
        }
    }

    void Update()
    {
        // 8
        if (character != null)
        {
            // 9
            meterImage.fillAmount = healthPoints.value / maxHealthPoints;

            // 10
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}

