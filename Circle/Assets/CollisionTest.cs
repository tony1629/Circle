using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dummy")
        {
            print("Enter");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "dummy")
        {
            print("Stay");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "dummy")
        {
            print("Exit");
        }
    }
}
