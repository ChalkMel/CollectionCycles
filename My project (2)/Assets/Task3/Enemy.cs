using System;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText; 
    [SerializeField] private TextMeshProUGUI levelText;

    public string UnitName {  get; private set; }
    public float Hp {  get; private set; }

    public int Level {  get; private set; }

    public void Init(string name, float hp, int level)
    {
        UnitName = name;
        Hp = hp;
        Level = level;

        DrawStats();
    }

    private void DrawStats()
    {
        nameText.text = UnitName;
        hpText.text = $"HP: {MathF.Round(Hp, 2)}";
        levelText.text = $"Level: {Level}";
    }

    public void SetBoss()
    {
        UnitName = "Boss";
        Level++;
        Hp *= 3;

        DrawStats();
    }
}