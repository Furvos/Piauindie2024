using Unity.VisualScripting;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
	public bool underRain;
	[SerializeField] float age;
	public int treeStage;

	private void Start()
	{
		age = 0;
		treeStage = 0;
	}
	private void Update()
	{
		//verify rain:
		if (underRain){
			Debug.Log("Plant Under Rain!");
		}
		else if (!underRain) {
			age += Time.deltaTime;
			Debug.Log("Plant Out of Rain");
		}

		if (age >= 10)
		{
			treeStage = 1;
		}
		else if (age >= 20)
		{
			treeStage = 2;
		}
		else if (age >= 25)
		{
			treeStage = 3;
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
