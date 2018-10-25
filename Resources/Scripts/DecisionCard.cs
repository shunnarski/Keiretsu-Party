
using System.Collections;
using System.Collections.Generic;

public class DecisionCard {

    private List<Decision> decisions = new List<Decision>();
    private string text;

    public DecisionCard(string text, List<Decision> decisions)
    {
        this.text = text;
        for(int i = 0; i < decisions.Count; i++)
        {
            Decision decision = decisions[i];
            char selection = i == 0 ? 'A' : 'B';
            this.decisions.Add(decision);
        }

    }

    public string getText()
    {
        return text;
    }

    public List<Decision> getDecisions()
    {
        return decisions;
    }
}
