using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isHit;
    public float _force;
    [SerializeField] private GameObject _club;
    [SerializeField] private GameObject _aim;
    private int _score = -15;
    public float _inertia;
    private Vector3 _auf;
    public GameObject aim;
    private Club _clubS;
    void Start()
    {
        _clubS = _club.GetComponent<Club>();
        _auf = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            if (_force > 0)
            {
                if (_inertia > 0)
                {
                    if (transform.position.y > 850 || transform.position.y < 150)
                    {
                        _auf *= -1;
                    }

                    Vector3 pos = transform.position + _auf * _inertia * _clubS._reverse;
                    // pos.y = Mathf.Clamp(pos.y, 0f, 800f);
                    // Debug.Log(pos.y);
                    transform.position = pos;
                    // transform.position += Vector3.up * _inertia;
                    _inertia -= 0.0005f;
                }
                _force--;
            }
            else
            {
                if(!isHit)
                    return;
                if (transform.position.y - _aim.transform.position.y > 25 ||
                    transform.position.y - _aim.transform.position.y < -25)
                {
                    _score += 5;
                    Debug.Log("Score: " + _score);
                }
                else
                {
                    Debug.Log("You win!");
                    Destroy(gameObject);
                    Destroy(_club);
                }
                if(_score == 5)
                    Debug.Log("You lose!");
                isHit = false;
                var club = _club.GetComponent<Club>();
                club._lastPos = transform.position;
                club._hit = false;
                if (transform.position.y > aim.transform.position.y)
                {
                    _club.transform.rotation = new Quaternion(_club.transform.rotation.x, _club.transform.rotation.y,
                        180, _club.transform.rotation.w);
                    club._reverse = -1;
                }
                else
                {
                    _club.transform.rotation = new Quaternion(_club.transform.rotation.x, 90,
                        0, _club.transform.rotation.w);
                    club._reverse = 1;
                }
                _club.transform.position = transform.position;
                
                _auf = Vector3.up;
            }
        }
    }
}
