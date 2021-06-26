using UnityEngine;

public class Test : MonoBehaviour
{
    public SoundSO music;
    public SoundSO sfx;
    public ParticleSystem particle;

    public IntReference intReference;
    public GameObjectReference objectReference;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SoundManager.Instance.PlayMusic(music.GetAudioClip(), true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.Instance.PlayOneShot(sfx);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
}