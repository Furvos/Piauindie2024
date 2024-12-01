using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//CÓDIGO NOVO QUE PESQUEI DO STACKOVERFLOW https://stackoverflow.com/questions/67654629/i-wrote-a-script-for-movement-and-mouse-look-movement-works-but-mouse-look-does

	public bool underRain;
	[SerializeField] private float _speed = 7f;
	[SerializeField] private float _mouseSensitivity = 50f;
	[SerializeField] private float _minCameraview = -70f, _maxCameraview = 80f;
	private CharacterController _charController;
	private Camera _camera;
	private float xRotation = 0f;
	void Start()
	{
		_charController = GetComponent<CharacterController>();
		_camera = Camera.main;

		if (_charController == null)
			Debug.Log("No Character Controller Attached to Player");

		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update()
	{
		//Get WASD Input for Player
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		//move player based on WASD Input
		Vector3 movement = transform.forward * vertical + transform.right * horizontal; //changed this line.
		_charController.Move(movement * Time.deltaTime * _speed);

		//Get Mouse position Input
		float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity; //changed this line.
		float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity; //changed this line.
																	 //Rotate the camera based on the Y input of the mouse
		xRotation -= mouseY;
		//clamp the camera rotation between 80 and -70 degrees
		xRotation = Mathf.Clamp(xRotation, _minCameraview, _maxCameraview);

		_camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
		//Rotate the player based on the X input of the mouse
		transform.Rotate(Vector3.up * mouseX * 3);

		//verify rain:
		if (underRain)
		{
			Debug.Log("Player Under Rain!");
		}
		else
		{
			Debug.Log("Player Out of Rain");
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Rain"))
		{
			underRain = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Rain"))
		{
			underRain = false;
		}
	}


	/*	
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

			rb.MoveRotation(rb.rotation * deltaRotation2);
		} */
}
