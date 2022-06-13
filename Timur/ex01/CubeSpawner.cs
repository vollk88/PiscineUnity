using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubeA;
    [SerializeField] private GameObject _cubeS;
    [SerializeField] private GameObject _cubeD;
    [SerializeField] private GameObject _cubes;

    [SerializeField] private GameObject[] _placesSpawn;
    // [SerializeField] private GameObject _sPlaceSpawn;
    // [SerializeField] private GameObject _dPlaceSpawn;

    private GameObject _aCubes;
    private GameObject _sCubes;
    private GameObject _dCubes;

    [SerializeField] private float _timeSpawn = 3f;
    private float _time;

    [SerializeField] private GameObject _panel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _time)
        {
            _time+= _timeSpawn;
            SpawnCubes();
        }

        if (Input.GetKeyDown(KeyCode.A) && _aCubes)
        {
            _panel.transform.localScale = Vector3.one *6;
            float rez = _panel.transform.position.y - _aCubes.transform.position.y;
            if (rez < 0)
                rez = -rez;
            Debug.Log("Precision: " + rez);
            Destroy(_aCubes);
        }
        if (Input.GetKeyDown(KeyCode.S)&& _sCubes)
        {
            _panel.transform.localScale = Vector3.one *6;
            float rez = _panel.transform.position.y - _sCubes.transform.position.y;
            if (rez < 0)
                rez = -rez;
            Debug.Log("Precision: " + rez);
            Destroy(_sCubes);
        }
        if (Input.GetKeyDown(KeyCode.D)&& _dCubes)
        {
            _panel.transform.localScale = Vector3.one *6;
            float rez = _panel.transform.position.y - _dCubes.transform.position.y;
            if (rez < 0)
                rez = -rez;
            Debug.Log("Precision: " + rez);
            Destroy(_dCubes);
        }
        if(_panel.transform.localScale.x > 4.63f)
            _panel.transform.localScale -= Vector3.one * 0.01f;
    }

    void SpawnCubes()
    {
        int i = Random.Range(1, 4);
        // Debug.Log(i);
        if (i == 1 && _aCubes)
            i++;
        if (i == 2 && _sCubes)
            i++;
        if (i == 3 && _dCubes)
            i--;
        if (i == 2 && _sCubes)
            i--;
        switch (i)
        {
            case 1:
                if(_aCubes)
                    return;
                _aCubes = Instantiate(_cubeA, _placesSpawn[0].transform.position, _cubeA.transform.rotation, _cubes.transform);
                break;
            case 2:
                if(_dCubes)
                    return;
                _sCubes = Instantiate(_cubeS, _placesSpawn[1].transform.position, _cubeS.transform.rotation, _cubes.transform);
                break;
            case 3:
                if(_dCubes)
                    return;
                _dCubes = Instantiate(_cubeD, _placesSpawn[2].transform.position, _cubeD.transform.rotation, _cubes.transform);
                break;
        }
    }
}
