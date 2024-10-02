using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region Variables
        //Rigidbody
        Rigidbody2D rigidbody2D;
        //점프하는 힘
        [SerializeField] float jumpForce = 6f;
        //점프중인지 확인
        private bool keyJump;
        //회전
        [SerializeField] private float rotateSpeed = 5f;
        private Vector3 birdRotation;
        //이동
        [SerializeField] private float moveSpeed = 5f;
        //버드대기
        [SerializeField] private float readyForce = 1f;
        #endregion
        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            keyJump = false;
        }

        void Update()
        {
            //키입력
            InputBird();

            //버드 대기

                ReadyBird();


            //버드 회전
            RotateBird();

            //버드 이동
            MoveBird();
        }

        private void FixedUpdate()
        {
            //점프
            if (keyJump)
            {
                JumpBird();
                keyJump = false;
            }
        }

        //컨트롤 입력
        private void InputBird()
        {
            //점프 : 스페이스바 또는 마우스 왼쪽 클릭
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            if (GameManager.IsStart == false && keyJump)
            {
                GameManager.IsStart = true;
            }
        }

        //버드 점프
        void JumpBird()
        {
            //힘을 이용해서 점프
            //rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        //버드 회전
        void RotateBird()
        {
            //up +30, down -90;
            float degree = 0;
            if (rigidbody2D.velocity.y > 0f)
            {
                degree = rotateSpeed;
            }
            else
            {
                degree = -rotateSpeed;
            }

            float rotationZ = birdRotation.z + degree;
            rotationZ = Mathf.Clamp(rotationZ + degree, -90f, 30f);

            birdRotation = new Vector3(0f, 0f, rotationZ);
            transform.eulerAngles = birdRotation;
        }

        //버드 이동
        void MoveBird()
        {
            if (GameManager.IsStart == false)
            {
                return;
            }
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        private void ReadyBird()
        {
            if (GameManager.IsStart) return;
            
                //위쪽으로 힘을 주어 제자리에 있기
                if (rigidbody2D.velocity.y < 0f)
            {
                rigidbody2D.velocity = Vector2.up * readyForce;
            }
        }
    }
}
