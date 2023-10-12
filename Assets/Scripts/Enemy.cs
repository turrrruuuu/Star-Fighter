using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    //private Vector3 _spawnPos = new Vector3(Random.Range(-9.25f, 9.25f), 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -7f)
        {
            float randX = Random.Range(-9.25f, 9.25f);
            transform.position = new Vector3(randX, 7f, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);

        }
    }
}
