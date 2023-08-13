using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform healthBar; // Referência ao Transform da barra de vida
    public float maxHealth = 100f; // Vida máxima do jogador
    private float currentHealth; // Vida atual do jogador

    private Vector3 initialScale; // Escala inicial da barra de vida

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida máxima
        initialScale = healthBar.localScale; // Armazena a escala inicial da barra de vida
        UpdateHealthBar(); // Atualiza a barra de vida no início do jogo
    }
    //TODO: Remover o dano estivo e implementar o dano de projeteis, armadilhas e ataque
    private void FixedUpdate(){
        TakeDamage(0.02f);
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Reduz a vida atual pelo valor do dano
        currentHealth = Mathf.Max(currentHealth, 0f); // Garante que a vida atual não seja negativa
        UpdateHealthBar(); // Atualiza a barra de vida após receber dano

        if (currentHealth <= 0f)
        {
            // Implemente o código para tratar a derrota do jogador aqui (game over, respawn, etc.)
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        Vector3 newScale = new Vector3(initialScale.x * healthPercentage, initialScale.y, initialScale.z);
        healthBar.localScale = newScale; 
    }
}
