using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject vanillaPrefab;
    public GameObject chocolatePrefab;
    public GameObject strawberryPrefab;

    ShopManager isUsingVanilla;
    ShopManager isUsingChocolate;
    ShopManager isUsingStrawberry;


    // Update is called once per frame
    void Start()
    {
        if(isUsingVanilla == true)
        {
            VanillaPlay();
        }
        else if (isUsingChocolate == true)
        {
            ChocoPlay();
        }
        else if (isUsingStrawberry == true)
        {
            StrawberryPlay();
        }

    }

    public void VanillaPlay()
    {
        vanillaPrefab.SetActive(true);
        chocolatePrefab.SetActive(false);
        strawberryPrefab.SetActive(false);
    }

    public void ChocoPlay()
    {
        strawberryPrefab.SetActive(false);
        vanillaPrefab.SetActive(false);
        chocolatePrefab.SetActive(true);
    }

    public void StrawberryPlay()
    {
        vanillaPrefab.SetActive(false);
        chocolatePrefab.SetActive(false);
        strawberryPrefab.SetActive(true);
    }
}
