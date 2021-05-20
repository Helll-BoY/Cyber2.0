using UnityEngine;
using System.Collections;
/*
 * Swipe Input script for Unity by @fonserbc, free to use wherever
 *
 * Attack to a gameObject, check the static booleans to check if a swipe has been detected this frame
 * Eg: if (SwipeInput.swipedRight) ...
 *
 * 
 */

public class SwipeInput : MonoBehaviour
{

	// If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 0.5f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public const float MIN_SWIPE_DISTANCE = 0.17f;

	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;


	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;
	private CharacterController _characterController;
	private Vector3 moveVec, gravity;

	public GameObject scr;

	public float speed, jumpSpeed;
	public Animator anim;
	private int laneNumber = 1,
		lanesCount = 2;

	public float firstsLanePos,
		laneDistance,
		sideSpeed;

	bool but = false;

	public void Start()
    {
		_characterController = GetComponent<CharacterController>();

		gravity = Vector3.zero;
		anim = GetComponent<Animator>();
	}
	public void Update()
	{
		swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;
		float input = Input.GetAxis("Horizontal");
		if (Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				startTime = Time.time;
			}
			if (t.phase == TouchPhase.Ended)
			{
				if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
					return;

				Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

				if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
					return;
				
				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
				{ // Horizontal swipe
					
					if (swipe.x > 0)
					{

						laneNumber = laneNumber + 1;
						swipedRight = true;
					//	laneNumber += (int)Mathf.Sign(input);
					//	laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
					
					//	Vector3 newPos = transform.position;
					//	newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
					//	transform.position = newPos;
					}
					else
					{
						laneNumber = laneNumber - 1;
						swipedLeft = true;
						
						//laneNumber += (int)Mathf.Sign(input);
						//laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
						
					}
				}
				else
				{
					
					if (swipe.y > 0)
					{
						swipedUp = true;
					}
					else
					{
						swipedDown = true;
					}
				}
			}
			
			
		}


	
	
	}
	void FixedUpdate()
	{
		//	Debug.Log(laneNumber);
		moveVec += gravity;
		moveVec *= Time.deltaTime;
		if (_characterController.isGrounded)
		{
			//if (Input.GetKey(KeyCode.S))
			//	{
			//anim.SetBool("slide", true);
			//Invoke("a", 0.9f);
			//}
			gravity = Vector3.zero;
			if (swipedUp == true)
			{
				Debug.Log("jump");
				gravity.y = jumpSpeed;
				anim.SetBool("inAir", true);
				StartCoroutine(o());
			}


		}

		else
		{
			gravity += Physics.gravity * Time.deltaTime * 3;
			//  anim.SetBool("inAir", false);
		}
		
		_characterController.Move(moveVec);
		if (swipedRight == true && laneNumber == 2)
		{
			//Debug.Log(2);
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
			transform.position = -newPos;
	
		}
		if (swipedRight == true && laneNumber == 1)
		{
			//Debug.Log(1);
				Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
				transform.position = -newPos;
			
		}
		if (swipedRight == true && laneNumber == 0)
		{
			//Debug.Log(0);
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
			transform.position = -newPos;

		}
		if (swipedLeft == true && laneNumber == 2)
		{
		//	Debug.Log(2);
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
			transform.position = -newPos;

		}
		if (swipedLeft == true && laneNumber == 1)
		{
			//Debug.Log(1);
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
			transform.position = -newPos;

		}
		if (swipedLeft == true && laneNumber == 0)
		{
			//Debug.Log(0);
			Vector3 newPos = transform.position;
			newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);
			transform.position = -newPos;

		}



		if (_characterController.isGrounded)
		{
			//if (Input.GetKey(KeyCode.S))
		//	{
				//anim.SetBool("slide", true);
				//Invoke("a", 0.9f);
			//}
			gravity = Vector3.zero;
			if (swipedUp == true)
			{
				gravity.y = jumpSpeed;
				anim.SetBool("inAir", true);
				StartCoroutine(o());
			}


		}

		else
		{
			gravity += Physics.gravity * Time.deltaTime * 3;
			//  anim.SetBool("inAir", false);
		}
	
	}

	public IEnumerator o()
	{
		yield return new WaitForSeconds((float)0.9);
		anim.SetBool("inAir", false);
	}
	public void a()
	{

		anim.SetBool("slide", false);
	}


}