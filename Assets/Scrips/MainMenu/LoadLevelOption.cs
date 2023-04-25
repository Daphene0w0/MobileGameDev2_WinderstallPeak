using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOption : MonoBehaviour
{
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }
}
