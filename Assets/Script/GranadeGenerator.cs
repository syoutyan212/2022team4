using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GranadeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject granadeItem;
    [SerializeField] private List<GranadeSpawnPoint> spawnPoints;

    private const float IntervalSpawnTime = 5.0f;
    private float elapsedTime = 0.0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // TODO あとで所持グレネードがマックスではないときという条件を付け加える
        if (elapsedTime > IntervalSpawnTime)
        {
            elapsedTime = 0.0f;
            var spawnables = spawnPoints.Where(point => !point.IsSpawnItem).ToList();
            if (spawnables.Count == 0) return;
            var choice = spawnables[Random.Range(0, spawnables.Count)];

            choice.IsSpawnItem = true;
            var g = Instantiate(granadeItem, choice.transform);
            g.GetComponent<GranadeItem>().Callback = () => { choice.IsSpawnItem = false; };
        }
    }
}
