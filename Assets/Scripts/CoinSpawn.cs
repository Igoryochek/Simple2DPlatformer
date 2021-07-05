using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _coinCount;

    private int _spawnDelay=3;

    private void Start()
    {
        StartCoroutine(InstantiateCoin());
    }

    private IEnumerator InstantiateCoin()
    {
        for (int i = 0; i < _coinCount; i++)
        {
            int randomPointIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_coinPrefab, _spawnPoints[randomPointIndex].transform.position, _spawnPoints[randomPointIndex].transform.rotation);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
