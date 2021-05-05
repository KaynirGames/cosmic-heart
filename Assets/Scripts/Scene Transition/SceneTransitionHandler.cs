using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SceneTransitionHandler : MonoBehaviour
{
    private const string MAIN_TEX = "_MainText";
    private const string CUTOFF = "_Cutoff";
    private const string EDGE_SMOOTHING = "_EdgeSmoothing";

    private const float CUTOFF_MAX_VALUE = 1.1f;
    private const float CUTOFF_MIN_VALUE = -0.1f;

    [SerializeField] private float _transitionSpeed = 1f;

    private Image _image;

    private bool _isLoading;
    private bool _isDone;
    private int _loadingSceneID;
    private float _edgeSmoothing;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _edgeSmoothing = _image.material.GetFloat(EDGE_SMOOTHING);
        _isLoading = false;
        _isDone = false;
    }

    private void Update()
    {
        if (_isDone)
        {
            return;
        }

        if (_isLoading)
        {
            if (FadeMaterial(CUTOFF_MIN_VALUE - _edgeSmoothing))
            {
                SceneManager.LoadScene(_loadingSceneID);
            }
            return;
        }

        if (FadeMaterial(CUTOFF_MAX_VALUE))
        {
            _isDone = true;
        }
    }

    public void LoadScene(int sceneID)
    {
        _isLoading = true;
        _isDone = false;
        _loadingSceneID = sceneID;
    }

    private bool FadeMaterial(float targetValue)
    {
        float currentCutoff = _image.material.GetFloat(CUTOFF);
        float newCutoff = Mathf.MoveTowards(currentCutoff, targetValue, _transitionSpeed * Time.deltaTime);

        _image.material.SetFloat(CUTOFF, newCutoff);

        return newCutoff == targetValue;
    }
}
