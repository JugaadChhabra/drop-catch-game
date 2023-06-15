using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    LifeManager lifeManager;
    public GameObject lifemanager;
    [SerializeField] public GameObject GameOverMenu;
    [SerializeField] public GameObject score;
    [SerializeField] public GameObject apple;
    [SerializeField] public GameObject cross;
    
    void Awake() 
    {
        lifeManager = lifemanager.GetComponent<LifeManager>();
    }

    public void RestartGame()
    {   Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        lifeManager.count = 0;
        ScoreManager.score = 0;
        LifeManager.isRunning = true;
    }
}
