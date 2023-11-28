using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
	protected int  maxHP = 100;
	protected int  HP;
	protected int  repair = 0;

	protected int  adDef = 0;
	protected int  apDef = 0;
	
	protected int  attackDamage = 0;

	private float   healCoolTime = 5.0f;
	private float   updateTime = 0.0f;

	protected virtual void Start() {
		HP = maxHP;
	}

	// Update is called once per frame
	protected virtual void FixedUpdate() {
		if (repair != 0) {
			if (updateTime >= healCoolTime) {
				updateTime = 0.0f;
				heal(repair);
			} else {
				updateTime += Time.fixedDeltaTime;
			}
		}
	}

	public void heal(int healAmount) {
		this.HP += healAmount;
		hpCheck();
	}

	public void damageAD(int damage) {
		HP = HP - (damage - adDef);
		if (HP <= 0) isDied();
		resetHealUpdateTime();
		hpCheck();
	}

	public void damageAP(int damage) {
		HP = HP - (damage - apDef);
		if (HP <= 0) isDied();
		resetHealUpdateTime();
		hpCheck();
	}

	protected void hpCheck() {
		if (HP < 0) {
			HP = 0;
		} else if (HP > maxHP) {
			HP = maxHP;
		}
	}

	protected void resetHealUpdateTime() {
		this.updateTime = 0.0f;
	}

	public void attack(GameObject target) {
		target.GetComponent<Ability>().damageAD(this.attackDamage);
	}

	protected virtual void isDied() {}

	public int getMaxHP() { return (this.maxHP); }
	public int getHP() { return (this.HP); }
	public int geRepair() { return (this.repair); }
	public int getAdDef() { return (this.adDef); }
	public int getApDef() { return (this.apDef); }

	public void getMaxHP(int newValue) { this.maxHP = newValue; }
	public void geRepair(int newValue) { this.repair = newValue; }
	public void getAdDef(int newValue) { this.adDef = newValue; }
	public void getApDef(int newValue) { this.apDef = newValue; }
}
