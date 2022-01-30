using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omikuji : MonoBehaviour
{
    private int z=1;

    void Update()
    {
        this.transform.rotation = (this.transform.rotation) * Quaternion.Euler(0, 0, 0.5f * z);
        if (this.transform.rotation.z >= 0.1 || this.transform.rotation.z <= -0.1)
        {
            z *= -1;
        }
    }
}
