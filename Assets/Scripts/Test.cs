using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public EnemyWaveManager waveManager;
    public WeaponBase playerWeapon;
    public AudioClip musicClip;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            waveManager.TrySpawnNext();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SoundManager.Instance.PlayMusic(musicClip, true);
        }
    }
}
