using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Waletarget : MonoBehaviour {

    NavMeshAgent agent;
    Animator anima;
    public GameObject target;//đối tuộng muốn chạy tới
                             // Use this for initialization
    void Start()
    {

        anima = gameObject.GetComponent<Animator>();//get animation mặc định



        agent = gameObject.GetComponent<NavMeshAgent>();


        //lấy cái navigation

    }
    public void MoveToPosition(Vector3 position)
    {
        agent.SetDestination(position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Sqrt(Mathf.Abs((transform.position.x - target.transform.position.x) * (transform.position.x - target.transform.position.x) + (transform.position.z - target.transform.position.z) * (transform.position.z - target.transform.position.z))) < 100)&& (Mathf.Sqrt(Mathf.Abs((transform.position.x - target.transform.position.x) * (transform.position.x - target.transform.position.x) + (transform.position.z - target.transform.position.z) * (transform.position.z - target.transform.position.z))) >= 30))
        {
            anima.SetBool("move", true);
            anima.SetBool("beat", false);
            agent.SetDestination(target.transform.position);//tới chỗ đó

        }
        if ((Mathf.Sqrt(Mathf.Abs((transform.position.x - target.transform.position.x) * (transform.position.x - target.transform.position.x) + (transform.position.z - target.transform.position.z) * (transform.position.z - target.transform.position.z))) < 30))
        {
            anima.SetBool("move", false);
            anima.SetBool("beat", true);
        }
        if ((Mathf.Sqrt(Mathf.Abs((transform.position.x - target.transform.position.x) * (transform.position.x - target.transform.position.x) + (transform.position.z - target.transform.position.z) * (transform.position.z - target.transform.position.z))) >= 100))
        {
            anima.SetBool("move", false);
            anima.SetBool("beat", false);
        }



    }
}
