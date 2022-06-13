using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public Vector3 _lastPos;
    private bool _readyForHit = true;
    [SerializeField]private GameObject _ballObj;
    private Ball _ball;
    private int _force;
    public bool _hit;
    public int _reverse = 1;
    void Start()
    {
        _ball = _ballObj.GetComponent<Ball>();
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_readyForHit && Input.GetKey(KeyCode.Space))
        {
            _readyForHit = false;
        }
        
        if (Input.GetKey(KeyCode.Space) && !_readyForHit)
        {
            transform.position -= Vector3.up * _reverse;
            // Debug.Log(3);
            _force++;
        }
        else if((_lastPos.y > transform.position.y && !_readyForHit && _reverse == 1) || (_lastPos.y < transform.position.y && !_readyForHit && _reverse == -1))
        {
            // Debug.Log(2);
            transform.position += Vector3.up * _reverse;
        }
        else if(_lastPos == transform.position && !_readyForHit && !_hit)
        {
            _hit = true;
            // Debug.Log("1");
            Hit();
        }
        else
        {
            _readyForHit = true;
            _lastPos = transform.position;
        }
        
    }

    void Hit()
    {
        if (!_ball.isHit)
        {
            _ball.isHit = true;
            // transform.position = _ballObj.transform.position;
            _ball._force = 2*_force;
            _ball._inertia = 1;
            _force = 0;
        }
    }
}
