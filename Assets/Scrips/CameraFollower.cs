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

    private void FixedUpdate()
	{
        if (lookAt != null)
        {
            Vector3 desiredPosition = lookAt.position + offset;
            //desiredPosition.x = 0;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
            
        }
        else
        {
            Invoke("RestartScene", waitTime);
        }


	}

	private void RestartScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
