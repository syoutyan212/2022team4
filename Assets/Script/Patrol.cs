using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class Patrol : MonoBehaviour {

    public Transform[] central;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;

    Vector3 baitPos;
    GameObject bait;
    float distance;
    [SerializeField] float trackingRange= 3f;
    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        bait = GameObject.FindWithTag("Bait");
    }


    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (central.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = central[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % central.Length;
    }


    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        
        if (tracking)
        {
            bait = GameObject.FindWithTag("Bait");
            
            if (bait == null)
            {
                tracking = false;
                return;
            }
            
            baitPos = bait.transform.position;
            distance = Vector3.Distance(this.transform.position, baitPos);
            
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
                tracking = false;
            
            //Playerを目標とする
            agent.destination = baitPos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
                tracking = true;


            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}