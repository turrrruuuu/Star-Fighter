using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randX = Random.Range(-9.2f, 9.2f);
            Vector3 position = new Vector3(randX, 6, 0);
            Instantiate(_enemy, position,Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
