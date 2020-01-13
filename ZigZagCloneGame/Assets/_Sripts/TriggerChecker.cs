using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField]
    private string ball_tag;
    private Rigidbody platform_rigidbody;


    public void Start()
    {
        platform_rigidbody = GetComponentInParent<Rigidbody>();
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(ball_tag))
        {

            Invoke("fallDown",0.5f);
            
        }
    }

    public void fallDown()
    {
        platform_rigidbody.isKinematic = false;
        platform_rigidbody.useGravity = true;
        Destroy(transform.parent.gameObject,2f);
    }



}//trigger checker class
