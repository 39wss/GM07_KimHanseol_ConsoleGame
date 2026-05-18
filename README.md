# 턴제 RPG 제작 과제

스타듀밸리의 농부가 펠리칸 타운 외곽 광산을 탐험하며 몬스터를 처치하는 턴제 RPG

## 구현 기능

- 플레이어 이름 입력 후 게임 시작
- 메인 메뉴에서 상점 / 인벤토리 / 광산 / 종료 선택
- 턴제 전투 (방어력 적용 데미지 계산, 최소 1 데미지 보장)
- 경험치 획득 및 레벨업 (HP / 공격력 / 방어력 증가)
- 상점에서 무기 / 방어구 / 회복약 구매
- 인벤토리에서 아이템 확인 및 판매 (구매가의 50%)
- 몬스터 처치 시 전리품 자동 획득
- 1층 슬라임 → 2층 박쥐 → 3층 그림자 덩치 순서로 던전 진행
- HP 0이면 광산 입장 불가



## 클래스 구조

```
Character                           // 공통 속성/메서드 (Name, Hp, TakeDamage, IsAlive)
├── Player : Character, ILevelable  // 레벨, 경험치, 골드, 인벤토리 관리
└── Monster : Character             // DropExp, Loot 공통 보유
    ├── Slime : Monster
    ├── Bat : Monster
    └── ShadowBrute : Monster

Item                                // Name, Price, Type 공통 속성
├── Weapon : Item                   // 공격력(Atk) 보유
├── Armor : Item                    // 방어력(Def) 보유
├── HealItem : Item                 // 회복량(HealAmount) 보유
├── SlimeLoot : Item                // 전리품(Loot)
├── BatLoot : Item
└── ShadowBruteLoot : Item

인터페이스
└── ILevelable                      // GainExp(), LevelUp() 구현

시스템
├── GameManager                     // 메인 루프, 메뉴, 상점/인벤토리/광산 진입
├── BattleSystem                    // 턴제 전투 로직
├── DungeonManager                  // 층별 몬스터 생성
└── ShopSystem                      // 상점 아이템 목록 보관
```



## 사용한 컬렉션

List<Item> Inventory (Player.cs)

- 플레이어가 보유한 아이템 목록
- Add()로 아이템 추가, RemoveAt()으로 판매 시 삭제
- Count로 현재 보유 개수 확인

Item[] shopItems (ShopSystem.cs)

- 상점에서 판매하는 아이템 목록
- Length로 아이템 개수 확인


