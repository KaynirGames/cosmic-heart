using UnityEngine;

public class SoundEffect : MonoBehaviour, ISpecialEffect
{
    [SerializeField] private AudioClip[] _clipVariations = null;
    [SerializeField] private AudioSource _audioSource = null;

    public void Play(GameObject target)
    {
        _audioSource.PlayOneShot(GetRandomClip());
    }

    private AudioClip GetRandomClip()
    {
        return _clipVariations?[Random.Range(0, _clipVariations.Length)];
    }
}