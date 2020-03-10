using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDelete : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }

}
