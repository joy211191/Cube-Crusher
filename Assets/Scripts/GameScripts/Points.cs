using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public int points;
    public CubeGenerator cubeGenerator;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<Scoring>().UpdateScore(points);
            cubeGenerator.spawnedCubes.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
