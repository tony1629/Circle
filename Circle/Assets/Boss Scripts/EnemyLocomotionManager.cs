using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AL
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        public LayerMask detectionLayer;
        public CharacterStats currentTarget;
        EnemyAnimatorManager enemyAnimatorManager;
        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
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
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (enemyManager.isPerformingAction)
            {

            }
        }
    }

}

