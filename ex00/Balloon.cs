using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    public Image balloon;
    public Image air;
    private RectTransform _ballonSize;
    private RectTransform _airBar;
    private Vector3 defaultSize;
    private Vector3 _balloonMaxSize;
    private float costSpace = 0.08f;
    private float _mult = 1;

    private void Start()
    {
        _airBar = air.GetComponent<RectTransform>();
        _ballonSize = balloon.GetComponent<RectTransform>();
        defaultSize = _ballonSize.localScale;
        _balloonMaxSize = new Vector3(_ballonSize.localScale.x * 7f, _ballonSize.localScale.y * 7f,
            _ballonSize.localScale.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && air.fillAmount - costSpace > 0)
        {
            _mult = 1.1f;
            air.fillAmount -= costSpace;
            if (_ballonSize.localScale.x > _balloonMaxSize.x)
            {
                Destroy(balloon);
                Debug.Log("Balloon life time: " + (int)Time.time + "s");
                Destroy(this);
            }
        }
        else if (_ballonSize.localScale.x > defaultSize.x)
            _mult = 0.999f;
        else
            _ballonSize.localScale = defaultSize;

        if (!Input.GetKeyDown(KeyCode.Space) && air.fillAmount < 1f)
            air.fillAmount += 0.001f;
        _ballonSize.localScale = new Vector3(_ballonSize.localScale.x * _mult, _ballonSize.localScale.y * _mult,
            _ballonSize.localScale.z);
    }
}
