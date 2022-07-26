# LawOfTheOcean
## 개요
---
팀명: 수산시장<br>
제목: Law of the ocean<br>
모티브로 한 게임: feed and grow, subnautica, Star Fox 64<br>
게임 스토리: 주인공 Billano는 자신의 동료 Sara와 함께 바닷속 보물을 찾는다. 보물을 발견한 Sara가 Billano에게 연락을 하는 순간 커다란 고래에게 공격을 당하고 고래에게 보물을 빼앗기게 된다. 보물을 되찾기 위해 주인공 Billano가 되어 떠나는 바닷속 슈팅게임
 <br>
승리조건: 보스 씬까지 도달 후 보스와 싸워 승리 시 승리<br>
패배조건: Hp가 0일 때<br>
주요 타겟층: 모든 연령층
<br>
## 게임 구조
---
### 시점
- 1인칭 시점
### GameManager  <b> - 고현서</b>
- 각 뺏어온 스킬의 수를 저장 
### Entity
- EntityHealth.cs
- PlayerHealth.cs
-EnemyHealth.cs
- player🤽
    - PlayerInput.cs <b>- 고현서</b>
    - PlayerMovement.cs <b> - 신정훈</b>
    - PlayerSkill.cs <b>- 고현서</b>
            - 기본공격: 총알 발사
            - 스킬: Enemy Skill 강탈
- Enemy
    - 플레이어가 감지 범위에 도달했을 경우 공격,
    - 감지범위에 벗어났을 경우 갈길 감 (맵의 끝에 DestroyZone 설치)
    - EnemyMovement.cs (level 별)<b> - 신정훈</b>
    - 게🦀 <b> - 신정훈</b>
        - crabSkill.cs
        - 적과 부딪치면 Hp 일정량 회복 스킬
    - 해파리🐙 <b> - 신정훈</b>
        - jellyFishSkill.cs
        - 상대에게 전기를 날려 맞추면 상대 경직 효과 주기
    - 복어🐡 <b>- 고현서</b>
        - blowFishSkill.cs
        - 플레이어가 일정 위치만큼 다가오면 몸을 확 부풀려 가시발사 데미지 준다. 
    - 상어🦈 - 신정훈</b>
        - SharkSkill.cs
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
### Object
- item.cs <b>- 고현서</b>
### Skill Structure
![image](https://user-images.githubusercontent.com/76097749/177246976-2dbe747a-5673-4db8-b7d8-31cc574927ef.png)

## 긴급!! 프로토 타입을 위한 정보 전달 UI 제작
1. Player 체력 UI & 적 체력 UI - Jung
2. 스킬 카피 했는 여부 + 스킬 swap 발동했는지 여부  + 스킬 swap 그거를 위한 스킬 정보 띄워주기 - Ko

---
## <b>피드백</b>
1. 30초 안에 핵심만 보여야함
     - 스킬 카피가 (P 스킬 <--> E 스킬)
     - 영상 넣어야하고 그 영상과 똑같이 구현
2. 카메라 회전도 물에 있는 것처럼
[New!]
4. copySkill 잘 쓸 수 있도록 -> 한번 적용하면 죽일때 무조건 Copy 
5. 난이도 조절
6. 그래픽 (바다느낌나게)
7. 고래 둥둥떠다니는 느낌 
8. 플레이어 헤엄치는 느낌
9. 타격감 -> 고래 물방울 같은 
10. 가야할 경로 표시 -> 각 씬마다 포탈의 위치를 알려줄 맵 UI 제작 
---
## <b>베타 계획</b>
- copySkill 사용시 이펙트 
- Copy한 Skill들 시각화해서 몇개있는지 보여주기 
### <b>스토리</b>
    - 고래가 플레이어가 타고 있는 잠수함을 쳐서 보물을 뺏어갔다.
    - 플레이어는 그 보물을 되찾기 위해 싸운다.
    - 마지막에 플레이어는 "네 보스, 무기를 확보했습니다. 멍청한 고래때문에 계획이 틀어졌어.." 
    - "이제 전 세계는 우리 것이 될거야" 이런 느낌의 대사를 하여 반전 스토리.
### <b>코드 관련</b>
- 청새치 버그 생각  
- 세이브 기능 구현 
- 플레이어 맞을 때, 쏠 때 떨림
- 중간에 게임을 나갈 수 있는 UI 적용 

### <b>컴포넌트 관련</b>
- 에셋 다시 조사 
- 폰트 다시 조사 
- 잠수부 머리 장치 그림 찾기 및 적용 
- 씨네머신 (좀 중요) 
    - start 
    - ending 
- 적 배치 논의 
- 플레이어 총소리, 기타 소리 넣기 
- 터레인 규격 논의 
- 적 스킬 이펙트 넣으려면 넣기 

### <b>테스팅 관련</b>
- 버그 찾기 
### <b>우선순위 설정</b>
+ 보스 스킬 사운드 
1. 보스 움직임 + effect 
2. 바다 그래픽
3. 플레이어 움직임 + 이펙트 
4. 타격감, 맞을 때 움직임 
5. 씨네머신 
6. 맵 지도 
8. 중간에 나갈 수 있는 UI, Player UI
7. 난이도 조절
9. 사운드, 추가 이펙트
10. 버그 테스팅
---
## <b>스크립트</b>
---
### <b>Hyeonseo Ko (고현서)</b>
### Manager
- GameManager.cs (주로 게임 데이터 보관 및 전달)
- UIManager.cs  (UI에 필요한 정보들 전달)
### Entity
- EntityHealth.cs 
   - EnemyHealth.cs (EntityHealth 상속받아 사용)
   - PlayerHealth.cs (EntityHealth 상속받아 사용)
- Enemy
    - EnemyDetection.cs
    - Skill.cs (Scriptable Object, 스킬들이 상속받아서 사용)
    - EnemySkill.cs (위의 Skill들을 상속받은 Scriptable Object들을 랜덤적으로 발동 -> 스킬들을 찾는 방법에는 스킬들이 많아질 것을 대비하여 이분탐색 알고리즘 사용)
    - BlowFish (사방에 가시 총알 발사)
        - BlowFish.cs
        - BlowFishSkill .cs (Skill 상속받아 사용)
    - SwordFish (일정 시간동안 속도 6 증가)
        - SwordFish.cs
        - SwordFishSkill.cs (Skill 상속받아 사용)
        - SwordFishUseSkill.cs
- Player
    - PlayerInput.cs 
    - PlayerShooter.cs
    - PlayerSkillCopy.cs
- Boss
    - BossWaterSkill.cs (특이한 원의 형태로 물방울 발사)
    - BossSprinkler.cs (Sprinkler처럼 물방울 발사)
    - BossFirePos.cs
### Object
- SkillOrb.cs
- StolenSkill.cs (강탈할 스킬 소유자 컴포넌트에 장착)
- ThornBullet.cs (BlowFish 가시 스킬 bullet.)
- WaterBullet (Boss의 bullet)
- Bullet.cs (플레이어의 기본 무기 bullet.)
- DeadZone.cs (맵의 범위지정 및 벗어난 오브젝트 파괴, 플레이어의 경우 1.5초마다 5씩 체력 감소)
- DirectorAction.cs (시네머신 director 관련 script)
- EnemyStopSkill.cs (Enemy가 player에게 silence skill을 맞았을 경우 skill 제어 여부 정보 전달 스크립트.)
- Portal.cs
- Stage3_Event.cs
- NextEnding.cs 
- DontDestroyObject.cs (사용 안됨)
- NameTag.cs  (프리팹의 이름 전달 ex) SwordFish(1) -> SwordFish 전달) (사용 안됨)

