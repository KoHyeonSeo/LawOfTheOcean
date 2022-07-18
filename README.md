# LawOfTheOcean
### ⛔<b>깃허브 push, pull, merge 주의점</b>
- <b>먼저 작업 전 pull하기!!</b> 
- <b>merge할 때는 유니티 끄고 merge진행!!!</b>
- <b>서로의 스크립트 수정 금지</b>
- <b>create pull request 필수!!</b> 
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
### Skill Structure
![image](https://user-images.githubusercontent.com/76097749/177246976-2dbe747a-5673-4db8-b7d8-31cc574927ef.png)

## 긴급!! 프로토 타입 정보 전달 UI 제작
1. Player 체력 UI & 적 체력 UI - Jung
2. 스킬 카피 했는 여부 + 스킬 swap 발동했는지 여부  + 스킬 swap 그거를 위한 스킬 정보 띄워주기 - Ko

---
## <b>강사님 피드백</b>
1. 30초 안에 핵심만 보여야함
     - 스킬 카피가 (P 스킬 <--> E 스킬)
     - 영상 넣어야하고 그 영상과 똑같이 구현
2. 카메라 회전도 물에 있는 것처럼
3. 플레이어 기본 공격에 대한 피드백 주시려다 말았음
---
New! 
4. copySkill 잘 쓸 수 있도록 -> 한번 적용하면 죽일때 무조건 Copy
5. 난이도 조절
---
## <b>베타 계획</b>
- copySkill 사용시 이펙트 ㄱ
- Copy한 Skill들 시각화해서 몇개있는지 보여주기
### <b>스토리</b>
    - 고래가 플레이어가 타고 있는 잠수함을 쳐서 보물을 뺏어갔다.
    - 플레이어는 그 보물을 되찾기 위해 싸운다.
    - 마지막에 플레이어는 "네 보스, 무기를 확보했습니다. 멍청한 고래때문에 계획이 틀어졌어.." 
    - "이제 전 세계는 우리 것이 될거야" 이런 느낌의 대사를 친다.
### <b>코드 관련</b>
- 청새치 버그 생각  -> K
- 세이브 기능 구현 -> K
- 플레이어 맞을 때, 쏠 때 떨림 -> S
- 중간에 게임을 나갈 수 있는 UI 적용 -> S

### <b>컴포넌트 관련</b>
- 에셋 다시 조사 -> K/S
- 폰트 다시 조사 -> K/S
- 잠수부 머리 장치 그림 찾기 및 적용 -> K/S
- 씨네머신 (좀 중요) 
    - start -> S
    - ending -> K 
- 적 배치 논의 -> K/S
- 플레이어 총소리, 기타 소리 넣기 -> K/S
- 터레인 규격 논의 -> K/S
- 적 스킬 이펙트 넣으려면 넣기 -> K/S

### <b>테스팅 관련</b>
- 버그 찾기 -> K/S
