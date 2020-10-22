using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity
{
    public GameObject mobGo;

    public enum MobType
    {
        Player,
        Enemy
    }

    enum MobState
    {
        Idle,
        Attacking,
        Defending,
        Charging,
        Died
    }

    public MobType mobType;
    private MobState mobState;
    public string mobName;

    // Privadas
    int _health;
    int _attackDamage;
    int _hitDefense;
    bool _attackTurn;
    Color _entityColor;

    public int Health
    {
        get
        {
            return _health;
        }
        private set
        {
            if (value <= 0)
            {
                mobState = MobState.Died;
            }
            _health = value;
        }
    }

    public Entity(string name, int type)
    {
        mobName = name;
        mobType = (MobType)type;
    }

    public void InitializeEntity(int health, int atkDamage, int hitDefense)
    {
        switch(mobType)
        {
            case MobType.Player:
                this.mobType = MobType.Player;
                this._entityColor = Color.green;

                break;
            case MobType.Enemy:
                this.mobType = MobType.Enemy;
                this._entityColor = Color.red;
                break;
        }

        this.Health = health;
        this._attackDamage = atkDamage;
        this._hitDefense = hitDefense;
    }

    public void EnableTurn()
    {
        this._attackTurn = true;
        Debug.Log("Es el turno de " + mobName + ".");
    }

    public void DealerStatus(string name)
    {
        if (name == this.mobName)
        {
            this._attackTurn = false;
            Debug.Log("Ya no es el turno de " + this.mobName + ".");
        } 
        else 
        {
            Debug.Log("Algo malo pasó aquí, el personaje " + name + ", no es el mismo que se requirió");
        }
    }

    public void TargetStatus (int value, string factor)
    {

        switch (factor)
        {
            case "Hited":
                this.Health -= value - this._hitDefense;
                Debug.Log("La entidad " + this.mobName + " ha sido golpeada con un valor de " + value + " y se ha defendido con " + this._hitDefense + " puntos de defensa, su vida actual es " + this.Health + ".");
                break;
            case "Healed":
                this.Health += value;
                Debug.Log("La entidad " + this.mobName + " ha sido curada con un valor de " + value + " su vida actual es " + this.Health + ".");
                break;
            default:
                Debug.Log("MISS");
                break;
        }
    }
}
