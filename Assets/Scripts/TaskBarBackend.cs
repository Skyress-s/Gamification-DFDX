using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBarBackend : MonoBehaviour
{

    [SerializeField] private string noteSceneName;
    [SerializeField] private string profileSceneName;
    [SerializeField] private string menuSceneName;

    private string _currentSceneName;
    private string _prevSceneName = "S_MainMenu";
    private SceneHanlderComponent _sceneHanlderComp;
    private DataManager _dataManager;

    private void Start()
    {
        _dataManager = FindObjectOfType<DataManager>();
        _sceneHanlderComp = GetComponent<SceneHanlderComponent>();
        _currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void OnRightButtonClick()
    {
        if (_dataManager.stringsDictionary.ContainsKey("prevScene")) _prevSceneName = _dataManager.stringsDictionary["prevScene"];
        
        _currentSceneName = SceneManager.GetActiveScene().name;
        Debug.LogError("Scenes: " + _currentSceneName + " | " + noteSceneName + " | " + _prevSceneName);
        if (_currentSceneName == profileSceneName)
        {
            // Debug.LogError("return from profile");
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        if (_currentSceneName == noteSceneName)
        {
            return;   
        }
        // Debug.LogError("open profile");
        _prevSceneName = _currentSceneName;
        _dataManager.stringsDictionary["prevScene"] = _prevSceneName;
        _sceneHanlderComp.LoadScene(profileSceneName);
    }

    public void OnLeftButtonClick()
    {
        if (_dataManager.stringsDictionary.ContainsKey("prevScene")) _prevSceneName = _dataManager.stringsDictionary["prevScene"];
        
        _currentSceneName = SceneManager.GetActiveScene().name;
        Debug.LogError("Scenes: " + _currentSceneName + " | " + noteSceneName + " | " + _prevSceneName);
        if (_currentSceneName == noteSceneName)
        {
            Debug.LogError("return from notes");
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        if (_currentSceneName == profileSceneName)
        {
            return;   
        }
        // Debug.LogError("open notes");
        _prevSceneName = _currentSceneName;
        _dataManager.stringsDictionary["prevScene"] = _prevSceneName;
        _sceneHanlderComp.LoadScene(noteSceneName);
    }

    public void OnBackButtonClick()
    {
        _sceneHanlderComp.LoadScene(menuSceneName);
    }
}
