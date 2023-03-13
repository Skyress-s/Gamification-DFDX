using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class FirstLoginHandler : MonoBehaviour
{

    [SerializeField] private AnimationClip finishNameTransitionClip;
    [SerializeField] private TMP_InputField inputField;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (finishNameTransitionClip == null || inputField == null)
        {
            Debug.LogError($"ERROR {gameObject.name} HAS UNSET REFERENCES");
            Selection.activeGameObject = gameObject;
            return;
        }
    }

    #region UIMethods
    public void OnFinishWritingName()
    {
        Debug.Log(inputField);
        // SceneHandler.LoadSceneWithDefaultTransition("S_TEMP");
        Scene prev = SceneManager.GetActiveScene();
        var handler = SceneManager.LoadSceneAsync("S_TEMP", LoadSceneMode.Additive);
        handler.completed += operation => {
            _animator.Play(finishNameTransitionClip.name);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("S_TEMP"));
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