### UI
- CrossHair.cs
- StartScript.cs
- UI_Hurt.cs
- UIExplain.cs
- UIMap.cs
- UISetting.cs
- UISkillCopy.cs
- UIPlayerSilence.cs
---
### <b>신정훈<b> 
### Entity
- Player
    - PlayerMove.cs (Player움직임 구현 및 애니메이션 제어)
    - CameraRotate.Cs
- Enemy
    - JellyFish (스킬 적중시 일정시간동안 silence(공격불가))
        - JellyFish.cs
        - JellySkill.cs (스킬 상속받아 사용)
    - Crab
        - Crab.cs (상대방의 체력을 빼앗아 회복)
        - CrabSkill.cs (스킬 상속받아 사용)
- Boss
    - Boss.cs (보스 등장 및 체력감소시 소환되는 Enemy관리)
    - StartTrigger.cs
    - EnemySummon.cs (보스 체력일정 일정량 감소시 Enmey 소환)

### Object
- JellyFishBullet.cs (JellyFish의 silence 스킬 bullet)
- CrabBullet.cs (Crab의 체력뺏기 스킬 bullet)
- JellyFishGOD.cs 
- BlowFishGOD.cs 
- SwordFishGOD.cs
- PlayerBubble.cs
- BossCineMachine.cs (시네머신 Boss 움직임 스크립트)
### UI
- MainMenu.cs
- GameOver.cs
- UIPlayerHP.cs
- UIEnemyHP.cs

