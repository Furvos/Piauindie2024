using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
	private void Start()
	{
		GetComponent
	}
	void FixedUpdate()
    {
		Vector3 centerOfSphere = sphere.transform.position;

		Vector3 placementPosition = placePosition;

		Vector3 normal = (placementPosition - centerOfSphere).normalized;
	}
}
