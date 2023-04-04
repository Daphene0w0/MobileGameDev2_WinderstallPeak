using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before restarting the game")]
    public float waitTime = 1.0f;

    public GameObject explosion;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
                Debug.Log("Player Died");
                //Destroy the player
                //Destroy(collision.gameObject);
                //var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
                //Call the function ResetGame after waitTime has passed
                //Invoke("ResetGame", waitTime);
        }
        
        //First check if we collide with the player
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("Player Died");
        //    //Destroy the player
        //    Destroy(collision.gameObject);
        //    var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
        //    //Call the function ResetGame after waitTime has passed
        //    Invoke("ResetGame", waitTime);
        //}

    }
    private void ResetGame()
    {
        //Restart the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    /// If the object is tapped, we spawn an explosion and
    /// destroy this object
    private void PlayerTouch()
    {
        if (explosion != null)
        {
            var particles = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(particles, 1.0f);
        }
        Destroy(this.gameObject);
    }
}