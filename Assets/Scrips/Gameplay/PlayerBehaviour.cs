using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
	public GameObject explosion;
	//public float waitTime = 2f;

	//For Movement
	private CharacterController controller;

	public float speed = 100.0f; //the speed of the character

	public float laneSpeed = 10f; //speed  to move between lanes

	//This is to set the lanes
	private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

	//This is what separates the lanes, distancing each other from one another
	private const float Lane_Distance = 3.3f;


	//variables for swiping
	public float minSwipeDistance = 0.25f; //how far player need to swipe to execute an action
	private float minSwipeDistancePixels; //holds value above and converts to pixels

	private Vector2 touchStart;


	//For Jumping
	private Vector3 direction;
	public float jumpForce;
	public float Gravity = -9.81f;

	//For Sound Effects
	[SerializeField] AudioSource JumpSFX;
	[SerializeField] AudioSource DeathSFX;
	[SerializeField] AudioSource SlideSFX;

	private void Start()
	{
		controller = GetComponent<CharacterController>(); //This is required to use Character Controller related codes

		minSwipeDistancePixels = minSwipeDistance * Screen.dpi;

		PlayerPrefs.SetInt("PlayerIsDead", 0);
	}


	private void Update()
	{

		//detect player touch
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began)
			{
				touchStart = touch.position;
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				Vector2 touchEnd = touch.position;

				float x = touchEnd.x - touchStart.x;

				//gets player input to move left or right
				if (x < 0)
				{
					MoveRight(false);
				}

				if (x > 0)
				{
					MoveRight(true);
				}
			}
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


		// To move. Without these, character won't move
		Vector3 moveVector = Vector3.zero;
		moveVector.x = (targetPosition - transform.position).normalized.x * speed * laneSpeed;
		moveVector.y = -0.1f;
		moveVector.z = speed;


		controller.Move(moveVector * Time.deltaTime);


		//To go back down after jumping
		direction.y += Gravity * Time.deltaTime;

		//this ensures player can only jump once and when they're grounded
		if (controller.collisionFlags == CollisionFlags.Below)
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.touches[0];

				if (touch.phase == TouchPhase.Began)
				{
					touchStart = touch.position;
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					Vector2 touchEnd = touch.position;

					float y = touchEnd.y - touchStart.y;

					//gets player input to move left or right
					if (y > 0)
					{
						Jump();
					}

				}
			}
		}


	}


	//moving lanes function and make movements smooth
	private void MoveRight(bool goingRight)
	{
		SlideSFX.Play();

        desiredLane += (goingRight) ? 1 : -1;


        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
	}
	//private void MoveLeft(bool goingRight)
	//{
	//	SlideSFX.Play();

 //       desiredLane += (goingRight) ? 1 : -1;
       
	//	desiredLane = Mathf.Clamp(desiredLane, 0, 2);
	//}


	private void FixedUpdate()
	{
		controller.Move(direction * Time.deltaTime); //This affects the Jump mechanics
	}


	//jump function
	private void Jump()
	{
		JumpSFX.Play();
		direction.y = jumpForce;
	}


	//if player hits an obstacle what would happen
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.transform.tag == "Obstacle")
		{
			DeathSFX.Play();
			PlayerPrefs.SetInt("PlayerIsDead", 1);
			Debug.Log("Player Died");
			//Destroy the player
			Destroy(this.gameObject);
			var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
			//Call the function ResetGame after waitTime has passed
			//Invoke("LoadGameOverMenu", waitTime);
		}

	}

}