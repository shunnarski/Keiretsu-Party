using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RollDiceButton : MonoBehaviour {


    Dice[] dice;
    BankDisplayScript bank;
    EVDisplayScript EV;
    MoneyDisplayScript money;
    EventMessageDisplay eventMessage;

    List<EventCard> eventCards = new List<EventCard>();
    List<DecisionCard> decisionCards = new List<DecisionCard>();


    public int diceSum;

    bool rollDiceWait = false;
    bool getSumWait = false;
	// Use this for initialization
	void Start () {
        dice = (Dice[])FindObjectsOfType(typeof(Dice));
        bank = (BankDisplayScript)FindObjectOfType(typeof(BankDisplayScript));
        EV = (EVDisplayScript)FindObjectOfType(typeof(EVDisplayScript));
        money = (MoneyDisplayScript)FindObjectOfType(typeof(MoneyDisplayScript));
        eventMessage = (EventMessageDisplay)FindObjectOfType(typeof(EventMessageDisplay));

        // instantiate event and decision cards to use
        EventCard eventCard = new EventCard("You internalize employee housing, providing on-site housing for all employees", -400, 40);
        EventCard eventCard2 = new EventCard("Country is angered by recent big-business hostile takeover!", 0, -20);
        eventCards.Add(eventCard);
        eventCards.Add(eventCard2);

        Decision decision = new Decision("Outsource", 900, -20);
        Decision decision2 = new Decision("Stay domestic", -200, 30);
        List<Decision> decisions = new List<Decision>();
        decisions.Add(decision);
        decisions.Add(decision2);
        DecisionCard decisionCard = new DecisionCard("Your company has the option to outsource production to a cheaper country for cheap labor.", decisions);
        decisionCards.Add(decisionCard);
        

       
    }

    public void ExecuteTurn()
    {
        StartCoroutine(RollDice());
        StartCoroutine(setDiceSum());
        StartCoroutine(getEventFromRoll());
    }

    private IEnumerator RollDice()
    {
        rollDiceWait = true;
        for(int i = 0; i < dice.Length; i++)
        {
            Dice die = dice[i];
            die.Roll();
        }
        float waitTime = 0.05f * 30;

        yield return new WaitForSeconds(waitTime);
        rollDiceWait = false;
        getSumWait = true;


    }

    private IEnumerator setDiceSum()
    {
        while (rollDiceWait) {
            yield return new WaitForSeconds(0.1f);
        }
        diceSum = 0;
        for (int i = 0; i < dice.Length; i++)
        {
            Dice die = dice[i];
            diceSum += die.finalSide;
        }
        getSumWait = false;
    }

    private IEnumerator getEventFromRoll()
    {
        while(getSumWait || rollDiceWait)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("Dice Sum At Event: " + diceSum);


        // get money from bank
        if(diceSum == 2)
        {
            // get money from bank
            eventMessage.message = "Get all money in the bank!";
            money.money_score += bank.bank_val;
            bank.bank_val = 0;
        }
        // buyout
        else if(diceSum == 12)
        {
            eventMessage.message = "Buyout another player's company! (Feature coming soon!)";
            
        }
        // event
        else if(diceSum >= 6 && diceSum <= 8)
        {
            int index = Random.Range(0, 2);
            EventCard evCard = eventCards[index];
            eventMessage.message = evCard.getText();
            int money_affected = evCard.getMoneyAffect();

            money.money_score += money_affected;
            bank.bank_val += money_affected > 0 ? money_affected : 0;
            EV.ev_score += evCard.getEVEffect();
            
        }
        // decision
        else
        {
            DecisionCard decCard = decisionCards[0];
            Decision decision = decCard.getDecisions()[0];
            Decision decision2 = decCard.getDecisions()[1];
            eventMessage.message = decCard.getText() + "\n" + decision.getText() + "\n" + decision2.getText() + "\n" + "No selection abilities yet!";

            int money_affected = decision.getMoneyAffect();

            money.money_score += money_affected;
            bank.bank_val += money_affected < 0 ? money_affected : 0;
            EV.ev_score += decision.getEVEffect();

        }
    }



    // Update is called once per frame
    void Update () {
	}
}
