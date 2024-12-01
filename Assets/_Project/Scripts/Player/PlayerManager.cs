using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public Sprite newSprite;
	public bool underRain;
	[SerializeField] float age;
	public int playerStage;
	private void Start()
	{
		age = 0;
	}
	private void Update()
	{
		//verify rain:
		if (underRain)
		{
			Debug.Log("Player Under Rain!");
		}
		else if (!underRain)
		{
			age += Time.deltaTime;
			Debug.Log("Player Out of Rain");
		}
		if (age >= 10)
		{
			playerStage = 1;
		}
		else if (age >= 20)
		{
			playerStage = 2;
		}
		else if (age >= 25)
		{
			playerStage = 3;
		}
		
	}
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Rain"))
		{
			underRain = true;
			RewindTime();
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Rain"))
		{
			underRain = false;
		}
	}

	private void RewindTime()
	{
		age -= 1f * Time.deltaTime;
	}
}
