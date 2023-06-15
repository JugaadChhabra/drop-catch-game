using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] public GameObject effect;
    GameManager gameManager;
    public GameObject gamemanager;
    [SerializeField] public GameObject[] apple;
    [SerializeField] public GameObject[] cross;
    public int count = 0;
    public static bool isRunning = true;

    void Awake() 
    {
        gameManager = gamemanager.GetComponent<GameManager>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("object"))
        {
            Destroy(collision.gameObject);
            GameObject ob = Instantiate(effect, objectController.pos, transform.rotation);
            Destroy(ob,2f);

            if (count != 4)
            {

                // Deactivating the first child of each game object in the apple array
                foreach (GameObject appleObj in apple)
                {
                    if (appleObj.transform.childCount > 0)
                    {
                        appleObj.transform.GetChild(count).gameObject.SetActive(false);
                    }
                }

                // Activating the first child of each game object in the cross array
                foreach (GameObject crossObj in cross)
                {
                    if (crossObj.transform.childCount > 0)
                    {
                        crossObj.transform.GetChild(count).gameObject.SetActive(true);
                    }
                }
                count += 1;
            }

            else
            {
                Time.timeScale = 0f;
                gameManager.GameOverMenu.SetActive(true);
                gameManager.score.SetActive(false);
                gameManager.apple.SetActive(false);
                gameManager.cross.SetActive(false);
                isRunning = false;
            }

        }
    }


}


