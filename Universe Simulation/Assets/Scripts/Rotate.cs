using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform orbitTarget; // planet's orbit target
    public float distanceFromTarget; // distance between planet and its orbit planet
    public float orbitSpeed; // rotation speed around the orbit target
    public float selfRotationSpeed; // self rotation speed
    public float radius; // radius of the object

    // Update is called once per frame
    void Update()
    {
        if (orbitTarget != null)
        {
            // orbiting around the target
            transform.RotateAround(orbitTarget.position, Vector3.up, orbitSpeed * Time.deltaTime);

            // calculating the relative position
            Vector3 offset = transform.position - orbitTarget.position;
            offset = offset.normalized * distanceFromTarget;
            transform.position = orbitTarget.position + offset;

            // self rotation
            transform.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
        }
    }
}
