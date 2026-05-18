namespace Game.System
{
  public enum ItemType
  {
    Weapon, Armor, Loot, Heal
  }

  public enum MenuOption
  {
    Shop = 1,
    Inventory = 2,
    Mine = 3,
    Exit = 0,
  }

  public abstract class Item
  {
    public string Name { get; protected set; }
    public int Price { get; protected set; }
    public ItemType Type { get; protected set; }

    public Item(string name, int price, ItemType type)
    {
      Name = name;
      Price = price;
      Type = type;
    }
    public abstract void ShowInfo();
  }

  public class Weapon : Item
  {
    public int Atk { get; private set; }
    public Weapon(string name, int atk, int price): base(name, price, ItemType.Weapon)
    {
      Atk = atk;
    }
    public override void ShowInfo()
    {
      Console.WriteLine($"무기: {Name}, 공격력: {Atk}, 가격: {Price}");
    }
  }
  public class Armor : Item
  {
    public int Def { get; private set; }

    public Armor(string name, int def, int price)
    : base (name, price, ItemType.Armor)
    {
      Def = def;
    }
    public override void ShowInfo()
    {
      Console.WriteLine($"방어구: {Name}, 방어력: {Def}, 가격: {Price}");
    }
  }
  public class HealItem : Item {
    public int HealAmount { get; private set; }
    public HealItem(string name, int healAmount, int price) : base(name, price, ItemType.Heal) {
      HealAmount = healAmount;
    }
    public override void ShowInfo()
    {
      Console.WriteLine($"회복약: {Name}, 회복량: {HealAmount}, 가격: {Price}");
    }
  }
}