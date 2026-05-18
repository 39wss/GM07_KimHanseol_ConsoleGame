using Game.Character;

namespace Game.System
{
  class DungeonManager
  {
    private const int MaxFloor = 3;

    public Monster? GetMonster(int floor)
    {
      switch (floor)
      {
        case 1: return new Slime();
        case 2: return new Bat();
        case 3: return new ShadowBrute();
        default:
            Console.WriteLine("더 이상 층이 없습니다");
            return null;
      }
    }

    public int GetMaxFloor()
    {
      return MaxFloor;
    }
  }
}