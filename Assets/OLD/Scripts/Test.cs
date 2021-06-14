using UnityEngine;

public class Test : MonoBehaviour
{
    public EnemyWaveManager waveManager;
    public WeaponBase weapon;
    public SoundSO music;
    public SoundSO sfx;
    public ParticleSystem particle;

    public IntVariableSO intVariable;

    void Start()
    {
        Debug.Log("Test");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            weapon.UseWeapon();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            waveManager.TrySpawnNext();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SoundManager.Instance.PlayMusic(music.GetAudioClip(), true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.Instance.PlaySound(sfx);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intVariable.ApplyChange(100);
        }
    }
}
