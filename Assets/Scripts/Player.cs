using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.5f;
    [SerializeField]
    private GameObject _bulletPrefab;    // Start is called before the first frame updat
    private float _canFire= 0f ;
    [SerializeField]
    private float _fireRate = 0.3f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot() ;
        }

    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        //transform.Translate(Vector3.right*horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);

        //if (transform.position.y <= -4.0f)
        //{
        //    transform.position = new Vector3(transform.position.x, -4.0f, 0);
        //}
        //else if (transform.position.y >= 6.0f)
        //{

        //    transform.position = new Vector3(transform.position.x, 6.0f, 0);
        //}
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.0f, 6.0f), 0);
        if (transform.position.x < -11.25f)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
        else if (transform.position.x > 11.25f)
        {
            transform.position = new Vector3(-11.25f, transform.position.y, 0);
        }
    }
    void Shoot()
    {
        
            _canFire = Time.time + _fireRate;
            Debug.Log("Space");
            Instantiate(_bulletPrefab, transform.position + new Vector3(0,0.8f,0),Quaternion.identity); ;
        
    }
}

