using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelectionDisplay : MonoBehaviour
{
    [SerializeField] private List<LevelDataSO> _levels = null;
    [SerializeField] private Vector2 _planetDisplayPosition = Vector2.zero;
    [SerializeField] private ParallaxHandler _parallaxHandler = null;
    [SerializeField] private TextMeshProUGUI _levelNameField = null;
    [SerializeField] private GameObject _prevLevelButton = null;
    [SerializeField] private GameObject _nextLevelButton = null;

    private LevelDataSO _currentLevel;
    private int _currentLevelIndex;
    private List<GameObject> _planets;

    private void Awake()
    {
        CreatePlanets();
    }

    private void Start()
    {
        SetLevel(_currentLevelIndex);
    }

    public void SetNextLevel()
    {
        SetLevel(_currentLevelIndex + 1);
    }

    public void SetPreviousLevel()
    {
        SetLevel(_currentLevelIndex - 1);
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(_currentLevel.SceneID);
    }

    public void Close()
    {
        TogglePlanet(_currentLevelIndex, false);
        gameObject.SetActive(false);
    }

    private void SetLevel(int index)
    {
        TogglePlanet(_currentLevelIndex, false);
        _currentLevelIndex = index;
        _currentLevel = _levels[index];

        _levelNameField.SetText(_currentLevel.LevelName);
        TogglePlanet(index, true);
        _parallaxHandler.SetMaterial(_currentLevel.BackgroundMaterial);

        CheckSelectionButtons(index);
    }

    private void CreatePlanets()
    {
        _planets = new List<GameObject>();

        foreach (LevelDataSO levelData in _levels)
        {
            GameObject planet = Instantiate(levelData.PlanetPrefab,
                                            _planetDisplayPosition,
                                            Quaternion.identity);
            planet.SetActive(false);
            _planets.Add(planet);
        }
    }

    private void TogglePlanet(int index, bool enable)
    {
        _planets[index].SetActive(enable);
    }

    private void CheckSelectionButtons(int index)
    {
        _prevLevelButton.SetActive(index > 0);
        _nextLevelButton.SetActive(index < _levels.Count - 1);
    }
}