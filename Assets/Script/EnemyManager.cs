using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemyBox;
 
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Cube");
 
        print("敵の数：" + enemyBox.Length);
 
        if(enemyBox.Length == 0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}