using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : GameUnit
{
    public GameObject Target;

    public AttackRangeScript ParentAttackRing;
    public ParticleSystem particle;
    private Vector3 targetPosition;
    private void Start()
    {
        OnInit();
        
    }
    private void Update()
    {
        Vector3 targetPosition2 = new Vector3(targetPosition.x, targetPosition.y + 1f, targetPosition.z);

        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition2, 10 * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition2) > 0.1f) return;
        ParentAttackRing.TargetSet = false;
        this.gameObject.SetActive(false);
    }

    public override void OnDespawn()
    {
       
    }

    public override void OnInit()
    {
        
        targetPosition = Target.transform.position;
        ParentAttackRing.character.ResetPower();
        //Debug.Log(targetPosition);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.TAG_BOT))
        {

            ParentAttackRing.character.IncreaseLevel();

            Character tempChar = Cache.GetCharacter(other);

            ParentAttackRing.character.RemoveCharacter(tempChar);


            tempChar.OnDespawn();
            //tempChar.Despawn();
            tempChar.OnHit();
            //other.gameObject.SetActive(false);
            
            if (ParentAttackRing.character.CompareTag(ConstantClass.TAG_PLAYER))
            {
                ParentAttackRing.TargetRing.gameObject.SetActive(false);
                CoinManager.Ins.IncreaseTotalKillCoin();
            }

            this.gameObject.SetActive(false);

            Map.Ins.aliveBotNumber--;
            Map.Ins.activeBotNumber--;
            LevelManager.Ins.ChangeActiveBot(Map.Ins.aliveBotNumber);
            Map.Ins.CSpawnBot();
            
        }

        if (other.CompareTag(ConstantClass.TAG_PLAYER))
        {
            ParentAttackRing.character.IncreaseLevel();

            Character tempChar = Cache.GetCharacter(other);
            UIManager.Ins.GetUI<GamePlay>(UIManager.UIID.GamePlay).DeactiveJoystick(GameManager.Ins.Player);
            tempChar.OnHit();
            LevelManager.Ins.LoseBy(ParentAttackRing.character.CharName);
        }
    }

   
     
   

   

    
}
