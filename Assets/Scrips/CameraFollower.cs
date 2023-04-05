using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollower : MonoBehaviour
{
	public Transform lookAt; //Our MC

	public Vector3 offset = new Vector3(0, 3.0f, -10f);

	PlayerBehaviour playerBehaviour;

	private float waitTime = 2f;

	private void Start()
	{
		transform.position = lookAt.position + offset;
	}


    private void Update()
    {

        if (lookAt == null)
        {
            Invoke("RestartScene", waitTime);
            //playerBehaviour.Invoke("ResetGame", playerBehaviour.waitTime);
        }

    }

    private void FixedUpdate()
	{

        Vector3 desiredPosition = lookAt.position + offset;
        //desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);


	}

	private void RestartScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
