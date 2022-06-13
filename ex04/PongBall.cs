using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    [SerializeField] private RectTransform _playGround;

    private RectTransform ball;
    private int modV = 1;
    private int modH = 1;

    public int ModH
    {
        get => modH;
        set => modH = value;
    }
    
    void Start()
    {
        Debug.Log(transform.position);
        Debug.Log(_playGround.rect.yMax);
        ball = gameObject.GetComponent<RectTransform>();
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 40 * modV);
        transform.Translate(Vector3.left * Time.deltaTime * 40 * modH);
        if (ball.anchoredPosition.y >= _playGround.rect.yMax || ball.anchoredPosition.y <= _playGround.rect.yMin)
            modV *= -1;
        if (ball.anchoredPosition.x >= _playGround.rect.xMax || ball.anchoredPosition.x <= _playGround.rect.xMin)
        {
            modH *= -1;
        }
    }
}
