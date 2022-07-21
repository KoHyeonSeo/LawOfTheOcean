using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager getGameManager()
    {
        return instance;
    }
    
    public bool debugMod = false;

    //copy할 수 있는 스킬의 Max 값
    [SerializeField] private int skillMaxCnt = 10;
    //현재 스킬 갯수
    [SerializeField] private int currentSkillCnt;

    [System.Serializable]
    public struct SkillInfo
    {
        public Skill skill;
        public int skillCnt;
    }
    //적 스킬 인덱스(갯수) 저장할 공간 필요할거 같다.
    //각 적의 스킬을 copy에서 사용할 시 PlayerSkillCopy에서 어떻게 사용할 수 있을까?
    [Header("Player가 copy한 Enemy Skill 갯수")]
    [SerializeField] private List<SkillInfo> skills;
    private GameObject player;
    private bool isUnbeatable = false;
    
    private void Awake() {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        IsStealUse = false;
        IsSkillMaxCountError = false;
        int cnt = 0;
        foreach(var skill in skills)
        {
            cnt += skill.skillCnt;
        }
        if(cnt > skillMaxCnt)
        {
            Debug.LogError("스킬 수가 Max보다 많습니다!!");
        }
        else
        {
            currentSkillCnt = cnt;
        }
        if (debugMod)
        {
            player = GameObject.Find("Player");
        }
    }
    private void Update()
    {
        if (debugMod)
        {
            if (Input.GetKey(KeyCode.G))
            {
                if (Input.GetKey(KeyCode.Alpha0))
                {
                    SceneManager.LoadScene(0);
                }
                else if (Input.GetKey(KeyCode.Alpha1))
                {
                    SceneManager.LoadScene(1);
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    SceneManager.LoadScene(2);
                }
                else if (Input.GetKey(KeyCode.Alpha3))
                {
                    SceneManager.LoadScene(3);
                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    SceneManager.LoadScene(4);
                }
                else if (Input.GetKey(KeyCode.Alpha5))
                {
                    SceneManager.LoadScene(5);
                }
                else if (Input.GetKey(KeyCode.Alpha6))
                {
                    SceneManager.LoadScene(6);
                }
                else if (Input.GetKeyDown(KeyCode.KeypadPlus)&&player)
                {
                    player.GetComponent<PlayerMove>().Speed += 10;
                }
                else if (Input.GetKeyDown(KeyCode.KeypadMinus)&&player)
                {
                    player.GetComponent<PlayerMove>().Speed
                        = player.GetComponent<PlayerMove>().Speed - 10 > 0 ?
                        player.GetComponent<PlayerMove>().Speed - 10 : player.GetComponent<PlayerMove>().Speed;
                }
                else if (Input.GetKeyDown(KeyCode.KeypadEnter) && player)
                {
                    if (!isUnbeatable)
                    {
                        isUnbeatable = true;
                        player.GetComponent<PlayerHealth>().IsUnbeatable = true;
                    }
                    else
                    {
                        player.GetComponent<PlayerHealth>().IsUnbeatable = false;
                        isUnbeatable = false;
                    }
                }
            }
            
        }
    }
    /// <summary>
    /// 스킬과 각 스킬의 갯수 정보를 담아낼 skillList 읽기 쓰기 프로퍼티 
    /// </summary>
    public List<SkillInfo> SkillList
    {
        get { return skills; }
        set { skills = value; }
        
    }

    /// <summary>
    /// 인덱스를 넣어 스킬을 증가시키는 쓰기 전용 프로퍼티 
    /// [인덱스 정보]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetIncreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            if(currentSkillCnt + 1 <= skillMaxCnt)
            {
                skill.skillCnt++;
                skills[value] = skill;
                currentSkillCnt++;
                IsSkillMaxCountError = false;
            }
            else
            {
                IsSkillMaxCountError = true;
            }
        }
    }

    /// <summary>
    /// 인덱스를 넣어 스킬을 감소시키는 쓰기 전용 프로퍼티
    /// [인덱스 정보]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetDecreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            if (currentSkillCnt - 1 >= 0)
            {
                skill.skillCnt--;
                skills[value] = skill;
                currentSkillCnt--;
            }
        }
    }

    //스킬을 사용했는가
    public bool IsStealUse { get; set; }

    public bool IsStopAttack { get; set; }
    public int StealCopyCurIndex { get; set; }
    public bool IsSkillMaxCountError { get; set; }

}
