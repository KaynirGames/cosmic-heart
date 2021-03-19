using UnityEngine;

public class SoundEffect : BaseEffect
{
    [SerializeField] private AudioClip[] _clipVariations = null;

    public override void Activate(GameObject target)
    {
        if (target.TryGetComponent(out AudioSource source))
        {
            source.PlayOneShot(GetRandomClip());
        }
    }

    private AudioClip GetRandomClip()
    {
        return _clipVariations?[Random.Range(0,
                                             _clipVariations.Length)];
    }
}