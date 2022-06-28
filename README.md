# LawOfTheOcean
## 개요
---
팀명: 수산시장<br>
제목: Law of the ocean<br>
모티브로 한 게임: feed and grow
게임 스토리: 주인공의 동생이 고래에게 먹혔다. 동생을 구하러 가는 한 스쿠버의 이야기<br>
승리조건: 보스 씬까지 도달 후 보스와 싸워 승리 시 승리<br>
패배조건: Hp가 0일 때<br>
주요 타겟층: 모든 연령층
<br>
## 게임 구조
---
### 시점
- 3인칭 물고기 뒷모습
### GameManager  <b> - 고현서</b>
- PlayerHealth.cs
- 각 뺏어온 스킬의 수를 저장 
### Entity
- Entity class작성
- player🤽
    - PlayerInput.cs <b>- 고현서</b>
    - PlayerMovement.cs <b> - 신정훈</b>
    - PlayerSkill.cs <b>- 고현서</b>
        - 기본 공격: 조개나 성게 던지기
        - 물고기 잡아서 레벨업 시 물고기 스킬 뺏기
        - 많이 먹을 수록 스킬 많이 가능(스킬 최대값 부여)
- Enemy
    - 플레이어가 감지 범위에 도달했을 경우 공격,
    - 감지범위에 벗어났을 경우 갈길 감 (맵의 끝에 DestroyZone 설치)
    - EnemyMovement.cs (level 별)<b> - 신정훈</b>
    - 게🦀 <b> - 신정훈</b>
        - crabSkill.cs(확률적으로 떨어트림)
        - 적과 부딪치면 Hp 일정량 회복 스킬
    - 해파리🐙 <b> - 신정훈</b>
        - jellyFishSkill.cs(확률적으로 떨어트림)
        - 상대에게 전기를 날려 맞추면 상대 경직 효과 주기
    - 복어🐡 <b>- 고현서</b>
        - blowFishSkill.cs(확률적으로 떨어트림)
        - 플레이어가 일정 위치만큼 다가오면 몸을 확 부풀려 데미지 준다. 
    - 상어🦈 - 신정훈</b>
        - SharkSkill.cs(확률적으로 떨어트림)
        - 갑자기 확 다가오는 스킬
    - Boss(고래)🐋 <b> - 신정훈</b> <b>+ 고현서</b>
        - 보스 등장 때 씨네머신 사용
        - BossSkill(scriptable) -> 여러개

### UI
- UIManager.cs <b>- 고현서</b>
- 현재 레벨창 <b> - 신정훈</b>
- 게임 초기창 <b>- 고현서</b>
- 게임 오버 / 게임 스타트 <b> - 신정훈</b>
- 체력(플레이어 & 고래) <b> - 신정훈</b>
- 죽인 물고기 수 <b> - 신정훈</b>
### Object
- item.cs <b>- 고현서</b>
---
## <b>강사님 피드백</b>
1. 30초 안에 핵심만 보여야함
     - 스킬 카피가 (P 스킬 <--> E 스킬)
 
