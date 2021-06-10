using System.Collections;
using UnityEngine;

public class LevelVictoryHandler : MonoBehaviour
{
    private const float STAR_PERCENT = 0.3f;

    [SerializeField] private WindowPopup _victoryPopup = null;
    [SerializeField] private IntVariableSO _currentScore = null;
    [SerializeField] private IntVariableSO _highScore = null;
    [SerializeField] private IntVariableSO _maxScore = null;
    [SerializeField] private IntVariableSO _stars = null;
    [SerializeField] private IntVariableSO _maxStars = null;
    [SerializeField] private float _victoryPopupDelay = 2f;

    private WaitForSecondsRealtime _waitForDelay;

    private void Awake()
    {
        _waitForDelay = new WaitForSecondsRealtime(_victoryPopupDelay);
    }

    public void ShowVictoryWindow()
    {
        StartCoroutine(VictoryPopupCO());
    }

    private void CalculateStars(int score)
    {
        float requiredScore = _maxScore.Value * STAR_PERCENT;
        int stars = _stars.Value;

        for (int i = stars; i < _maxStars.Value; i++)
        {
            if (score >= requiredScore * (i + 1))
            {
                _stars.SetValue(i + 1);
            }
        }
    }

    private IEnumerator VictoryPopupCO()
    {
        yield return _waitForDelay;

        if (_highScore.Value < _currentScore.Value)
        {
            _highScore.SetValue(_currentScore.Value);
        }

        if (_stars.Value < _maxStars.Value)
        {
            CalculateStars(_highScore.Value);
        }

        _victoryPopup.Open();
    }
}