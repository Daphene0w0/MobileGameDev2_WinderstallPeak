using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public GameObject explosion;
	public float waitTime = 1.0f;


	//For Movement
	private CharacterController controller;

	private float verticalVelocity;
	public float speed = 100.0f;

	private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

	private const float Lane_Distance = 3.0f;


	//For Jumping
	private Vector3 direction;
	public float jumpForce;
	public float Gravity = -9.81f;


	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}


	private void Update()
	{
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
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}


	private void MoveRight(bool goingRight)
	{
		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp(desiredLane, 0, 2);
	}


	private void FixedUpdate()
	{
		controller.Move(direction * Time.deltaTime);
	}


	private void Jump()
	{
		direction.y = jumpForce;
	}
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            Debug.Log("Player Died");
            //Destroy the player
            Destroy(hit.gameObject);
            var particles = Instantiate(explosion, new Vector3(0, 0, -2) + transform.position, Quaternion.identity);
            //Call the function ResetGame after waitTime has passed
            Invoke("ResetGame", waitTime);
        }
    }
}