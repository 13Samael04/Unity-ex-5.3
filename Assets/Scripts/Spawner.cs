using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _coolDown;
    [SerializeField] private Coin _coin;
        
    private Transform[] _points;
    private Coroutine _coroutine;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _coroutine = StartCoroutine(CreateEnemys());
    }

    private IEnumerator CreateEnemys()
    {
        var waitForSeconds = new WaitForSeconds(_coolDown);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i].position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
