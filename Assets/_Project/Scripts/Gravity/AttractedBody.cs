using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class AttractedBody : MonoBehaviour
{
    private Attractor attractor;
    private Rigidbody rb;
    [SerializeField] private bool placeOnSurface = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = Attractor.instance;
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb);
    }
}
