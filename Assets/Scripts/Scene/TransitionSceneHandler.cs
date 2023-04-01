using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip introClip;
    [SerializeField] private AnimationClip outroClip;

    private void Start()
    {
        animator.Play(introClip.name);
        StartCoroutine(LoadScene(introClip.length, outroClip));
    }

    private IEnumerator LoadScene(float delay, AnimationClip outroClip)
    {
        yield return new WaitForSeconds(delay);
        // get scene
        Scene transitionScene = SceneManager.GetActiveScene();
        // load scene and save into handle
        var handle = SceneManager.LoadSceneAsync(SceneHandler.NewSceneName, LoadSceneMode.Additive);
        handle.completed += operation => {
            // set to active
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneHandler.NewSceneName));
            SceneManager.UnloadSceneAsync(SceneHandler.PreviousSceneName);
            
            animator.Play(this.outroClip.name);
            StartCoroutine(UnloadScene(transitionScene, outroClip.length));
        };
    }

    private IEnumerator UnloadScene(Scene scene, float delay)
    {
        
        // unload transitionScene
        yield return new WaitForSeconds(delay);
        SceneManager.UnloadSceneAsync(scene);
    }
}