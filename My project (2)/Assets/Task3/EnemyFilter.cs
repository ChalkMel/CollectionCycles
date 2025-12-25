using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyFilter : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [Header("HP")]
    [SerializeField] private TMP_InputField hpInputField;
    [SerializeField] private Button hpApplyBtn;
    [Header("Level")]
    [SerializeField] private TMP_InputField levelInputField;
    [SerializeField] private Button levelApplyBtn;
    [Header("All")]
    [SerializeField] private Button showAllBtn;
    [Header("Boss")]
    [SerializeField] private TMP_InputField bossInputField;
    [SerializeField] private Button bossApplyBtn;

    private void Awake()
    {
        hpApplyBtn.onClick.AddListener(ApplyHpFilter);
        levelApplyBtn.onClick.AddListener(ApplyLevelFilter);
        showAllBtn.onClick.AddListener(ShowAll);
        bossApplyBtn.onClick.AddListener(ApplyBoss);
    }

    private void ApplyHpFilter()
    {
        for (int i = 0; i < enemySpawner.Enemies.Count; i++)
        {
            var enemy = enemySpawner.Enemies[i];
            enemy.gameObject.SetActive(enemy.Hp > float.Parse(hpInputField.text));
        }
    }

    private void ApplyLevelFilter()
    {
        for (int i = 0; i < enemySpawner.Enemies.Count; i++)
        {
            var enemy = enemySpawner.Enemies[i];
            enemy.gameObject.SetActive(enemy.Level == int.Parse(levelInputField.text));
        }
    }

    private void ShowAll()
    {
        foreach( var enemy in enemySpawner.Enemies)
             enemy.gameObject.SetActive(true);
    }

    private void ApplyBoss()
    {
        for(int i = 0; i < enemySpawner.Enemies.Count; i++)
        {
            var enemy = enemySpawner.Enemies[i];
            if (enemy.UnitName.Contains(bossInputField.text))
                enemy.SetBoss();
        }
    }
}