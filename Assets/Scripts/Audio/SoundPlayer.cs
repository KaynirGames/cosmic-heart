using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private SoundSO _sound = null;

    private SoundManager _manager;

    private void Start()
    {
        _manager = SoundManager.Instance;
    }

    public void Play()
    {
        _manager.PlayOneShot(_sound);
    }
}