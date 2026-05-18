using Game.Character;

namespace Game.System {
  class GameManager 
  {
    private Player player;
    private DungeonManager dungeon;
    private BattleSystem battle;
    private ShopSystem shop;

    public GameManager() 
    {
      Console.WriteLine("=== 스타듀 던전 ===");
      Console.Write("이름을 입력하세요: ");
      string name = Console.ReadLine() ?? "농부";

      player = new Player(name);
      dungeon = new DungeonManager();
      battle = new BattleSystem();
      shop = new ShopSystem();
    }

    public void Run() 
    {
      bool isRunning = true;
      while (isRunning)
      {
        ShowMainMenu();

        if(!int.TryParse(Console.ReadLine(), out int choice)) {
          continue;
        }
        switch ((MenuOption)choice)
        {
          case MenuOption.Shop:
          ShowShop();
          break;
          case MenuOption.Inventory:
          ShowInventory();
          break;
          case MenuOption.Mine:
          if(player.Hp <= 0) {
            Console.WriteLine("HP가 없어서 광산에 입장할 수 없습니다.");
            Console.WriteLine("상점에서 회복약을 구매하세요!");
            Console.ReadLine();
            break;
          }
          EnterDungeon(); 
          break;
          case MenuOption.Exit:
          Console.WriteLine("게임을 종료합니다.");
          isRunning = false;
          break;
          default:
          Console.WriteLine("잘못된 입력입니다.");
          break;
        }
      }
    }

    private void ShowShop() {
      Console.Clear();
      while(true) {
        Console.WriteLine("=== 상점 ===");
        Console.WriteLine($"현재 소지금: {player.Gold}");
        for(int i = 0;i < shop.shopItems.Length;i++) {
          Console.Write($"[{i+1}] ");
          shop.shopItems[i].ShowInfo();
        }
        Console.WriteLine("---");
        Console.WriteLine("[0] 나가기");
        Console.WriteLine("구매할 아이템을 선택하세요: ");

        if(int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= shop.shopItems.Length)
        {
          BuyItem(shop.shopItems[idx - 1]);
        }
        else {
          if(idx >= shop.shopItems.Length) {
            Console.WriteLine("유효한 숫자를 입력해주세요.");
          } else break;
        }
      }
    }

    private void BuyItem(Item item) {
      if(player.Gold < item.Price) {
        Console.WriteLine("골드가 부족합니다.");
        return;
      }
      player.SpendGold(item.Price);

      if (item is HealItem healItem)
      {
          player.Heal(healItem.HealAmount);
          Console.WriteLine($"{item.Name} 사용!");
      }
      else
      {
          player.Inventory.Add(item);
          Console.WriteLine($"{item.Name} 구매 성공!");
      }
    }

    private void ShowMainMenu() {
      Console.Clear();
      Console.WriteLine("=== 메인 메뉴 ===");
      Console.WriteLine($"[{player.Name}] LV.{player.Level} HP: {player.Hp}/{player.MaxHp}");
      Console.WriteLine("1) 상점");
      Console.WriteLine("2) 인벤토리");
      Console.WriteLine("3) 광산");
      Console.WriteLine("0) 종료");
      Console.WriteLine("원하는 행동을 입력하세요: ");
    }

    private void ShowInventory()
    {
      Console.Clear();
      while(true) {
        Console.WriteLine("=== 인벤토리 ===");
        if(player.Inventory.Count == 0) {
          Console.WriteLine("아이템이 없습니다.");

          Console.WriteLine("---");
          Console.WriteLine("[0] 나가기");
          if (Console.ReadLine() == "0") break;
          continue;
        }
        for (int i = 0; i < player.Inventory.Count; i++)
        {
          Console.Write($"[{i + 1}] ");
          player.Inventory[i].ShowInfo();
        }
        Console.WriteLine("---");
        Console.WriteLine("[0] 나가기");
        Console.Write("판매할 아이템을 선택하세요: ");

        if(int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx<= player.Inventory.Count)
        {
          Item selectedItem = player.Inventory[idx - 1];
          SellItem(idx - 1);
        }
        else {
          if(idx >= player.Inventory.Count) {
            Console.WriteLine("빈 슬롯입니다.");
          }
          else break;
        }
      }
    }

    private void SellItem(int slotIndex) {
      Item item = player.Inventory[slotIndex];

      int sellPrice = item.Price / 2;
      player.AddGold(sellPrice);
      player.Inventory.RemoveAt(slotIndex);
      Console.WriteLine($"\n {item.Name} 판매 완료 + {sellPrice}Gold");
    }

    private void EnterDungeon() 
    {
      Console.Clear();
      for(int f =  1;f <= dungeon.GetMaxFloor();f++)
      {
        Console.WriteLine($"\n === 광산 {f}층 ===");
        Monster? monster = dungeon.GetMonster(f);
        battle.StartBattle(player, monster);

        if(!player.IsAlive()) {
          Console.WriteLine($"\n 게임 오버...");
          Console.WriteLine("---");
          Console.WriteLine("[0] 나가기");

          Console.ReadLine();
          return;
        }
      }
      Console.WriteLine("광산을 클리어했다!");
      Console.WriteLine($" 최종 레벨: {player.Level} / HP: {player.Hp}/{player.MaxHp}");
      Console.WriteLine("---");
      Console.WriteLine("[0] 나가기");
      Console.ReadLine();
    }
  }
}