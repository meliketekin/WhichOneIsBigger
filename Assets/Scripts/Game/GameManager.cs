using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject upPanel;
    [SerializeField]
    private GameObject compareText, chooseText;
    [SerializeField]
    private GameObject rectangle1, rectangle2;
    [SerializeField]
    private GameObject countDown;
    [SerializeField]
    private Text countDownText, rectangleText1, rectangleText2;
    [SerializeField]
    private GameObject[] circles;
    [SerializeField]
    private GameObject trueIcon, falseIcon;
    [SerializeField]
    private GameObject pausePanel, finalPanel;
    [SerializeField]
    private Text time, score, trueCounterTxt, falseCounterTxt, finalScore;
    [SerializeField]
    private AudioClip begin, finish, trueAudio, falseAudio;
    timeManager timeManager;
    int topNumber, bottomNumber, questionLevel, questionCounter;
    int bigNumber, clickValue;
    int totalScore, scoreInc;
    int trueCounter, falseCounter;
    int scoreTime = 10;
    int total = 0;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audioSource.PlayOneShot(begin);
        trueCounter = 0;
        falseCounter = 0;
        totalScore = 0;
        score.text = "0";
        finalScore.GetComponent<RectTransform>().localScale = Vector3.zero;
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        timeManager = Object.FindObjectOfType<timeManager>();
        rectangleText1.text = "";
        rectangleText2.text = "";
        upPanel.GetComponent<CanvasGroup>().DOFade(1,1.5f);
        compareText.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        rectangle1.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        rectangle2.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        chooseText.GetComponent<CanvasGroup>().DOFade(0,0f);
        circleGo();
        StartCoroutine("beginCountDown");
           
    }

    void circleGo()
    {
        foreach(var circle in circles)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    void findLevelforQuestion()
    {
        if (questionCounter < 5)
        {
            questionLevel = 1;
            scoreInc = 10;
        }
        else if (questionCounter >= 5 && questionCounter < 10)
        {
            questionLevel = 2;
            scoreInc = 20;
        }
        else if (questionCounter >= 10 && questionCounter < 15)
        {
            questionLevel = 3;
            scoreInc = 30;
        }
        else if (questionCounter >= 15 && questionCounter < 20)
        {
            questionLevel = 4;
            scoreInc = 40;
        }
        else if (questionCounter >= 20 && questionCounter < 25)
        {
            questionLevel = 5;
            scoreInc = 50;
        }
        else
        {
            questionLevel = Random.Range(1, 6);
            scoreInc = 60;
        }
        findLevel();
    } 
    void findLevel()
    {

    
        if (questionLevel==1)
        {
            firstLevel();
            
        }
        else if (questionLevel == 2)
        {
            secondLevel();
        }
        else if (questionLevel == 3)
        {
            thirdLevel();
        }
        else if (questionLevel == 4)
        {
            fourthLevel();
        }
        else if (questionLevel == 5)
        {
            fifthLevel();
        }
        

    }

    void firstLevel()
    {
        int random = Random.Range(0, 50);
        if(random<=25)
        {
            topNumber = Random.Range(0, 50);
            bottomNumber = topNumber + Random.Range(1, 20);
        }
        else
        {
            bottomNumber = Random.Range(0, 50);
            topNumber = bottomNumber + Random.Range(1, 20);
        }
        if(topNumber>bottomNumber)
        {
            bigNumber = topNumber;
        }
        else
        {
            bigNumber = bottomNumber;
        }
        rectangleText1.text = topNumber.ToString();
        rectangleText2.text = bottomNumber.ToString();

    }

    void secondLevel()
    {
        int firstnum = Random.Range(1, 10);
        int secondnum = Random.Range(1, 20);

        int thirdnum = Random.Range(1, 10);
        int fourthnum = Random.Range(1, 20);

        topNumber = firstnum + secondnum;
        bottomNumber = thirdnum + fourthnum;

        if(topNumber>bottomNumber)
        {
            bigNumber = topNumber;
        }
        else if (topNumber < bottomNumber)
        {
            bigNumber = bottomNumber;
        }
        else if(topNumber==bottomNumber)
        {
            secondLevel();
        }
        rectangleText1.text = firstnum + " + " + secondnum;
        rectangleText2.text = thirdnum + " + " + fourthnum;
    }

    void thirdLevel()
    {
        int firstnum = Random.Range(15, 50);
        int secondnum = Random.Range(1, 15);

        int thirdnum = Random.Range(15, 50);
        int fourthnum = Random.Range(1, 15);

        topNumber = firstnum - secondnum;
        bottomNumber = thirdnum - fourthnum;

        if (topNumber > bottomNumber)
        {
            bigNumber = topNumber;
        }
        else if (topNumber < bottomNumber)
        {
            bigNumber = bottomNumber;
        }
        else
        {
            thirdLevel();
        }
        rectangleText1.text = firstnum + " - " + secondnum;
        rectangleText2.text = thirdnum + " - " + fourthnum;
    }

    void fourthLevel()
    {
        int firstnum = Random.Range(1, 15);
        int secondnum = Random.Range(1, 20);

        int thirdnum = Random.Range(1, 15);
        int fourthnum = Random.Range(1, 20);

        topNumber = firstnum * secondnum;
        bottomNumber = thirdnum * fourthnum;

        if (topNumber > bottomNumber)
        {
            bigNumber = topNumber;
        }
        else if (topNumber < bottomNumber)
        {
            bigNumber = bottomNumber;
        }
        else
        {
            thirdLevel();
        }
        rectangleText1.text = firstnum + " x " + secondnum;
        rectangleText2.text = thirdnum + " x " + fourthnum;
    }

    void fifthLevel()
    {
        int divisor1 = Random.Range(1, 50);
        topNumber = Random.Range(1, 15);
        int dividend1 = divisor1 * topNumber;

        int divisor2 = Random.Range(1, 50);
        bottomNumber = Random.Range(1, 15);
        int dividend2 = divisor2 * bottomNumber;

        if (topNumber > bottomNumber)
        {
            bigNumber = topNumber;
        }
        else if (topNumber < bottomNumber)
        {
            bigNumber = bottomNumber;
        }
        else
        {
            fourthLevel();
        }
        rectangleText1.text = dividend1 + " / " + divisor1;
        rectangleText2.text = dividend2 + " / " + divisor2;
    }
    IEnumerator beginCountDown()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(0.3f);
        countDown.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        countDown.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);

        countDownText.text = "2";
        yield return new WaitForSeconds(0.3f);
        countDown.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        countDown.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);

        countDownText.text = "1";
        yield return new WaitForSeconds(0.3f);
        countDown.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        countDown.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.4f);

        StopAllCoroutines();

        Debug.Log("game began");
        StartCoroutine(timeManager.countTime());
        compareText.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        chooseText.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        findLevelforQuestion();

    }

    public void buttonValue(string clickButton)
    {
        if(clickButton=="topButton")
        {
            clickValue = topNumber;
        }
        else if (clickButton == "bottomButton")
        {
            clickValue = bottomNumber;
        }

        if(clickValue==bigNumber)
        {
            trueCounter++;
            audioSource.PlayOneShot(trueAudio);
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.3f);
            totalScore += scoreInc;
            score.text = totalScore.ToString();
            Invoke("IconGo", 0.3f);
            circles[questionCounter%5].GetComponent<RectTransform>().DOScale(1, 0.3f);

            if(questionCounter%5==0)
            {
                circleGo();
            }
            questionCounter++;
            findLevelforQuestion();
        }
        else
        {
            falseCounter++;
            audioSource.PlayOneShot(falseAudio);
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.3f);
            Invoke("IconGo",0.3f);
            levelDown();
            findLevelforQuestion();
        }
    }

    void IconGo()
    {
        trueIcon.GetComponent<RectTransform>().DOScale(0, 0.3f);
        falseIcon.GetComponent<RectTransform>().DOScale(0, 0.3f);
    }
    void levelDown()
    {

        questionCounter -= (questionCounter % 5 + 5);
        if(questionCounter<0)
        {
            questionCounter = 0;
        }
        circleGo();
        
    }

    public void tryAgain()
    {
        pausePanel.SetActive(false);
        Start();
        beginCountDown();

    }
    public void backToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void exit()
    {
       pausePanel.SetActive(false);
    }
    public void pause()
    {
        pausePanel.SetActive(true);
    }

    public void startAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void finishGame()
    {
        audioSource.PlayOneShot(finish);
        time.text = "00";
        finalPanel.SetActive(true);
        trueCounterTxt.text = trueCounter.ToString();
        falseCounterTxt.text = falseCounter.ToString();
        finalScore.GetComponent<RectTransform>().DOScale(1, 0.2f);
        StartCoroutine(printScore());    
    }
    IEnumerator printScore()
    {
        for(int i=0;i<scoreTime;i++)
        {
            if(i==0)
            {
                yield return new WaitForSeconds(0.3f);
                int scoreTimeInc = totalScore / scoreTime;
                total += scoreTimeInc;
                finalScore.text = total.ToString();


            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                int scoreTimeInc = totalScore / scoreTime;
                total += scoreTimeInc;
                finalScore.text = total.ToString();
            }
        }
    }
}
