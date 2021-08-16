using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    [SerializeField]
    private Text time;
    GameManager gameManager;
    void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    public IEnumerator countTime()
    {
    for(int i=90;i>=0 ;i--)
        {
            if(i<10)
            {
                time.text = "0" + i.ToString();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                time.text = i.ToString();
                 yield return new WaitForSeconds(1f);
            }
            if(i==0)
            {
                gameManager.finishGame();
            }
        }
    }
}
