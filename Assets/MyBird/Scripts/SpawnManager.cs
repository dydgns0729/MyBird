using System.Collections;
using UnityEngine;
namespace MyBird
{
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        //스폰 프리팹
        public GameObject pipe;

        //스폰 타이머
        private float countdown;
        [SerializeField] float spawnTimer = 1f;
        
        [SerializeField] float maxSpawnTimer = 1.05f;
        [SerializeField] float minSpawnTimer = 0.95f;
        public static float levelTimer;

        private Vector3 spawnPosition;
        [SerializeField] float maxY = 3.8f;
        [SerializeField] float minY = -1.8f;
        #endregion
        void Start()
        {
            countdown = spawnTimer;
            levelTimer = 0f;

        }
        void Update()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath) return;

            if (countdown <= 0f)
            {
                SpawnPipe();
                countdown = Random.Range(minSpawnTimer - levelTimer, maxSpawnTimer); // 1.05f ~ 0.95f => 1.05f ~ 0.90f
            }
            countdown -= Time.deltaTime;

        }

        void SpawnPipe()
        {
            // 파이프의 월드 위치를 설정
            spawnPosition = transform.position + new Vector3(0f, Random.Range(minY, maxY), 10f);
            Instantiate(pipe, spawnPosition, Quaternion.identity);

        }
    }
}