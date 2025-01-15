using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRItemInteractor : MonoBehaviour
{
    public GameObject[] LockObjects; // The objects to destroy when unlocked
    public GameObject KeyItem; // The item needed to unlock
    [SerializeField] private AudioClip UnlockSound; // The sound to play when unlocked
    [SerializeField] private AudioSource audioSource; // The AudioSource component

    private void Awake()
    {
        // Get or add an AudioSource component
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the key item
        if (other.gameObject == KeyItem)
        {
            // Destroy all lock objects in the array
            foreach (GameObject lockObject in LockObjects)
            {
                if (lockObject != null)
                {
                    Destroy(lockObject);
                }
            }

            // Destroy the key item
            if (KeyItem != null)
            {
                Destroy(KeyItem);
            }

            // Play the unlock sound
            if (UnlockSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(UnlockSound);
            }
        }
    }
}
