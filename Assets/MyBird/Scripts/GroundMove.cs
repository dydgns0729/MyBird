using UnityEngine;

namespace MyBird
{
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        [SerializeField] float moveSpeed = 5f;
        #endregion
        void Start()
        {

        }

        void Update()
        {
            if (GameManager.IsDeath) return;
            MoveGround();
        }

        void MoveGround()
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 8.4f, transform.localPosition.y, transform.localPosition.z);
            }
        }

    }
}