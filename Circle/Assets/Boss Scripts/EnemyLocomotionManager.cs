using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EL
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        public LayerMask detectionLayer;
        public CharacterStats currentTarget;
        EnemyAnimatorManager enemyAnimatorManager;
        NavMeshAgent navMeshAgent;

        public float distanceFromTarget;
        public float stoppingDistance = 0.5f ;
        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }
        public void HandleDetection()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);
            for(int i =0; i<colliders.Length; i++)
            {
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                if(characterStats != null)
                {
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                    {
                        currentTarget = characterStats;
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (enemyManager.isPerformingAction)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                navMeshAgent.enabled = false;
            }
            else
            {
                if(distanceFromTarget > stoppingDistance)
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                }
            }
            navMeshAgent.transform.localPosition = Vector3.zero;
            navMeshAgent.transform.localRotation = Quaternion.identity;
        }
    }

}

