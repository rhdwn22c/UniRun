﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
       // 게임 오브젝트로부터 사용할 컴포넌트를 가져와 변수에 할당
       playerRigidbody = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {
       if(isDead) {
        // 사망 시 처리 종료
        return;
       }

       // 마우스 왼 버튼을 누르고, 최대 점프 횟수에 도달하지 않았다면
       if(Input.GetMouseButtonDown(0) && jumpCount < 2) {
        // 점프 횟수 증가
        jumpCount++;
        // 점프 직전 속도를 순간 (0, 0)으로 변경
        playerRigidbody.velocity = Vector2.zero;
        // 리지드바디에 위쪽으로 힘주기
        playerRigidbody.AddForce(new Vector2(0, jumpForce));
        // 오디오 재생
        playerAudio.Play();
       }
       else if(Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0) {
        // 마우스 왼 버튼에서 손을 떼고, 속도의 y 값이 0보다 크다면 속도를 절반으로 변경
        playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
       }

       // 애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
       animator.SetBool("Grounded", isGrounded);
   }

   private void Die() {
       // 사망 처리
   }

   private void OnTriggerEnter2D(Collider2D other) {
       // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
   }

   private void OnCollisionEnter2D(Collision2D collision) {
       // 바닥에 닿았음을 감지하는 처리
   }

   private void OnCollisionExit2D(Collision2D collision) {
       // 바닥에서 벗어났음을 감지하는 처리
   }
}