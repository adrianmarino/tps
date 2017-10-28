using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.Networking.NetworkSystem;

public class PlayerOld : MonoBehaviour {

	#region Properties
	private Animator playerAnimator;
	private Rigidbody playerRigidbody;
	public float movementSpeed = 100f;
	#endregion

	void Start () {
		playerAnimator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();

		deathAnimations = new List<string>();
		deathAnimations.Add (DEATH_FRONT);
		deathAnimations.Add (DEATH_BACK);
	}

	void Update () {
		playAnimationWhenPressMouseButton (playerAnimator, nextDeathAnimation (), MIDDLE_MOUSE_BUTTON);

		float horozontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		playerAnimator.SetFloat ("inputHorizontal", horozontal);
		playerAnimator.SetFloat ("inputVertical", vertical);

		float horizontalMovement = horozontal  * movementSpeed * Time.deltaTime;
		float vertitalMovement = vertical * movementSpeed * Time.deltaTime;
		playerRigidbody.velocity = new Vector3 (horizontalMovement, 0f, vertitalMovement);


		playerAnimator.transform.parent.position = playerAnimator.transform.position;
	}

	private string nextDeathAnimation ()
	{
		return deathAnimations[Random.Range (0, deathAnimations.Count)];
	}

	#region Util methods
	public static void playAnimationWhenPressKey (Animator animator, string animationName, string keyName)
	{
		if (Input.GetKeyDown (keyName))
			animator.Play (animationName, -1, 0f);
	}
	public static void playAnimationWhenPressMouseButton (Animator animator, string animationName, int button)
	{
		if (Input.GetMouseButtonDown(button))
			animator.Play (animationName, -1, 0f);
	}
	#endregion

	#region Constants
	private const string DEATH_FRONT = "death_from_the_front";
	private const string DEATH_BACK = "death_from_the_back";

	private const string KEY_ONE = "1";
	private const string KEY_TWO = "2";
	private const string KEY_THREE = "3";
	private const int MIDDLE_MOUSE_BUTTON = 0;
	#endregion

	#region Attributes
	private List<string> deathAnimations;
	#endregion
}

