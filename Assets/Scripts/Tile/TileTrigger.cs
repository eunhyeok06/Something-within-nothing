using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileTrigger : MonoBehaviour
{
    public AudioSource sfxSource;       
    public AudioClip[] audioClips;
    public float[] delays;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(PlaySequence());
        }
    }


    private IEnumerator PlaySequence()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            AudioClip clip = audioClips[i];
            float delay = delays[i];
            sfxSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length + delay);
        }
    }
}
