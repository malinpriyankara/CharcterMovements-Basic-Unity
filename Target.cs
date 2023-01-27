using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _flashLight;
    void Start()
    {
        
    }//Start

    
    void Update()
    {
        
    }//Update
    private void OnCollisionEnter(Collision collision)//Coding Challange 011
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _flashLight.SetActive(true);
            print("Collision Occured");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) _flashLight.SetActive(false);
    }

}//Class
