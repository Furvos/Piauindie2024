using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;

    void Update()
    {
		//if press click then plant
		{
			if (Input.GetMouseButtonDown(0)) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hit))
				{
					if (hit.collider.CompareTag("PlacementArea")) // Ensure valid area
					{
						Plant(hit.point);
					}
				}
			}
		}
	}

    void Plant(Vector3 position)
    {
        GameObject item = Instantiate(seedPrefab, position, Quaternion.identity);
    }
}
