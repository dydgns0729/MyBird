using System.Collections;
using UnityEngine;
namespace MyBird
{
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        public GameObject pipe;
        private float countdown;
        [SerializeField] float spawnTimer = 1f;
        [SerializeField] float maxSpawnTimer = 1.05f;
        [SerializeField] float minSpawnTimer = 0.95f;

        private Vector3 spawnPosition;
        [SerializeField] float maxY = 3.8f;
        [SerializeField] float minY = -1.8f;
        #endregion
        void Start()
        {
            countdown = spawnTimer;

        }
        void Update()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath) return;

            if (countdown <= 0f)
            {
                SpawnPipe();
                countdown = Random.Range(minSpawnTimer, maxSpawnTimer);
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