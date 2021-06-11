using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    public static float  speedStatic = .1f, hpStatic = 1;
    private Vector3 TargetPos;
    private Animator _animator;
    private BoxCollider _boxcollider;
    public static sbyte scoreEnemy, levelEnemy;
    private float counter, health, speed;
    private bool dead;

    private void Start()
    {
        _boxcollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        TargetRandom();
        scoreEnemy++;
        levelEnemy++;
        if (levelEnemy >= 10)
        {
            speedStatic += .01f;
            hpStatic++;
            levelEnemy = 0;
        }
        speed = speedStatic;
        health = hpStatic;
        Debug.Log(hpStatic);
    }
    private void Update()
    {
        if (!Menu._MENU)
        {
            if (scoreEnemy < 10)
            {
                if (!dead)
                {
                    if (transform.position != TargetPos)
                    {
                        transform.LookAt(TargetPos);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed);
                    }
                    else
                    {
                        TargetRandom();
                    }
                    if (Boost.distruction)
                    {
                        _animator.SetInteger("Walking", 1);
                        speed = 0;
                        counter += Time.deltaTime;
                        if (counter >= 1.5f)
                        {
                            scoreEnemy--;
                            Destroy(gameObject);
                        }
                    }
                }
                else
                {
                    counter += Time.deltaTime;
                    if (counter >= 1.5f)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                _animator.SetInteger("Walking", 2);
            }
        }
    }

    void TargetRandom() { TargetPos = new Vector3(Random.Range(SpawnEnemy._MinPosX, SpawnEnemy._MaxPosX), 0, Random.Range(SpawnEnemy._MinPosZ, SpawnEnemy._MaxPosZ)); }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Menu._MENU)
        {
            health--;
            if (scoreEnemy < 10 && health <= 0)
            {
                scoreEnemy--;
                _boxcollider.enabled = false;
                _animator.SetInteger("Walking", 1);
                dead = true;
                Debug.Log("Dead");
            }
        }
    }
}
