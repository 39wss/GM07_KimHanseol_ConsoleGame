using Game.Character;
using Game.System;

namespace Game.Character
{
  class Player : Character, ILevelable
  {
    public int Gold { get; private set; } = 1000;
    public int Level { get; private set; } = 1;
    public int Exp { get; private set; }
    public int NextLevelExp { get; private set; } = 30;
    public int MineFloor { get; private set; } // 현재 광산 층수

    private const int MaxInventorySize = 10;
    public List<Item> Inventory { get; private set; } = new List<Item>();

    public Player(string name) : base(name, 100, 10, 5)
    {
      MineFloor = 1;
    }

    public void AddGold(int amount) { Gold += amount; }
    public void SpendGold(int amount) { Gold = Math.Max(0, Gold - amount); }

    public void GainExp(int exp)
    {
      Exp += exp;
      Console.WriteLine($"\n 경험치 {exp} 획득! (현재 {Exp}/{NextLevelExp})");

      if(Exp >= NextLevelExp)
      {
        LevelUp();
      }
    }
    public void LevelUp()
    {
      Level++;
      Exp = 0;
      NextLevelExp = (int)(NextLevelExp * 1.5);
      MaxHp += 20;
      Hp = MaxHp;
      Attack += 10;
      Defense += 5;

      Console.WriteLine($"레벨업! {Level} 레벨이 되었다!");
      Console.WriteLine($"HP: {Hp} / 공격력: {Attack}/ 방어력: {Defense}");
    }
    public void Heal(int amount) {
      Hp = Math.Min(MaxHp, Hp + amount);
      Console.WriteLine($"HP {amount} 회복! (현재 {Hp}/{MaxHp})");
    }
  }
}