using System.Collections.Generic;
using UnityEngine;

public class LevelTabSelectorUI : BaseTabSelectorUI
{
    [Header("Level Selector Settings:")]
    [SerializeField] private List<LevelDataSO> _levels = null;
    [SerializeField] private Vector2 _planetDisplayPosition = Vector2.zero;
    [SerializeField] private SceneTransitionHandler _transitionHandler = null;
    [SerializeField] private ParallaxHandler _parallaxHandler = null;

    private List<GameObject> _planets;

    private void Awake()
    {
        CreatePlanets();
    }

    public void PlayLevel()
    {
        _transitionHandler.LoadScene(_levels[_tabIndex].SceneID);
    }

    public void ClearDisplay()
    {
        HideContent(_tabIndex);
    }

    protected override void ShowContent(int index)
    {
        base.ShowContent(index);
        TogglePlanet(index, true);
        _parallaxHandler.SetMaterial(_levels[index].BackgroundMaterial);
    }

    protected override void HideContent(int index)
    {
        base.HideContent(index);
        TogglePlanet(index, false);
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
}