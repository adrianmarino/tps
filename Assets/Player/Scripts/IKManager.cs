using UnityEngine;

namespace TPS
{
	[RequireComponent (typeof(Animator))]
	public class IKManager : MonoBehaviour
	{
		private void OnAnimatorIK (int layerIndex)
		{
			if (!isActive)
				return;
			
			animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, leftHandWeigth);
			animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, leftHandWeigth);  
			animator.SetIKPosition (AvatarIKGoal.LeftHand, leftHandTarget.position);
			animator.SetIKRotation (AvatarIKGoal.LeftHand, leftHandTarget.rotation);
		}

		#region Initialization

		void Start ()
		{
			animator = this.GetComponent<Animator> ();
		}

		#endregion

		#region Attributes

		Animator animator;

		[SerializeField]
		bool isActive;

		[SerializeField]
		Transform leftHandTarget;

		[SerializeField]
		float leftHandWeigth;

		#endregion

		public IKManager ()
		{
			isActive = true;
			leftHandWeigth = 1f;
		}

	}
}
