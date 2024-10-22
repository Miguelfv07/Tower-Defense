using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
public static LevelManager instance;
    public Transform[] path;
    public Transform startPoint;

    public int currency;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("N�o tem dinheiro");
            return false;
        {

            }
        }
    }
}
