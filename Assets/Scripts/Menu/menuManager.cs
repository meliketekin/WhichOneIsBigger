using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField]
    private Transform brainImage;

    [SerializeField]
    private GameObject startButton;
    void Start()
    {
        brainImage.GetComponent<RectTransform>().DOLocalMoveX(0f, 2f).SetEase(Ease.OutBack);
        startButton.GetComponent<RectTransform>().DOLocalMoveY(-236f,2f).SetEase(Ease.OutBack);
    }

    public void play()
    {
        SceneManager.LoadScene("GameScene");
    }

   
}
