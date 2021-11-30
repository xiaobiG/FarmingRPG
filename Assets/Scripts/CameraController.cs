using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 offset = new Vector3(0, 6, -6);
    private float Smooth = 2f;

    void Start()
    {
        // 查找带有 PlayerController 脚本的 GameObject
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Smooth * Time.deltaTime);
    }
}