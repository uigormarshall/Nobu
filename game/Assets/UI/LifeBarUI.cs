using UnityEngine;
using UnityEngine.UI;

public class LifeBarUI : MonoBehaviour
{
    public Image lifeBarImage;
    public float maxHealth = 100f; // Valor máximo da vida do personagem
    public float currentHealth = 100f; // Valor atual da vida do personagem

    void Update()
    {
        // Atualiza a escala da barra de vida com base no valor atual da vida
        float normalizedHealth = currentHealth / maxHealth;
        lifeBarImage.transform.localScale = new Vector3(normalizedHealth, 1f, 1f);
    }
}
