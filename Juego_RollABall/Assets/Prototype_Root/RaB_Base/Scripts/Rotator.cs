using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotSpeedX;
    public float rotSpeedY;
    public float rotSpeedZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * rotSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.up * rotSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotSpeedZ * Time.deltaTime);

    }
}
