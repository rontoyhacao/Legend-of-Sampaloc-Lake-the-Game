using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI QuestionText;
    [SerializeField] List<QuestionSO> Questions = new List<QuestionSO>();
    [SerializeField] QuestionSO CurrentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] AnswerButtons;
    int CorrectAnswerIndex;
    bool HasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite DefaultAnswerSprite;
    [SerializeField] Sprite CorrectAnswerSprite;
    [SerializeField] Sprite WrongAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer Timer;
    [SerializeField] TextMeshProUGUI TimerText;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI ScoreText;
    ScoreKeeper ScoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider ProgressBar;

    public bool IsComplete;
    int MaxQuestions = 10;
    int QuestionCounter = 0;

    [Header("Fast Forward Button")]
    [SerializeField] Button FastForwardButton;

    void Start()
    {
        Timer = FindObjectOfType<Timer>();
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
        ProgressBar.maxValue = MaxQuestions;
        ProgressBar.value = 0;
    }

    void Update()
    {
        TimerImage.fillAmount = Timer.FillFraction;
        TimerText.text = Mathf.Round((Timer.TimerValue)).ToString();
        if(Timer.LoadNextQuestion)
        {
            if (ProgressBar.value == ProgressBar.maxValue)
            {
                IsComplete = true;
                return;
            }

            HasAnsweredEarly = false;
            GetNextQuestion();
            Timer.LoadNextQuestion = false;
        }
        else if(!HasAnsweredEarly && !Timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonsInteractable(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        HasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonsInteractable(false);
        Timer.CancelTimer();

        Data2.ScoreData = ScoreKeeper.CalculateScore();
        ScoreText.text = Data2.ScoreData.ToString() + "%";

        
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;
        Image wrongButtonImage;
        CorrectAnswerIndex = CurrentQuestion.GetCorrectAnswerIndex();
        string correctAnswer = CurrentQuestion.GetAnswer(CorrectAnswerIndex);
        string textPurpose = CurrentQuestion.GetTextPurpose();

        FastForwardButton.gameObject.SetActive(true);

        if (index == CurrentQuestion.GetCorrectAnswerIndex())
        {
            QuestionText.text = $"Tama! Ang layunin ng may akda sa teksto ay {correctAnswer.ToLower()}. {textPurpose}";
            buttonImage = AnswerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
            ScoreKeeper.IncrementCorrectAnswers();
            SoundCollection.instance.CallSfx(7);
        }
        else if(index == -1)
        {
            QuestionText.text = $"Subukan mo muli! Ang tamang layunin ng may akda sa teksto ay {correctAnswer.ToLower()}. {textPurpose}";
            buttonImage = AnswerButtons[CorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
        }
        else
        {
            QuestionText.text = $"Subukan mo muli! Ang tamang layunin ng may akda sa teksto ay {correctAnswer.ToLower()}. {textPurpose}";
            wrongButtonImage = AnswerButtons[index].GetComponent<Image>();
            wrongButtonImage.sprite = WrongAnswerSprite;
            buttonImage = AnswerButtons[CorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
            SoundCollection.instance.CallSfx(8);
        }
    }

    void GetNextQuestion()
    {
        if(MaxQuestions > 0)
        {
            SetButtonsInteractable(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            ProgressBar.value++;
            QuestionCounter++;
            ScoreKeeper.IncrementQuestionsSeen();
            FastForwardButton.gameObject.SetActive(false);
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, Questions.Count);
        CurrentQuestion = Questions[index];

        if(Questions.Contains(CurrentQuestion))
        {
            Questions.Remove(CurrentQuestion);
        }
    }

    void DisplayQuestion()
    {
        QuestionText.text = CurrentQuestion.GetQuestion();
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = CurrentQuestion.GetAnswer(i);
        }
    }

    void SetButtonsInteractable(bool state)
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            Button button = AnswerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Image buttonImage = AnswerButtons[i].GetComponent<Image>();
            buttonImage.sprite = DefaultAnswerSprite;
        }
    }
}
