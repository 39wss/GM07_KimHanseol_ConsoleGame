using Game.Character;

namespace Game.System
{
  class BattleSystem
  {
    public void StartBattle(Player player, Monster? monster)
    {
      Console.WriteLine($"{monster.Name}이(가) 나타났다!");

      while(player.IsAlive() && monster.IsAlive())
      {
        PlayerTurn(player, monster);
        if(!monster.IsAlive()) break;

        MonsterTurn(player, monster);
      }

      if(player.IsAlive())
      {
        Console.WriteLine($"\n {monster.Name}을(를) 처치했다!");
        player.GainExp(monster.DropExp);
        if(monster.Loot != null)
        {
          player.Inventory.Add(monster.Loot);
          Console.WriteLine($"\n {monster.Loot.Name}을(를) 획득했다!");
        }
      }
      else
      {
        // Console.WriteLine($"\n 게임 오버...");
      }
    }

    public void PlayerTurn(Player player, Monster monster)
    {
      Console.WriteLine("\n --- 플레이어 턴 ---");
      Console.WriteLine("1) 공격");
      Console.WriteLine("원하는 행동을 입력하세요: ");

      string input = Console.ReadLine();

      switch(input)
      {
        case "1":
          int dmg = monster.TakeDamage(player.Attack);
          Console.WriteLine($"{player.Name}의 공격! {monster.Name}에게 {dmg} 데미지!");
          Console.WriteLine($"{monster.Name} 남은 HP: {monster.Hp}");
          break;
        default: 
          Console.WriteLine("잘못된 입력, 턴을 넘깁니다.");
          break;
      }
    }

    public void MonsterTurn(Player player, Monster monster)
    {
      Console.WriteLine("\n --- 몬스터 턴 ---");
      int dmg = player.TakeDamage(monster.Attack);
      Console.WriteLine($"{monster.Name}의 공격! {player.Name}에게 {dmg} 데미지!");
      Console.WriteLine($"{player.Name} 남은 HP: {player.Hp}");
    }
  }
}