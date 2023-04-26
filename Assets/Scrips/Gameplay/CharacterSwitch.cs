using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    
    public GameObject vanillaPrefab;
    public GameObject chocolatePrefab;
    public GameObject strawberryPrefab;

    // Update is called once per frame
    void Start()
    {
        if(PlayerPrefs.GetInt("SnowmanFlavour") == 1)
        {
            Instantiate(vanillaPrefab, transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("SnowmanFlavour") == 2)
        {
            Instantiate(chocolatePrefab, transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("SnowmanFlavour") == 3)
        {
            Instantiate(strawberryPrefab, transform.position, Quaternion.identity);
        }

    }

}
