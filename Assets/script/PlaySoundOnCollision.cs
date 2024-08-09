using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    float elapsedTime;
    float timeTilDeath = 3;

    private void FixedUpdate()
    {
        if (elapsedTime >= timeTilDeath)
        {
            Destroy(gameObject);
        }
        else
        {
            elapsedTime += Time.fixedDeltaTime;
        }
    }
    void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }
}