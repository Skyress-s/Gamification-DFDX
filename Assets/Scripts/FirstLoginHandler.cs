using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
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
        _animator.Play(finishNameTransitionClip.name);
        SceneHandler.LoadSceneWithDefaultTransition("S_TEMP");
    }
    
    #endregion
}