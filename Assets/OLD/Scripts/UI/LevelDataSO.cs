﻿using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Level Data")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private string _levelName = null;
    [SerializeField] private int _sceneID = 0;
    [SerializeField] private GameObject _planetPrefab = null;
    [SerializeField] private Material _backgroundMaterial = null;
    [SerializeField] private IntVariableSO _highScore = null;

    public string LevelName => _levelName;
    public int SceneID => _sceneID;
    public GameObject PlanetPrefab => _planetPrefab;
    public Material BackgroundMaterial => _backgroundMaterial;
    public IntVariableSO HighScore => _highScore;
}
