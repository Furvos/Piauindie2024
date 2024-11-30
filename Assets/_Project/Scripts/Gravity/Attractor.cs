using UnityEngine;

public class Attractor : MonoBehaviour
{
	public static Attractor instance;

	private SphereCollider col;

	private void Awake()
	{
		instance = this;
		col = GetComponent<SphereCollider>();
	}

	public float gravity = -10f;

	public void Attract (Rigidbody body)
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		body.AddForce(gravityUp * gravity);
		
		RotateBody(body);
	}

	public void PlaceOnSurface (Rigidbody body)
	{
		body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * col.radius));
	}

	void RotateBody (Rigidbody body)
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
		body.MoveRotation(Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));

	}
}