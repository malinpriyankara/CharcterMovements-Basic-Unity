using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
   
    private Rigidbody _rigidB;
    [SerializeField]
    private float movementForce = 5.0f;
    [SerializeField]
    private Renderer _playerRenderer;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _rotationSpeed=5;
    private Color _playerColor;
    [SerializeField]
    private GameObject _spotLight;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _originPoint;
    [SerializeField]
    private GameObject _hammer;
    [SerializeField]
    private GameObject[] _objects;
    [SerializeField]
    private float _bulletSpeed = 10f;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _bulletOriginPoint;

   
    void Start()
    {
        _rigidB = GetComponent<Rigidbody>();
        _playerRenderer = _player.GetComponent<Renderer>();
        _playerRenderer.material.SetColor("_Color", Color.red);
        _playerColor = _playerRenderer.material.color;
    }//start

    
    void Update()
    {
        PlayerMove();
        ChangeColor();
        ChangeScale();
        ChangeRotation();
        Fire();
    }//update

    private void PlayerMove()//Coading Challange 001
    {
        _rigidB.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * movementForce);
    }//Player Move
    private void ChangeRotation()//Coading Challange 002
    {
        
        if (Input.GetKeyDown(KeyCode.Z)) transform.rotation = Quaternion.Euler( new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y*_rotationSpeed, transform.rotation.eulerAngles.z));
        
    }//Change Rotation
    private void ChangeScale()//Coading Challange 003
    {
        if (Input.GetKeyDown(KeyCode.Q)) _player.transform.localScale = new Vector3(_player.transform.localScale.x, _player.transform.localScale.y, _player.transform.localScale.z) * 2 ;

    }//Change Scale
    private void ChangeColor()//Coading Challange 004
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _playerRenderer.material.SetColor("_Color", Color.red);
        } 
        if (Input.GetKeyDown(KeyCode.G))
        {
            _playerRenderer.material.SetColor("_Color", Color.green);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _playerRenderer.material.SetColor("_Color", Color.blue);
        }

        
    }//Change Color
    private void OnCollisionEnter(Collision collision)//coding Challange 005/006/007/008
    {
        if (collision.gameObject.CompareTag("WinBoard")) _playerRenderer.material.SetColor("_Color", Color.black);//Coading Challange 005
       
        if (collision.gameObject.CompareTag("LightOn")) _spotLight.SetActive(true);//Coading Challange 006
        
        if (collision.gameObject.CompareTag("Enemy"))//Coading Challange 007
        {
            Destroy(_enemy,1.0f);
            Destroy(_player, 3.0f);
        }
        if (collision.gameObject.CompareTag("Trigger")) Instantiate(_hammer, _originPoint.transform.position,Quaternion.identity);//Coading Challange 008


    }//On Collision Enter
    
    private void OnCollisionExit(Collision collision)//Coading Challange 006
    {
        if (collision.gameObject.CompareTag("LightOn"))
        {
            _spotLight.SetActive(false);
        }
    }//On Collision Exit
    
    private void Fire()//Coading Challange 010;
    {
        if(Input.GetMouseButtonDown(0)) Instantiate(_bullet, _bulletOriginPoint.transform.position, Quaternion.identity);
    }//Fire

}//Class
