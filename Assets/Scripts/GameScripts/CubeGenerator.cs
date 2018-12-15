using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public List<GameObject> cubePrefabs = new List<GameObject>();
    public List<GameObject> spawnedCubes = new List<GameObject>();
    public bool empty;
    public bool checkNow=false;
    public Scoring scoring;

    int cubeTypes;
    int totalCubes;

    int counter;

    private void Awake() {
        scoring = FindObjectOfType<Scoring>();
    }

    private void Start() {
        cubeTypes = PlayerPrefs.GetInt("Types");
        totalCubes = cubeTypes * 5;//PlayerPrefs.GetInt("Cubes");
        scoring.timer =15 * cubeTypes;
        for(int i = 0; i < totalCubes; i++) {
            Vector3 position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
            GameObject go= Instantiate(cubePrefabs[Random.Range(0, cubeTypes)], position, Quaternion.identity);
            go.GetComponent<Points>().cubeGenerator = this;
            spawnedCubes.Add(go);
            counter++;
        }
        checkNow = true;
    }

    private void LateUpdate() {
        if (checkNow&&spawnedCubes.Count == 0)
            empty = true;
    }

    public void Restart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Quit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
