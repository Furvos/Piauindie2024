using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float age;
	void OnCollisionStay(Collision collision)
	{
		if (collision.collider.CompareTag("Rain"))
		{
			Debug.Log("It's Raining Man, oh, Aleluia");
			age -= 1f * Time.deltaTime;
		}

	}
}
