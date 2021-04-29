using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGo : MonoBehaviour
{
    Vector3 movevec;
    void Start()
    {
        movevec = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movevec * Time.deltaTime * 100);
    }
}
