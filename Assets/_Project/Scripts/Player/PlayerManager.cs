using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	
    [SerializeField] float age;

	private void Update()
	{
		age -= 1f * Time.deltaTime;
	}

}
