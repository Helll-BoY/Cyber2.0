using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGo : MonoBehaviour
{
    Vector3 movevec;
    void Start()
    {
        StartCoroutine("i");
        movevec = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movevec * Time.deltaTime * 100);
    }
    public IEnumerator i()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
  
}
