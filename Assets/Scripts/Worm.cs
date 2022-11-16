using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 3f;
    private bool _isLeft = true;

    private void Start()
    {
        gameObject.transform.position = new Vector3(_point1.position.x, _point1.position.y, transform.position.z);
    }

    private void Update()
    {
        if (_isLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point1.position, speed * Time.deltaTime);
        }
        if (transform.position == _point1.position)
        {
            Transform tempoPoint = _point1;
            _point1 = _point2;
            _point2 = tempoPoint;
            _isLeft = false;
            StartCoroutine(Waiting());
        }
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);

        if (transform.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        _isLeft = true;
    }
}
