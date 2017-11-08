using UnityEngine;

namespace TPS
{

	[System.Serializable]
	public class Bone
	{
		public void PointTo (Vector3 target)
		{
			if (!enable)
				return;

			transform.LookAt (target);
			transform.rotation = transform.rotation * Quaternion.Euler (offset);
		}

		#region Attributes

		[SerializeField]
		string name;

		[SerializeField]
		bool enable;

		[SerializeField]
		Transform transform;

		[SerializeField]
		Vector3 offset;

		#endregion

		public Bone ()
		{
			enable = true;
			name = "";
		}

		public Bone (Transform transform, Vector3 offset)
		{
			this.transform = transform;
			this.offset = offset;
		}
	}
}
