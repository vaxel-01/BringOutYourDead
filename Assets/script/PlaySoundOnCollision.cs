using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip collisionSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }
}