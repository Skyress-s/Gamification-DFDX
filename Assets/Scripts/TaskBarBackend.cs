using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBarBackend : MonoBehaviour
{

    [SerializeField] private string noteSceneName;
    [SerializeField] private string profileSceneName;

    private string _currentSceneName;
    private string _prevSceneName = "S_MainMenu";
    private SceneHanlderComponent _sceneHanlderComp;

    // private enum NavState
    // {
    //     NotesOpen,
    //     ProfileOpen,
    //     NeitherOpen
    // }
    //
    // public enum ButtonLabel
    // {
    //     Left,
    //     Right
    // }

    // private NavState _currentState;

    public static TaskBarBackend Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    private void Start()
    {
        _sceneHanlderComp = GetComponent<SceneHanlderComponent>();
        _currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void OnRightButtonClick()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        if (_currentSceneName == profileSceneName)
        {
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        _prevSceneName = _currentSceneName;
        _sceneHanlderComp.LoadScene(profileSceneName);
    }

    public void OnLeftButtonClick()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        if (_currentSceneName == noteSceneName)
        {
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        _prevSceneName = _currentSceneName;
        _sceneHanlderComp.LoadScene(noteSceneName);
    }
}
