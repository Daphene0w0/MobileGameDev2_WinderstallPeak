using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject LevelCompeleteUI;

    [SerializeField] AudioSource levelCompleteSFX;

    
    private void OnTriggerEnter(Collider other)
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        levelCompleteSFX.Play();
        LevelCompeleteUI.SetActive(true);
    }


}
