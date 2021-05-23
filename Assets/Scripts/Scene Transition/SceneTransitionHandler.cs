using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionHandler : MonoBehaviour
{
    private const string MAIN_TEX = "_MainText";
    private const string CUTOFF = "_Cutoff";
    private const string EDGE_SMOOTHING = "_EdgeSmoothing";

    private const float CUTOFF_MAX_VALUE = 1.1f;
    private const float CUTOFF_MIN_VALUE = -0.1f;

    [SerializeField] private Image _transitionScreen = null;
    [SerializeField] private Sprite _transitionSprite = null;
    [SerializeField] private float _transitionSpeed = 1f;

    private float _edgeSmoothing;

    private void Start()
    {
        SetTransitionTexture(_transitionSprite);
        _edgeSmoothing = _transitionScreen.material.GetFloat(EDGE_SMOOTHING);
        _transitionScreen.material.SetFloat(CUTOFF, CUTOFF_MIN_VALUE);

        StartCoroutine(FadeMaterialCO(CUTOFF_MAX_VALUE));
    }

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneCO(sceneID));
    }

    public void SetTransitionTexture(Sprite textureSprite)
    {
        _transitionScreen.material.SetTexture(MAIN_TEX, textureSprite.texture);
    }

    private IEnumerator FadeMaterialCO(float targetValue)
    {
        _transitionScreen.raycastTarget = true;

        float cutoff = _transitionScreen.material.GetFloat(CUTOFF);
        float delta = _transitionSpeed * Time.deltaTime;

        while (cutoff != targetValue)
        {
            cutoff = Mathf.MoveTowards(cutoff, targetValue, delta);
            _transitionScreen.material.SetFloat(CUTOFF, cutoff);
            yield return null;
        }

        _transitionScreen.raycastTarget = false;
    }

    private IEnumerator LoadSceneCO(int sceneID)
    {
        yield return FadeMaterialCO(CUTOFF_MIN_VALUE - _edgeSmoothing);
        SceneManager.LoadScene(sceneID);
    }
}
