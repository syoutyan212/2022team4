using UnityEngine;
using UnityEngine.AI;

// NavMeshAgentコンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    [Tooltip("巡回する地点の配列")]
    public Transform[] waypoints;

    // NavMeshAgentコンポーネントを入れる変数
    private NavMeshAgent navMeshAgent;
    // 現在の目的地
    private int currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // navMeshAgent変数にNavMeshAgentコンポーネントを入れる
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;
        
        // 目的地点までの距離(remainingDistance)が目的地の手前までの距離(stoppingDistance)以下になったら
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // 目的地の番号を１更新（右辺を剰余演算子にすることで目的地をループさせれる）
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            // 目的地を次の場所に設定
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    public void SetinitialDestination()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }
}