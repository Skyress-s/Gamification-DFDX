using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MultipleChoiceButtonsWrapper : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    
    public Button Button1 => button1;
    public Button Button2 => button2;
    public Button Button3 => button3;
    public Button Button4 => button4;
    
    public UnityEvent<int> onButtonClicked = new UnityEvent<int>();
    
    // public UnityEvent onCorrectAnswer = new UnityEvent();
    // public UnityEvent onWrongAnswer = new UnityEvent();

    private void Start() {
        button1.onClick.AddListener(() => OnButtonClicked(0));
        button2.onClick.AddListener(() => OnButtonClicked(1));
        button3.onClick.AddListener(() => OnButtonClicked(2));
        button4.onClick.AddListener(() => OnButtonClicked(3));   
    }

    private void OnButtonClicked(int p0) {
        onButtonClicked?.Invoke(p0);
    }


    public void SetupButtons(MultipleChoiceQuestion question) {
        button1.GetComponentInChildren<TMP_Text>().text = question.answer1;
        button2.GetComponentInChildren<TMP_Text>().text = question.answer2;
        button3.GetComponentInChildren<TMP_Text>().text = question.answer3;
        button4.GetComponentInChildren<TMP_Text>().text = question.answer4;
    }

    /// <summary>
    /// Get the button, if button index does not exists, return null
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    Button GetButtonFromIndex(int index) {
        switch (index) {
            case 0:
                return button1;
            case 1:
                return button2;
            case 2:
                return button3;
            case 3:
                return button4;
        }

        return null;
    }
    
    Button GetButtonFromAnswer(MultipleChoiceQuestion.CorrectAnswer answer) {
        switch (answer) {
            case MultipleChoiceQuestion.CorrectAnswer.A:
                return button1;
            case MultipleChoiceQuestion.CorrectAnswer.B:
                return button2;
            case MultipleChoiceQuestion.CorrectAnswer.C:
                return button3;
            case MultipleChoiceQuestion.CorrectAnswer.D:
                return button4;
        }

        return null;
    }
    
    public void SetHighlight(int index, Color color) {
        Transform backgroundTransform = GetButtonFromIndex(index).transform.GetChild(0);
        LeanTween.cancel(backgroundTransform.gameObject);
        LeanTween.moveLocal(backgroundTransform.gameObject, Vector3.zero, 1.2f).setEaseOutCirc();
        backgroundTransform.GetComponent<Image>().color = color;
    }
}
