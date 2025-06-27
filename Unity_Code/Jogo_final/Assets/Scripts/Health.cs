using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa o namespace necessário para lidar com cenas

public class Health : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private int health = 3;
    [SerializeField] private Animator animator; // Referência para o componente Animator

    public int GetHealth
    {
        get { return health; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        animator.SetTrigger("Die"); // Ativa a trigger de morte na animação
        deathSoundEffect.Play();

         // Carrega a cena GameOver após um pequeno atraso
        StartCoroutine(LoadGameOverScene());
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2f); // Aguarda por 2 segundos antes de mudar de cena
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (currentSceneName == "Nivel0")
        {
            SceneManager.LoadScene("Game0");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
