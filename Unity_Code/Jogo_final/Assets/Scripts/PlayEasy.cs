using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayEasy : MonoBehaviour
{
    [SerializeField] private AudioSource clickSoundEffect;

    public void playez()
    {
        StartCoroutine(PlayAudioAndLoadScene());
    }

    private IEnumerator PlayAudioAndLoadScene()
    {
        clickSoundEffect.Play();

        // Aguarda até que a duração do áudio tenha passado
        yield return new WaitForSeconds(clickSoundEffect.clip.length);

        // Carrega a cena após o áudio ter sido reproduzido completamente
        SceneManager.LoadScene("Nivel0");
    }
}
