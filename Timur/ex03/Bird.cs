using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Bird : MonoBehaviour
{
    public GameObject[] pipes;
    public GameObject[] grounds;
    [SerializeField] private GameObject _pipe;
    public GameObject spawnPipes;
    public GameObject spawnGrounds;

    private float speed = 1;
    private float time;
    private RectTransform _rectTransform;

    private int _score;
    
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        SpawnPipesGround();
        MoveAll();

        transform.position += Vector3.down;
        
        if (Input.GetKeyDown(KeyCode.Space))
            transform.Translate(Vector3.up * 100);

        if (Time.time > time)
        {
            speed += 0.1f;
            time += 1;
        }

        // foreach (var VARIABLE in pipes)
        // {
        //     if (transform.position.x == VARIABLE.transform.position.x)
        //     {
        //         _score += 5;
        //         Debug.Log(_score);
        //     }
        // }
    }

    void CheckDeath()
    {
        if (transform.position.y < 200)
        {
            Died();
        }
        foreach (var pipe in pipes)
        {
            // Debug.Log(_rectTransform.rect.y);
            // var rect = pipe.GetComponent<RectTransform>();
            if(transform.position.x > pipe.transform.position.x - 50 && transform.position.x < pipe.transform.position.x + 50 && (transform.position.y < 370 || transform.position.y > 650))
                Died();
        }
    }

    void SpawnPipesGround()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].transform.position.x < -100)
            {
                _score += 5;
                // Debug.Log(_score);
                pipes[i].transform.position = spawnPipes.transform.position;
            }
        }

        for (int i = 0; i < grounds.Length; i++)
        {
            if (grounds[i].transform.position.x < -1000f)
                grounds[i].transform.position = spawnGrounds.transform.position;
        }
    }

    void MoveAll()
    {
        foreach (var VARIABLE in pipes)
        {
            VARIABLE.transform.Translate(Vector3.left * speed);
        }
        foreach (var VARIABLE in grounds)
        {
            VARIABLE.transform.Translate(Vector3.left * speed);
        }
    }
    
    void Died()
    {
        Debug.Log("Score: "+_score + "\n" + "Time: "+Mathf.RoundToInt(Time.time) + "s");
        Destroy(this);
        // Debug.Log("Death");
    }
}
