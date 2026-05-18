namespace Game.System
{
  class SlimeLoot : Item
  {
    public SlimeLoot() : base("녹조류", 15, ItemType.Loot) {}
    public override void ShowInfo()
    {
      Console.WriteLine($"전리품: {Name}, 가격: {Price}");
    }
  }

  class BatLoot : Item
  {
    public BatLoot() : base("박쥐 날개", 15, ItemType.Loot) {}
    public override void ShowInfo()
    {
      Console.WriteLine($"전리품: {Name}, 가격: {Price}");
    }
  }

  class ShadowBruteLoot : Item
  {
    public ShadowBruteLoot() : base("공허 정수", 50, ItemType.Loot) {}
    public override void ShowInfo()
    {
      Console.WriteLine($"전리품: {Name}, 가격: {Price}");
    }
  }
}