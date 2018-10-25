using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceSumScript : MonoBehaviour {


    Text text;
    public int dice_sum;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        text = GetComponent<Text>();
        dice_sum = 0;
    }

    public void RollDice()
    {
        dice_sum = Random.Range(2, 13);
    }

    // Update is called once per frame
    void Update () {
        text.text = "Dice Sum: " + dice_sum;
	}
}
