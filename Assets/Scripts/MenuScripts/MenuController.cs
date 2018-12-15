using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    public Slider slider;
    public Text sliderText;


    [Header("Panels")]
    public GameObject playPanel;

    private void Start() {
        slider.value = PlayerPrefs.GetInt("Types");
        sliderText.text = slider.value.ToString();
    }

    public void Play() {
        playPanel.SetActive(true);
    }
    public void Credits() {

    }
    public void Exit() {

    }
    public void CubeSet() {
        PlayerPrefs.SetInt("Types", (int)slider.value);
        sliderText.text = slider.value.ToString();
    }

    public void Back() {
        playPanel.SetActive(false);
    }

    public void LevelLoad() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
