using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletForce = 100f;
    private Rigidbody _bulletRBD;
    [SerializeField]
    private GameObject _spotLight;
    void Start()
    {
        _bulletRBD = GetComponent<Rigidbody>();
    }//Start

    
    void Update()
    {
        Fire(); 
    }//Update
    private void Fire()//Coading Challange 010
    {
        _bulletRBD.AddForce(Vector3.forward * _bulletForce * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
      //  if (collision.gameObject.CompareTag("Target")) _spotLight.SetActive(false);
    }
   
}//Class
