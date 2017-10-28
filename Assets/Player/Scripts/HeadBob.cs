using UnityEngine;

public class HeadBob : MonoBehaviour
{
	#region Attributes

	public float bobbingSpeed = 0.18f;
	public float bobbingAmount = 0.2f;
	public float midpoint = 2.0f;
	public float count = 0;

	float timer = 0.0f;

	Vector3 cSharpConversion;

	#endregion

	void Update ()
	{
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		cSharpConversion = transform.localPosition;

		if (Mathf.Abs (horizontal) == 0 && Mathf.Abs (vertical) == 0)
			timer = 0.0f;
		else {
			waveslice = Mathf.Sin (timer);
			timer = timer + bobbingSpeed;
			if (timer > Mathf.PI * 2)
				timer = timer - (Mathf.PI * 2);
		}

		if (waveslice != 0) {
			float translateChange = waveslice * bobbingAmount;
			float totalAxes = Mathf.Abs (horizontal) + Mathf.Abs (vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
			translateChange = totalAxes * translateChange;
			cSharpConversion.y = midpoint + translateChange;
		} else
			cSharpConversion.y = midpoint;
		transform.localPosition = cSharpConversion;
	}
}

