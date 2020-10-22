using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Entity> entitiesOnGame = new List<Entity>();
    public GameObject entitiesPrefab;

    public string entityTurn;

    void Start()
    {
        entitiesOnGame.Add(new Entity("Pi", 0));
        entitiesOnGame.Add(new Entity("Saturn", 1));
        entitiesOnGame.Add(new Entity("Pluto", 1));
        entitiesOnGame.Add(new Entity("Mars", 1));

        entityTurn = RandomTurn();
        PutStats();
    }

    void PutStats()
    {
        foreach (var item in entitiesOnGame)
        {
            item.InitializeEntity(20, 5, 10);
        }
    }

    public string RandomTurn()
    {
        int result;
        result = Random.Range(0, entitiesOnGame.Count);
        entitiesOnGame[result].EnableTurn();
        return entitiesOnGame[result].mobName;
    }

    public void Fighting(string dealer, int target, int value, string condition)
    {
        
        foreach (var item in entitiesOnGame)
        {
            if(item.mobName == dealer)
            {
                item.DealerStatus(dealer);
                entitiesOnGame[target].TargetStatus(value, condition);
            }
        }
    }

}
