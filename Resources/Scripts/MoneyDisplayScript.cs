using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyDisplayScript : MonoBehaviour {


    public int money_score;

    Text text;


	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        text = GetComponent<Text>();
        money_score = 1000;
    }

    // Update is called once per frame
    void Update () {
        text.text = "Money: $" + money_score;
	}
}
