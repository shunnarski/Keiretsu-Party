using System.Collections;

public class EventCard {

    private string text;
    private int moneyAffect;
    private int evAffect;

    public EventCard(string text, int money, int ev)
    {
        this.text = text;
        this.moneyAffect = money;
        this.evAffect = ev;
    }



    public string getText()
    {
        return text;
    }

    public int getMoneyAffect()
    {
        return moneyAffect;
    }

    public int getEVEffect()
    {
        return evAffect;
    }
}
