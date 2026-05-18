using Game.Character;
using Game.System;

namespace Game.Character
{
  abstract class Monster : Character
  {
    public int DropExp { get; protected set; }
    public Item? Loot { get; protected set; }

    protected Monster(string name, int maxHp, int attack, int defense, int dropExp, Item? loot) : base(name, maxHp, attack, defense)
    {
      DropExp = dropExp;
      Loot = loot;
    }
  }

  class Slime : Monster
  {
    public Slime() : base("슬라임", 30, 10, 5, 20, new SlimeLoot())
    {
      
    }
  }

  class Bat : Monster
  {
    public Bat() : base("박쥐", 30, 5, 2, 10, new BatLoot())
    {
      
    }
  }

  class ShadowBrute : Monster
  {
    public ShadowBrute() : base("그림자 덩치", 100, 20, 15, 40, new ShadowBruteLoot())
    {
      
    }
  }
}