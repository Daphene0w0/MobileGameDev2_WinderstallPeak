using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    private int waitTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("PlayerIsDead") == 1)
        {
            //gameOverPanel.SetActive(true);
            //Time.timeScale = 0;

            StartCoroutine(LoadGameOverMenu(waitTime));
            //Invoke("LoadGameOverMenu", waitTime);

        }
    }

    IEnumerator LoadGameOverMenu(int waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        
        gameOverPanel.SetActive(true);
        PlayerPrefs.SetInt("PlayerIsDead", 0);
        //Time.timeScale = 0;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("PlayerIsDead", 0);
    }
}
