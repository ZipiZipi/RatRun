using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Destroy(other.gameObject);
        }
    }
}
