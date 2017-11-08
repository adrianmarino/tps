using System;
using System.Collections.Generic;
using TPS;
using UnityEngine;

namespace FPS
{
	[RequireComponent (typeof(Animator))]
	public class CharacterAim : MonoBehaviour
	{

		void LateUpdate ()
		{
			aimBones.ForEach (bone => bone.PointTo (GetTargetPosition ()));
		}

		Vector3 GetTargetPosition ()
		{
			if (aimCamera != null) {
				Vector3 forwardPoint = new Vector3 (0.5f, 0.5f, aimCamera.nearClipPlane + 10);
				return aimCamera.ViewportToWorldPoint (forwardPoint);
			}

			return aimTarget.position;
		}


		#region Inittialization

		void InitializeAimBones ()
		{
			if (aimBones.Count == 0) {
				Transform chestTransform = animator.GetBoneTransform (HumanBodyBones.Chest);
				Bone chestBone = new Bone (chestTransform, Vector3.zero);
				aimBones.Add (chestBone);
			}
		}

		void Start ()
		{
			animator = this.GetComponent<Animator> ();
			this.InitializeAimBones ();
		}

		#endregion

		#region Attributes

		Animator animator;

		[SerializeField]
		List<Bone> aimBones;

		[SerializeField]
		Camera aimCamera;

		[SerializeField]
		Transform aimTarget;

		#endregion

		public CharacterAim ()
		{
			aimBones = new List<Bone> ();
		}
	}
}

