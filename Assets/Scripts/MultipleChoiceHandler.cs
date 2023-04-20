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
        if (arg0 == (int)question.correctAnswer) {
            buttonsWrapper.SetHighlight(0, Color.red);
            buttonsWrapper.SetHighlight(1, Color.red);
            buttonsWrapper.SetHighlight(2, Color.red);
            buttonsWrapper.SetHighlight(3, Color.red);
            buttonsWrapper.SetHighlight(arg0, Color.green);
            Action yesAction = () => {
                SceneHandler.LoadSceneWithDefaultTransition(taskBarBackend.nextSceneAsset.name);
            };
            Action noAction = () => {
                SceneHandler.LoadSceneWithDefaultTransition(taskBarBackend.MenuSceneName);
            };
            
            ModulWindow.ShowQuestion("bingus dingus, you got it right!", "Next Question", "Return to Map", yesAction, noAction);
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