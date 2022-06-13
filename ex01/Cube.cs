using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private KeyCode keyToDestroy;
    private float _speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
        _speed = Random.Range(40f, 80f);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
