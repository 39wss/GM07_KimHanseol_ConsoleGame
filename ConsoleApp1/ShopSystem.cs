namespace Game.System {
  class ShopSystem {
    public Item[] shopItems = {
      new Weapon("나무 검", 5, 100),
      new Weapon("구리 검", 10, 300),
      new Weapon("철 검", 20, 700),
      new Armor("가죽 갑옷", 3, 100),
      new Armor("구리 갑옷", 7, 300),
      new Armor("철 갑옷", 15, 700),
      new HealItem("체력 물약", 50, 100),
      new HealItem("HP 풀충전", 999, 300),
    };
  }
}