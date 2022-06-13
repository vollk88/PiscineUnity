using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private RectTransform _playGround;
    [SerializeField] private GameObject ball;
    private RectTransform ballRect;
    private PongBall pongeBall;
    private RectTransform pl1;
    private RectTransform pl2;
    private RectTransform defaultPos;
    private int _score1;
    private int _score2;

    public GameObject LeftTop;
    public GameObject LeftBot;
    public GameObject RightTop;
    public GameObject RightBot;
    
    private void Start()
    {
        ballRect = ball.GetComponent<RectTransform>();
        defaultPos = ballRect;
        pongeBall = ball.GetComponent<PongBall>();
        pl1 = player1.GetComponent<RectTransform>();
        pl2 = player2.GetComponent<RectTransform>();
    }
    
    private void Update()
    {
        if ((pl1.anchoredPosition.x + pl1.rect.xMax / 2 > ballRect.anchoredPosition.x &&
             pl1.anchoredPosition.y + pl1.rect.height/2 > ballRect.anchoredPosition.y &&
             pl1.anchoredPosition.y - pl1.rect.height/2 < ballRect.anchoredPosition.y)||
            (pl2.anchoredPosition.x - pl2.rect.xMax / 2 < ballRect.anchoredPosition.x &&
             pl2.anchoredPosition.y + pl2.rect.height / 2 > ballRect.anchoredPosition.y &&
             pl2.anchoredPosition.y - pl2.rect.height / 2 < ballRect.anchoredPosition.y))
            pongeBall.ModH *= -1;
        if (Input.GetKey(KeyCode.S))
            if (player1.transform.position.y > LeftBot.transform.position.y)
                player1.transform.Translate(Vector3.down * Time.deltaTime * 60f);
        if (Input.GetKey(KeyCode.W))
            if (player1.transform.position.y < LeftTop.transform.position.y)
                player1.transform.Translate(Vector3.up * Time.deltaTime * 60f);
        if (Input.GetKey(KeyCode.DownArrow))
            if (player2.transform.position.y > LeftBot.transform.position.y)
                player2.transform.Translate(Vector3.down * Time.deltaTime * 60f);
        if (Input.GetKey(KeyCode.UpArrow))
            if (player2.transform.position.y < LeftTop.transform.position.y)
                player2.transform.Translate(Vector3.up * Time.deltaTime * 60f);
        if (!(ballRect.anchoredPosition.x <= _playGround.rect.xMin) &&
            !(ballRect.anchoredPosition.x >= _playGround.rect.xMax)) return;
        if (ballRect.anchoredPosition.x <= _playGround.rect.xMin)
            _score2++;
        else if (ballRect.anchoredPosition.x >= _playGround.rect.xMax)
            _score1++;
        ball.transform.position = Vector3.zero;
        Debug.Log("Player 1: " + _score1 + " | " + "Player 2: " + _score2);
    }
}
