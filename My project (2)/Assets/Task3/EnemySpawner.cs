using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int count;     
    [SerializeField] private Vector2 border;

    public List<Enemy> Enemies { get; private set; }
    void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        Enemies = new List<Enemy>();
        for (int i = 0; i < count; i++)
        {
            float posX = Random.Range(-border.x, border.x);
            float posY = Random.Range(-border.y, border.y);
            var enemy = Instantiate(enemyPrefab,
                new Vector3(posX, posY, 0),
                Quaternion.identity);
            enemy.Init($"Unit {i + 1}",
                Random.Range(0f, 10f),
                Random.Range(1, 4));
            Enemies.Add(enemy);
        }
    }
}