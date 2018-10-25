using System.Collections;

public class Decision {

    private string text;
    private char selection;
    private int moneyAffect;
    private int evAffect;

    public Decision(string text, int money, int ev)
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

    public char getSelection()
    {
        return selection;
    }

    public void setSelection(char selection)
    {
        this.selection = selection;
    }
}
