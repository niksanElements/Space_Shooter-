using UnityEngine;
using System.Collections;

public class BGSContorller : MonoBehaviour
{
    private Vector3 startPosition;

    public float scorllSpeed;
    public float tileSizeZ;

	void Start ()
    {
        startPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scorllSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
