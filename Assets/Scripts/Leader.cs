using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

[RequireComponent(typeof(LeaderController))]
public class Leader : Agent
{
    [Header("Perception")]
    public int numPerceivableObjs;
    public int observationRadius;

    private LeaderController lc;

    public override void InitializeAgent()
    {
        lc = GetComponent<LeaderController>();
    }

    public override void CollectObservations()
    {
        AddVectorObs(1);
        // Collider[] overlapObjs = Physics.OverlapSphere(transform.position, observationRadius);

        // overlapObjs = overlapObjs.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToArray();

        // float j = 0;

        // for (int i = 0; i < overlapObjs.Length; i++)
        // {

        //     j++;

        //     if (i < numPerceivableObjs)
        //     {
        //         AddVectorObs(1);

        //         if (overlapObjs[i].gameObject.CompareTag("Enemy"))
        //         {
        //             AddVectorObs(1);
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //         }
        //         else if (overlapObjs[i].gameObject.CompareTag("Platform"))
        //         {
        //             AddVectorObs(0);
        //             AddVectorObs(1);
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //         }
        //         else if (overlapObjs[i].gameObject.CompareTag("BouncyPlatform"))
        //         {
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //             AddVectorObs(1);
        //             AddVectorObs(0);
        //         }
        //         else if (overlapObjs[i].gameObject.CompareTag("SlidingPlatform"))
        //         {
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //             AddVectorObs(0);
        //             AddVectorObs(1);
        //         }

        //         Vector2 positionNorm = (overlapObjs[i].transform.position - transform.position) / observationRadius;

        //         Vector2 distanceNorm = positionNorm;

        //         if (positionNorm.x >= 0)
        //         {
        //             distanceNorm.x = 1 - positionNorm.x;
        //         }
        //         else
        //         {
        //             distanceNorm.x = -1 - positionNorm.x;
        //         }

        //         if (positionNorm.y >= 0)
        //         {
        //             distanceNorm.y = 1 - positionNorm.y;
        //         }
        //         else
        //         {
        //             distanceNorm.y = -1 - positionNorm.y;
        //         }

        //         AddVectorObs(distanceNorm);


        //         // Vector2 relSpeed = (Vector2.zero - rb2d.velocity) / (observationRadius * 2);

        //         // if (overlapObjs[i].transform.position.x - transform.position.x > 0)
        //         // {
        //         //     relSpeed = new Vector2(-relSpeed.x, relSpeed.y);
        //         // }

        //         // if (overlapObjs[i].transform.position.y - transform.position.y > 0)
        //         // {
        //         //     relSpeed = new Vector2(relSpeed.x, -relSpeed.y);
        //         // }

        //         // AddVectorObs(relSpeed);

        //     }
        //     else
        //     {
        //         break;
        //     }
        // }

        // for (int i = 0; i < numPerceivableObjs - j; i++)
        // {
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        //     AddVectorObs(0);
        // }

        //vectorObs = info.vectorObservation;
    }

    public override void AgentAction(float[] vectorAction)
    {
        Vector3 dir = new Vector3(vectorAction[0], 0, vectorAction[1]);
        lc.Move(dir.normalized);
        //Debug.Log("asd");
    }

    public override void AgentReset()
    {
        SetResetParameters();
    }

    public override void AgentOnDone()
    {
    }

    public override float[] Heuristic()
    {
        var action = new float[2];
        action[0] = Input.GetAxisRaw("Horizontal");
        action[1] = Input.GetAxisRaw("Vertical");
        return action;
    }
    public void SetResetParameters()
    {
        // var fp = m_MyAcademy.FloatProperties;
        // m_GoalSize = fp.GetPropertyWithDefault("goal_size", 5);
        // m_GoalSpeed = Random.Range(-1f, 1f) * fp.GetPropertyWithDefault("goal_speed", 1);
        // m_Deviation = fp.GetPropertyWithDefault("deviation", 0);
        // m_DeviationFreq = fp.GetPropertyWithDefault("deviation_freq", 0);
    }
}
