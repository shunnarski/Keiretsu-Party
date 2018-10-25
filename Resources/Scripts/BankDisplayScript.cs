using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BankDisplayScript : MonoBehaviour {

    Text text;
    public int bank_val;

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
        text = GetComponent<Text>();
        bank_val = 0;
    }

    // Update is called once per frame
    void Update () {
        text.text = "Bank: $" + bank_val;
	}
}
