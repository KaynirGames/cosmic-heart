using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float angle = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float radians = (angle + transform.rotation.z) * Mathf.Deg2Rad;

            Debug.Log("Sin = " + Mathf.Sin(radians));
            Debug.Log("Cos = " + Mathf.Cos(radians));
        }
    }
}
