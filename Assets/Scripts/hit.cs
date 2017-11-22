using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public float force = 5f;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))//chuột trái mặc định là fire1
        {
            Ray ray = new Ray(transform.position, transform.forward);
            //lúc này scrip chứa trong cây súng nên cây súng là đối tượng nên ta truy xuất transform là truy xuất vị trí cây súng)
            //vẽ 1 đường thẳng từ cây súng tới trước
            //tạo 1 đường thẳng từ màn hình tới vị trí trỏ chuột
            RaycastHit hit;
            //khi mà vật thể mà ray nó chạm sẽ tạo ra vật thể đó


            if (Physics.Raycast(ray, out hit) && hit.rigidbody != null&& hit.collider.gameObject.tag == "Finish")
            {
                hit.rigidbody.AddForceAtPosition(Vector3.one * force, hit.point);
                
            }
        }
    }
}
