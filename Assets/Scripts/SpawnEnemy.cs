using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] float MinPosX, MaxPosX, MinPosZ, MaxPosZ;
    public static float _MinPosX, _MaxPosX, _MinPosZ, _MaxPosZ;
    [SerializeField] GameObject[] PrefabBot;
    [SerializeField] TextMeshProUGUI _score, _hp;
    private Vector3 SpawnPos;
    private float counter;
    private void Awake()
    {
        _MinPosX = MinPosX;
        _MaxPosX = MaxPosX;
        _MinPosZ = MinPosZ;
        _MaxPosZ = MaxPosZ;
        Enemy.scoreEnemy = 0;
        Enemy.levelEnemy = 0;
        Enemy.hpStatic = 1;
        Enemy.speedStatic = .1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!Menu._MENU)
        {
            Spawn(3);
        }
            _score.text = "Monster: " + Enemy.scoreEnemy.ToString() + "/10";
            _hp.text = "HP: " + Enemy.hpStatic.ToString();
    }
    private void Spawn(float interval)
    {
        if (Enemy.scoreEnemy < 10)
        {
            counter += Time.deltaTime;
            if (counter > interval && !Boost.freezing)
            {
                SpawnPos = new Vector3(Random.Range(MinPosX, MaxPosX), 0, Random.Range(MinPosZ, MaxPosZ));
                Instantiate(PrefabBot[Random.Range(0, PrefabBot.Length)], SpawnPos, Quaternion.identity);
                if (Enemy.levelEnemy == 10)
                {
                    if (interval > .6f)
                    {
                        interval -= .5f;
                    }
                }
                counter = 0;
            }
        }
    }
}
