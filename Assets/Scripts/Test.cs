﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public EnemyWaveManager waveManager;
    public WeaponBase playerWeapon;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            waveManager.TrySpawnNext();
        }
    }
}
