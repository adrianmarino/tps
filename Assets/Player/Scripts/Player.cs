using UnityEngine;
using System;

namespace TPS
{
	[RequireComponent (typeof(Animator))]
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
		}

		#endregion

		#region Attributes

		Animator animator;

		CharacterController controller;

		[SerializeField]
		float runSpeed;

		[SerializeField]
		float jumpSpeed;

		[SerializeField]
		float rotationSpeed;

		[SerializeField]
		float gravity;

		Vector3 moveDirection;

		#endregion


		public Player ()
		{
			runSpeed = 10f;
			jumpSpeed = 10f;
			rotationSpeed = 500f;
			gravity = 10f;
			moveDirection = Vector3.zero;
		}
	}
}