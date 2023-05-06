using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    //variables for swiping
    public float minShopSwipeDistance = 0.25f; //how far player need to swipe to execute an action
    private float minShopSwipeDistancePixels; //holds value above and converts to pixels

    private Vector2 shopTouchStart;

    // To direct to the specific object intended to rotate, just in case.
    public GameObject SnowmanDisplay;

    // Original rotation position and Max rotation position

    Quaternion firstSkin = Quaternion.Euler (0, 0, 0); // default skin
    Quaternion secondSkin = Quaternion.Euler(0, 120, 0); // choco skin
    Quaternion thirdSkin = Quaternion.Euler(0, 240, 0); // strawberry skin

    public int currentSkin = 2;

    public float shopRotateSpeed = 10f;

    // To use with Lerp for smooth transition when changing characters.
    public float shopRotateDistance = 120.0f;

    //boolean for skins for gameplay reference
    public bool isUsingVanilla = true;
    public bool isUsingChocolate = false;
    public bool isUsingStrawberry = false;

    private void Start()
    {
        minShopSwipeDistancePixels = minShopSwipeDistance * Screen.dpi;

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //detect player touch
            if (Input.touchCount > 0)
            {
                Touch shoptouch = Input.touches[0];

                if (shoptouch.phase == TouchPhase.Began)
                {
                    shopTouchStart = shoptouch.position;
                }
                else if (shoptouch.phase == TouchPhase.Ended)
                {
                    Vector2 touchEnd = shoptouch.position;

                    float x = touchEnd.x - shopTouchStart.x;

                    if (x < 0)
                    {
                        NextSnowmanLeft();
                    }

                    if (x > 0)
                    {
                        NextSnowmanRight();
                    }
                }
            }
            switchSnowman();
        }
    }

    // swipe directions and switching skins
    void NextSnowmanLeft()
    {
        currentSkin += 1;
    }

    void NextSnowmanRight()
    {
        currentSkin -= 1;
    }

    void switchSnowman()
    {
        switch (currentSkin)
        {
            default:
        
                currentSkin = 2;
                PlayerPrefs.SetInt("SnowmanFlavour", 1); // To set the default (vanilla) skin
                break;

            case 1:
                transform.rotation = Quaternion.Slerp(transform.rotation, thirdSkin, 1 * Time.deltaTime * shopRotateSpeed);
                usingStrawberry();
                break;

            case 2:
                transform.rotation = Quaternion.Slerp(transform.rotation, firstSkin, 1 * Time.deltaTime * shopRotateSpeed);
                usingVanilla();
                break;

            case 3:
                transform.rotation = Quaternion.Slerp(transform.rotation, secondSkin, 1 * Time.deltaTime * shopRotateSpeed);
                usingChocolate();
                break;

            case 4:
                transform.rotation = Quaternion.Slerp(transform.rotation, thirdSkin, 1 * Time.deltaTime * shopRotateSpeed);
                usingStrawberry();
                break;
        }
    }

    public void usingVanilla()
    {
        PlayerPrefs.SetInt("SnowmanFlavour", 1);
        print("usingVanilla");
    }

    public void usingChocolate()
    {
        PlayerPrefs.SetInt("SnowmanFlavour", 2);
        print("usingChoco");
    }

    public void usingStrawberry()
    {
        PlayerPrefs.SetInt("SnowmanFlavour", 3);
        print("usingStrawberry") ;
    }
}
