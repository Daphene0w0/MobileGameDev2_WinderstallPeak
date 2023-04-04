using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject explosion;
    public float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        //First check if we collide with the player
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            Debug.Log("Player Hit");
            //Destroy the player
            //Destroy(collision.gameObject);
            var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
            //Call the function ResetGame after waitTime has passed
            //Invoke("ResetGame", waitTime);
            NextLevel();
        }

    }
    
    private void ResetGame()
    {
        //Restart the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

            /// If the object is tapped, we spawn an explosion and destroy this object
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
