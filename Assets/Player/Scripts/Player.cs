using UnityEngine;
using System;

// [RequireComponent (typeof(LookAtMouse))]
public class Player : MonoBehaviour
{

	#region Update

	void Update ()
	{
		this.UpdateMovement ();
		this.UpdateAnimation ();
	}

	void UpdateAnimation ()
	{
		if (!controller.isGrounded)
			return;
		animator.SetFloat ("forward-back", this.GetVertical ());
		animator.SetFloat ("left-right", this.GetHorizontal ());	
	}

	void UpdateMovement ()
	{
		if (controller.isGrounded) {
			moveDirection = new Vector3 (this.GetHorizontal (), 0, this.GetVertical ());
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= runSpeed;
			if (this.IsJump ())
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

		transform.Rotate (0, GetMouseHorizontal () * rotationSpeed, 0);
	}

	void LateUpdate ()
	{
		chestBone.LookAt (aimTarget.position);
		chestBone.rotation = chestBone.rotation * Quaternion.Euler (aimOffset);
	}

	#endregion

	#region Input

	Boolean IsJump ()
	{
		return Input.GetButton ("Jump");
	}

	float GetVertical ()
	{
		return Input.GetAxis ("Vertical");
	}

	float GetHorizontal ()
	{
		return Input.GetAxis ("Horizontal");
	}

	float GetMouseHorizontal ()
	{
		return Input.GetAxis ("Mouse X");
	}

	#endregion

	#region Inittialization

	void Start ()
	{
		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
		chestBone = animator.GetBoneTransform (HumanBodyBones.Chest);
	}

	#endregion

	#region Attributes

	Animator animator;

	CharacterController controller;

	Transform chestBone;

	[SerializeField]
	Transform aimTarget;

	[SerializeField]
	Vector3 aimOffset;

	[SerializeField]
	float runSpeed = 10f;

	[SerializeField]
	float jumpSpeed = 10f;

	[SerializeField]
	float rotationSpeed = 500f;

	[SerializeField]
	float gravity = 10f;

	Vector3 moveDirection = Vector3.zero;

	#endregion
}
