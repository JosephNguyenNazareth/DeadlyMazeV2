using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFlame : MonoBehaviour
{
    public GameObject obj;
    public float high=5.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward*high);
            //tạo đường thẳng từ súng tới trước
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "enemy")
            {
                Instantiate(obj, hit.point, Quaternion.identity);
            }
        }

    }
}

