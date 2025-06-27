using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioSource morteSoundEffect;
    [SerializeField] private int health = 1;
    [SerializeField] private Animator animator; // Referência para o componente Animator

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
        animator.SetTrigger("Die"); // Ativa a trigger de morte na animação
        morteSoundEffect.Play();
        StartCoroutine(DestroyAfterAnimation()); // Inicia a rotina para destruir o GameObject após a animação
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Aguarda o tempo de duração da animação
        Destroy(gameObject);
    }
}
