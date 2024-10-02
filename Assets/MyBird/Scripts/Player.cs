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
        //�����ϴ� ��
        [SerializeField] float jumpForce = 6f;
        //���������� Ȯ��
        private bool keyJump;
        //ȸ��
        [SerializeField] private float rotateSpeed = 5f;
        private Vector3 birdRotation;
        //�̵�
        [SerializeField] private float moveSpeed = 5f;
        //������
        [SerializeField] private float readyForce = 1f;
        #endregion
        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            keyJump = false;
        }

        void Update()
        {
            //Ű�Է�
            InputBird();

            //���� ���

                ReadyBird();


            //���� ȸ��
            RotateBird();

            //���� �̵�
            MoveBird();
        }

        private void FixedUpdate()
        {
            //����
            if (keyJump)
            {
                JumpBird();
                keyJump = false;
            }
        }

        //��Ʈ�� �Է�
        private void InputBird()
        {
            //���� : �����̽��� �Ǵ� ���콺 ���� Ŭ��
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            if (GameManager.IsStart == false && keyJump)
            {
                GameManager.IsStart = true;
            }
        }

        //���� ����
        void JumpBird()
        {
            //���� �̿��ؼ� ����
            //rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        //���� ȸ��
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

        //���� �̵�
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
            
                //�������� ���� �־� ���ڸ��� �ֱ�
                if (rigidbody2D.velocity.y < 0f)
            {
                rigidbody2D.velocity = Vector2.up * readyForce;
            }
        }
    }
}
