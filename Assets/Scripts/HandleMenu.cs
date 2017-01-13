using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;

public class HandleMenu : MonoBehaviour {
    public GameObject goButton;
    public Text introText;
    public SelectionSlider greenButton;
    public SelectionSlider orangeButton;
    public SelectionSlider redButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        introText.text = goButton.GetComponent<ShowMenu>().infos;
        greenButton.OnBarFilled += GreenButton_OnBarFilled;
        orangeButton.OnBarFilled += OrangeButton_OnBarFilled;
        redButton.OnBarFilled += RedButton_OnBarFilled;
    }

    private void RedButton_OnBarFilled()
    {
        //改变颜色值
        goButton.GetComponent<ColorSync>().ChangeColor(Color.red);
        //goButton.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        gameObject.SetActive(false);
    }

    private void OrangeButton_OnBarFilled()
    {
        goButton.GetComponent<ColorSync>().ChangeColor(Color.yellow);
        //goButton.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        gameObject.SetActive(false);
    }

    private void GreenButton_OnBarFilled()
    {
        goButton.GetComponent<ColorSync>().ChangeColor(Color.green);
        //goButton.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        introText.text = "";
        greenButton.OnBarFilled -= GreenButton_OnBarFilled;
        orangeButton.OnBarFilled -= OrangeButton_OnBarFilled;
        redButton.OnBarFilled -= RedButton_OnBarFilled;
    }

}
