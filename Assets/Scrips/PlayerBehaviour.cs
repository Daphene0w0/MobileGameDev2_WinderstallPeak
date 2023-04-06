using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
	public GameObject explosion;
	public float waitTime = 2f;


	//For Movement
	private CharacterController controller;

	private float verticalVelocity; //how fast the character switches lanes

	public float speed = 100.0f; //the speed of the character

	//This is to set the lanes
	private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

	//This is what separates the lanes, distancing each other from one another
	private const float Lane_Distance = 3.0f;


	//For Jumping
	private Vector3 direction;
	public float jumpForce;
	public float Gravity = -9.81f;


	[Header("Object References")]
	public Text scoreText;
	private float score = 0;
	public float Score
	{
 		get { return score; }
		
		set
 		{
 			score = value;
 			// Check if scoreText has been assigned
 			if (scoreText == null)
 			{
 				Debug.LogError("Score Text is not set. " +
 				"Please go to the Inspector and assign it");
 				// If not assigned, don't try to update it.
 				return;
 			}
 		// Update the text to display the whole number portion of the score
 		scoreText.text = string.Format("{0:0}", score);
 	}
}



	private void Start()
	{
		controller = GetComponent<CharacterController>(); //This is required to use Character Controller related codes

		Score = 0;
	}


	private void Update()
	{
		//Points overtime
		Score += Time.deltaTime;

		//gets player input to move left or right
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveRight(false);
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveRight(true);
		}

		//Calculate where we should be in future
		Vector3 targetPosition = transform.position.z * Vector3.forward;

		if (desiredLane == 0)
		{
			targetPosition += Vector3.left * Lane_Distance;
		}
		else if (desiredLane == 2)
		{
			targetPosition += Vector3.right * Lane_Distance;
		}



		Vector3 moveVector = Vector3.zero;
		moveVector.x = (targetPosition - transform.position).normalized.x * speed;
		moveVector.y = -0.1f;
		moveVector.z = speed;


		controller.Move(moveVector * Time.deltaTime);


		//To Jump
		direction.y += Gravity * Time.deltaTime;

		//this ensures player can only jump once and when they're grounded
		if (controller.collisionFlags == CollisionFlags.Below)
        {
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}

		
	}


	//moving lanes function and make movements smooth
	private void MoveRight(bool goingRight)
	{
		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp(desiredLane, 0, 2);
	}


	private void FixedUpdate()
	{
		controller.Move(direction * Time.deltaTime);
	}


	//jump function
	private void Jump()
	{
		direction.y = jumpForce;
    }


    //if player hits an obstacle what would happen
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            Debug.Log("Player Died");
            //Destroy the player
            Destroy(this.gameObject);
            var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
            //Call the function ResetGame after waitTime has passed
            Invoke("ResetGame", waitTime);
        }
    }

    //Reset level function on death
    public void ResetGame()
	{
		//Restart the current level
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}