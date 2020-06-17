using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatSystem: MonoBehaviour
{
    [Header("Health points")]
    [SerializeField] private int currentHealthPoints;
    [SerializeField] private int maxHealthPoints;
    [SerializeField] private int minHealthPoints;

    [Header("Energy points")]
    [SerializeField] private int currentEnergyPoints;
    [SerializeField] private int maxEnergyPoints;
    [SerializeField] private int minEnergyPoints;

    private int currentExp;
}
