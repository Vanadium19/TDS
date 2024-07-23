using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private readonly float _percentFactor = 100f;

    [Range(0, 1)]
    [Tooltip("0 - Menu, 1 - Game")]
    [SerializeField] private int _sceneNumber;

    [SerializeField] private GameObject _loadPanel;
    [SerializeField] private TMP_Text _percent;

    public void Load()
    {
        _loadPanel.SetActive(true);
        StartCoroutine(StartLoad());
    }

    private IEnumerator StartLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneNumber);

        while (asyncLoad.isDone == false)
        {
            float percent = Mathf.Round(asyncLoad.progress * _percentFactor);
            _percent.text = $"Loading... {percent}%";
            yield return null;
        }
    }
}