using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> meowClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(meowClips[Random.Range(0, meowClips.Count)]);
        }
    }
}

