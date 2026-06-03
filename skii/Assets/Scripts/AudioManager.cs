using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip CollisionSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += playCollisionSound;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= playCollisionSound;
    }

    private void playCollisionSound()
    {
        if (audioSource == null) return;
        audioSource.PlayOneShot(CollisionSound);
    }
}