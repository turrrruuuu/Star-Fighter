using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.5f;
    void Update()
    {
        BulletPos();
    }
    void BulletPos()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y > 7f)
        {
            Destroy(this.gameObject);
        }
    }
}
