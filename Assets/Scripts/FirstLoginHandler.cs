using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class FirstLoginHandler : MonoBehaviour
{

    [SerializeField] private AnimationClip finishNameTransitionClip;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string mainMenuScene;
    
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (finishNameTransitionClip == null || inputField == null)
        {
            Debug.LogError($"ERROR {gameObject.name} HAS UNSET REFERENCES");
#if UNITY_EDITOR
            Selection.activeGameObject = gameObject;
#endif
            return;
        }
    }

    #region UIMethods
    public void OnFinishWritingName()
    {
        Debug.Log(inputField);
        PlayerPrefs.SetString("username", inputField.text);
        PlayerPrefs.Save();
        // SceneHandler.LoadSceneWithDefaultTransition("S_TEMP");
        Scene prev = SceneManager.GetActiveScene();
        var handler = SceneManager.LoadSceneAsync(mainMenuScene, LoadSceneMode.Additive);
        handler.completed += operation => {
            _animator.Play(finishNameTransitionClip.name);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(mainMenuScene));
            StartCoroutine(WaitAndUnloadScene(finishNameTransitionClip.length, prev.name));
        };

    }

    IEnumerator WaitAndUnloadScene(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.UnloadSceneAsync(sceneName);
    }
    
    #endregion
}