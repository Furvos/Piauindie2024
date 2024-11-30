using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Range(0f,10f)]
	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;
	public float speedMultiplier = 5f;

	private float vertical;
	private float rotation;
	private Rigidbody rb;
	void Start()
    {
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

	}

    void FixedUpdate()
    {
		rb.MovePosition(rb.position + transform.forward * vertical * speedMultiplier * Time.fixedDeltaTime);
		//Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		//Quaternion deltaRotation = Quaternion.Euler(yRotation);
		//Quaternion targetRotation = rb.rotation * deltaRotation
		Vector3 targetPosition = rb.position;

		if (rotation == 0)
		{
			rb.MoveRotation(Quaternion.Euler(Vector3.zero) * rb.rotation);
		}
		if (vertical == 0)
		{
			rb.MovePosition(Vector3.LerpUnclamped(rb.position, targetPosition, Time.deltaTime));
		}



		Quaternion deltaRotation2 = Quaternion.Euler(new Vector3(0, 80 * rotation, 0) * Time.fixedDeltaTime);

		//rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 80f * Time.deltaTime));
		rb.MoveRotation(rb.rotation * deltaRotation2);
	}
}
