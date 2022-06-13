using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] private float _deathTime = 2f; 
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3, 5);
        _rectTransform = GetComponent<RectTransform>();
        Destroy(gameObject, _deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        // _rectTransform.position += new Vector3(0,0.01f,0);
        transform.Translate(new Vector3(0,-speed / 3,0));
        // transform.position -= new Vector3(0,speed,0);
    }
}
