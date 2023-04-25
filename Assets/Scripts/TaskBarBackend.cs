using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBarBackend : MonoBehaviour
{

    [SerializeField] private string noteSceneName;
    [SerializeField] private string profileSceneName;
    [SerializeField] private string menuSceneName;

    public string MenuSceneName => menuSceneName;

    [field:SerializeField] public string nextSceneName { get; private set; }


    private string _currentSceneName;
    private string _prevSceneName = "S_MainMenu";
    private SceneHanlderComponent _sceneHanlderComp;

    private void Start() {
        _sceneHanlderComp = GetComponent<SceneHanlderComponent>();
        _currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void OnRightButtonClick()
    {
        // if (_dataManager.stringsDictionary.ContainsKey("prevScene")) _prevSceneName = _dataManager.stringsDictionary["prevScene"];
        _prevSceneName = PlayerPrefs.GetString("prevScene", menuSceneName);
        
        _currentSceneName = SceneManager.GetActiveScene().name;
        // Debug.LogError("Scenes: " + _currentSceneName + " | " + noteSceneName + " | " + _prevSceneName);
        if (_currentSceneName == profileSceneName)
        {
            // // Debug.LogError("return from profile");
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        if (_currentSceneName == noteSceneName)
        {
            return;   
        }
        // // Debug.LogError("open profile");
        _prevSceneName = _currentSceneName;
        // _dataManager.stringsDictionary["prevScene"] = _prevSceneName;
        PlayerPrefs.SetString("prevScene", _prevSceneName);
        PlayerPrefs.Save();
        _sceneHanlderComp.LoadScene(profileSceneName);
    }

    public void OnLeftButtonClick()
    {
        // if (_dataManager.stringsDictionary.ContainsKey("prevScene")) _prevSceneName = _dataManager.stringsDictionary["prevScene"];
        _prevSceneName = PlayerPrefs.GetString("prevScene", menuSceneName);
        
        _currentSceneName = SceneManager.GetActiveScene().name;
        // Debug.LogError("Scenes: " + _currentSceneName + " | " + noteSceneName + " | " + _prevSceneName);
        if (_currentSceneName == noteSceneName)
        {
            // Debug.LogError("return from notes");
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        if (_currentSceneName == profileSceneName)
        {
            return;   
        }
        // // Debug.LogError("open notes");
        _prevSceneName = _currentSceneName;
        // _dataManager.stringsDictionary["prevScene"] = _prevSceneName;
        PlayerPrefs.SetString("prevScene", _prevSceneName);
        PlayerPrefs.Save();
        _sceneHanlderComp.LoadScene(noteSceneName);
    }

    public void OnBackButtonClick()
    {
        _prevSceneName = PlayerPrefs.GetString("prevScene", menuSceneName);
        PlayerPrefs.Save();
        if (SceneManager.GetActiveScene().name == menuSceneName)
        {
            Application.Quit();
        }
        if (_currentSceneName == noteSceneName || _currentSceneName == profileSceneName)
        {
            // Debug.LogError("return from notes");
            _sceneHanlderComp.LoadScene(_prevSceneName);
            return;
        }
        _sceneHanlderComp.LoadScene(menuSceneName);
    }
}
