using System.Collections;
using UnityEngine;

public class AudioSourceFader : MonoBehaviour
{
    public IEnumerator FadeInCO(AudioSource audioSource, AudioClip audioClip, float desiredVolume, bool loop)
    {
        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.Play();

        while (audioSource.volume < desiredVolume)
        {
            audioSource.volume += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = desiredVolume;
    }

    public IEnumerator FadeOutCO(AudioSource audioSource)
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime;
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.loop = false;
        audioSource.Stop();
    }
}
