using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth; // Referência para o script Health do jogador
    private TMP_Text healthText; // Referência para o componente TMP_Text

    private void Start()
    {
        healthText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // Atualiza o texto do contador de vidas com a saúde atual do jogador
        healthText.text = "x" + playerHealth.GetHealth.ToString();
    }
}
