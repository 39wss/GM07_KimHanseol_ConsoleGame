namespace Game.Character
{
  abstract class Character
  {
    public string Name { get; protected set; }
    public int Hp { get; protected set; }
    public int MaxHp { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }

    protected Character(string name, int maxHp, int attack, int defense)
    {
      Name = name;
      MaxHp = maxHp;
      Hp = maxHp;
      Attack = attack;
      Defense = defense;
    }

    public int TakeDamage(int damage)
    {
      int damageInt = Math.Max(1, damage - Defense);
      Hp = Math.Max(0, Hp - damageInt);
      return damageInt;
    }

    public bool IsAlive()
    {
      return Hp > 0;
    }
  }
}