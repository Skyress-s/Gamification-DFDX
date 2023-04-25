using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MultipleChoiceHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MultipleChoiceQuestion question;
    [SerializeField] private MultipleChoiceButtonsWrapper buttonsWrapper;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Button hintButton;
    [SerializeField] TaskBarBackend taskBarBackend;
    
    public Action onRequestGuidance;
    
    private Transform _mathematician;
    private void Start() {
        if (question == null) {
            Debug.LogError("NO QUESTION SET");
            return;
        }
        // try to get mathematician
        _mathematician = GameObject.FindGameObjectWithTag("Mathematician").transform;
        
        buttonsWrapper.SetupButtons(question);
        title.text = question.question;

        onRequestGuidance += PlayGuidance;
        buttonsWrapper.onButtonClicked.AddListener(OnButtonClicked);
        hintButton.onClick.AddListener(() => onRequestGuidance?.Invoke());
        
        
        // testing todo remove
        
        // var task = PlayGuidanceSequence();
    }

    private void OnButtonClicked(int arg0) {
        Color green = new Color(55f/255, 250f/255f, 90f/255f, 0.8f);
        Color red = new Color(237f/255, 106f/255f, 94f/255f, 0.5f);
        if (arg0 == (int)question.correctAnswer) {
            buttonsWrapper.SetHighlight(0, red);
            buttonsWrapper.SetHighlight(1, red);
            buttonsWrapper.SetHighlight(2, red);
            buttonsWrapper.SetHighlight(3, red);
            buttonsWrapper.SetHighlight(arg0, green);
            Action yesAction = () => {
                SceneHandler.LoadSceneWithDefaultTransition(taskBarBackend.nextSceneName);
            };
            Action noAction = () => {
                SceneHandler.LoadSceneWithDefaultTransition(taskBarBackend.MenuSceneName);
            };
            
            ModulWindow.ShowQuestion("Congratulations! You got it right!", "Next Question", "Return to Map", yesAction, noAction);
        }
        else {
            // onRequestGuidance?.Invoke();
        }
        MathDialog dialog = question.MathDialogFromAnswer((MultipleChoiceQuestion.CorrectAnswer)arg0);
        PlayMathDialog(dialog);
        
    }


    void PlayGuidance() {
        MathDialog dialog = question.mathGuidance[Random.Range(0, question.mathGuidance.Count)];
        var animator = _mathematician.GetComponentInChildren<Animator>();
        animator.Play(dialog.AnimationClip.name, 0, 0.1f);
        Vector3[] corners = new Vector3[4];
        _mathematician.GetComponent<RectTransform>().GetWorldCorners(corners);
        MathematicianUtils.PlayMessage(question.mathGuidance[0], corners[1], transform);
    }

    void PlayMathDialog(MathDialog mathDialog){
        var animator = _mathematician.GetComponentInChildren<Animator>();
        if (mathDialog.AnimationClip != null) 
            animator.Play(mathDialog.AnimationClip.name, 0, 0.1f);
        
        Vector3[] corners = new Vector3[4];
        _mathematician.GetComponent<RectTransform>().GetWorldCorners(corners);
        MathematicianUtils.PlayMessage(mathDialog, corners[1], transform);
    }
    
    /*
    async Task PlayGuidanceSequence() {
        await Task.Delay(2000);
        onRequestGuidance?.Invoke();
    }
*/
}