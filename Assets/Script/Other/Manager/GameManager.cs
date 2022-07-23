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

    //copy�� �� �ִ� ��ų�� Max ��
    [SerializeField] private int skillMaxCnt = 10;
    //���� ��ų ����
    [SerializeField] private int currentSkillCnt;

    [System.Serializable]
    public struct SkillInfo
    {
        public Skill skill;
        public int skillCnt;
    }
    //�� ��ų �ε���(����) ������ ���� �ʿ��Ұ� ����.
    //�� ���� ��ų�� copy���� ����� �� PlayerSkillCopy���� ��� ����� �� ������?
    [Header("Player�� copy�� Enemy Skill ����")]
    [SerializeField] private List<SkillInfo> skills;
    private GameObject player;
    private bool isUnbeatable = false;
    private float curScene;
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
            Debug.LogError("��ų ���� Max���� �����ϴ�!!");
        }
        else
        {
            currentSkillCnt = cnt;
        }
        if (debugMod)
        {
            player = GameObject.Find("Player");
            curScene = SceneManager.GetActiveScene().buildIndex;
        }
        IsStopPlayerInput = false;
    }
    private void Update()
    {
        if (debugMod)
        {
            if (SceneManager.GetActiveScene().buildIndex != curScene)
            {
                player = GameObject.Find("Player");
                curScene = SceneManager.GetActiveScene().buildIndex;
            }
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
    /// ��ų�� �� ��ų�� ���� ������ ��Ƴ� skillList �б� ���� ������Ƽ 
    /// </summary>
    public List<SkillInfo> SkillList
    {
        get { return skills; }
        set { skills = value; }
        
    }

    /// <summary>
    /// �ε����� �־� ��ų�� ������Ű�� ���� ���� ������Ƽ 
    /// [�ε��� ����]
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
    /// �ε����� �־� ��ų�� ���ҽ�Ű�� ���� ���� ������Ƽ
    /// [�ε��� ����]
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

    //��ų�� ����ߴ°�
    public bool IsStealUse { get; set; }

    public bool IsStopAttack { get; set; }
    public int StealCopyCurIndex { get; set; }
    public bool IsSkillMaxCountError { get; set; }

    public bool IsStopPlayerInput { get; set; }

}
