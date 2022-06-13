using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField]private GameObject Baloon;
    [SerializeField]private GameObject Air;

    private RectTransform _tranBal;
    private RectTransform _tranAir;

    private bool _win;
    private bool _lose;

    private Time _time;
    private float _timeF;

    [SerializeField]private float _timeDeath = 120f;
    
    // Start is called before the first frame update
    void Start()
    {
        _tranBal = Baloon.GetComponent<RectTransform>();
        _tranAir = Air.GetComponent<RectTransform>();
        _timeF = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_win)
        {
            Destroy(Baloon);
            Debug.Log("Balloon life time: "+Mathf.RoundToInt(Time.time)+"s");
            Destroy(this);
        }

        if (_lose)
        {
            Debug.Log("Balloon life time: "+Mathf.RoundToInt(_timeDeath)+"s");
            Destroy(this);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _tranAir.localScale.y > 1)
        {
            _tranAir.localScale -= new Vector3(0, 0.2f, 0f);
            _tranBal.localScale += Vector3.one * 0.5f;
        }

        if (_tranBal.localScale.x > 10)
        {
            _win = true;
        }

        if (Time.time > _timeDeath)
        {
            _lose = true;
        }
        // Debug.Log(Time.time);
        
        
        if (_tranBal.localScale.x > Vector3.one.x)
        {
            _tranBal.localScale -= Vector3.one * 0.001f;
        }
        
        if (_tranAir.localScale.y <  5)
        {
            _tranAir.localScale += new Vector3(0, 0.001f, 0f);
        }
    }
}
