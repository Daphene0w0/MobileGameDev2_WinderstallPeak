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
            StartCoroutine(LoadGameOverMenu(waitTime));
        }
    }

    IEnumerator LoadGameOverMenu(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(1);

    }

    public void Restart()
    {
        PlayerPrefs.SetInt("PlayerIsDead", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
