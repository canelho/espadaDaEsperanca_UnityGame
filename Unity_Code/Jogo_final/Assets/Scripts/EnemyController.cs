using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetSpeedBasedOnScene();
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("O inimigo tocou na parede!");
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(0.05f);

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

    private void SetSpeedBasedOnScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Nivel0")
        {
            speed = 3f;
        }
        else if (currentSceneName == "Nivel1")
        {
            speed = 4f;
        }
        else
        {
            speed = 5f; // Velocidade padrão se a cena não for Nivel0 nem Nivel1
        }
    }
}
