using System.Linq;
using UnityEngine;
 
public class GrenadeScript : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float desroytime;

    private SameTimeExplosionCount _sameTimeExplosionCount;
    
    private void Start()
    {
        _sameTimeExplosionCount = GameObject.Find("Canvas").GetComponentInChildren<SameTimeExplosionCount>();
        Invoke("Explode", 1.5f); // グレネードが作られてから1.5秒後に爆発させる
    }
 
    private void Update()
    {
        
    }

    void Explode()
    {
        // 爆発対象のチキンを取得
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(chicken => Vector3.Distance(chicken.transform.position, transform.position) <= range)
            .ToList();

        if (explodedChicken.Count == 0) return; // リストの要素が 0 の場合は何もしない

        _sameTimeExplosionCount.ShowText(explodedChicken.Count);

        foreach (var chicken in explodedChicken) // 配列に入れた一つひとつのオブジェクト
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbodyがあれば、グレネードを中心とした爆発の力を加える
            {
                rb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
                Destroy(chicken, desroytime);
            }
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        var playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
        }
    }
}