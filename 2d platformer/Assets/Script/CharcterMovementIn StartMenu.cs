using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        controller.Move(move * speed * Time.deltaTime);
    }
}