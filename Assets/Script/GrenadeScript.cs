using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GrenadeScript : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float desroytime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 1.5f); // グレネードが作られてから1.5秒後に爆発させる
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
 
    void Explode()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //「Cube」タグのついたオブジェクトを全て検索して配列にいれる
        
        if (enemys.Length == 0) return; // 「Cube」タグがついたオブジェクトがなければ何もしない。
 
        foreach (GameObject cube in enemys) // 配列に入れた一つひとつのオブジェクト
        {
            if (Vector3.Distance(cube.transform.position,transform.position)<=range)
            {
                if (cube.GetComponent<Rigidbody>()) // Rigidbodyがあれば、グレネードを中心とした爆発の力を加える
                {
                    cube.GetComponent<Rigidbody>().AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
                    Destroy(cube, desroytime);
                }
            }
        }
        
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); 
        
        if (players.Length == 0) return;
 
        foreach (GameObject Player in players)
        {
            if (Player.GetComponent<Rigidbody>())
            {
                Player.GetComponent<Rigidbody>().AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
            }
        }
    }
}