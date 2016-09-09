using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float tumble;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
