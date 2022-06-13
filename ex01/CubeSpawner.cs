using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeSpawner : MonoBehaviour
{
    public RectTransform deadLine;
    [SerializeField] private GameObject aCube;
    [SerializeField] private GameObject sCube;
    [SerializeField] private GameObject dCube;
    [SerializeField] private List<RectTransform> _transforms;
    private GameObject[] cubes = new GameObject[3];
    private GameObject _aCube;
    private GameObject _sCube;
    private GameObject _dCube;

    private int _i = 0;

    private void Start()
    {
        cubes[0] = aCube;
        cubes[1] = sCube;
        cubes[2] = dCube;
    }

    private void Update()
    {
        SpawnLogic();

        GameObject obj = null;
        if (!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)) return;
        if (Input.GetKeyDown(KeyCode.A) && _aCube) obj = _aCube;
        if (Input.GetKeyDown(KeyCode.S) && _sCube) obj = _sCube;
        if (Input.GetKeyDown(KeyCode.D) && _dCube) obj = _dCube;
        if (!obj) return;
        var res = obj.transform.position.y - 30f;
        if (res < 0) res *= -1;
        Debug.Log("Precision: " + res);
        if (obj) Destroy(obj);
    }

    private void SpawnLogic()
    {
        if (Random.Range(-50, 100) != 33) return;
        var i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                if (!_aCube) _aCube = Instantiate(cubes[i], _transforms[i].transform);
                break;
            case 1:
                if (!_sCube) _sCube = Instantiate(cubes[i], _transforms[i].transform);
                break;
            case 2:
                if (!_dCube) _dCube = Instantiate(cubes[i], _transforms[i].transform);
                break;
        }
    }
}
