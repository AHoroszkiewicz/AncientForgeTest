## 🚀 **Prerequisites**  
1. **Unity Hub** ([Download here](https://unity.com/download))  
2. **Unity Editor 6000.0.41f1**  
   - Install via Unity Hub → `Installs` → `Add` → Select version `6000.0.41f1`.  
3. **Git** ([Download here](https://git-scm.com/)) or another git client of choice  

---

## 📥 **Installation**  

### **1. Clone the Repository**  
```bash
git clone https://github.com/AHoroszkiewicz/AncientForgeTest.git
cd your-repo
```

### **2. Open the Project in Unity**  
- Launch **Unity Hub**  
- Click `Open` → Select the cloned project folder  
- Ensure Unity **6000.0.41f1** is selected  

> ⚠️ **If prompted to upgrade/downgrade**, **DO NOT** proceed. Use **only 6000.0.41f1**.  

### **3. Resolve Dependencies (If Needed)**  
- If errors appear, try:  
  - `Window` → `Package Manager` → Update packages  
  - Reimport assets: `Assets` → `Reimport All`  

---

## 🎮 **Running the Project**  
1. Open the main scene:  
   - Navigate to `Assets/Scenes/SampleScene.unity`
2. Press **▶ Play** in the Unity Editor.  

---

## 📦 **Project Structure**  
```
Assets/
├── Audio/                          # Just failed crafting sfx
│
├── Prefabs/                        # Prefab objects
│   ├── Machines/                   # Machine oriented prefabs
│   └── Particles/                  # Particle effects
│
├── Scenes/                         # Unity scene files
│
├── Scripts/                        # C# scripts
│   ├── Character/                  # Character related logic
│   ├── Inventory/                  # Inventory system
│   └── Machines/                   # Machine interactions
│
├── SO/                             # Scriptable Objects
│   ├── Bonus/                      # Bonus effects/data
│   ├── Items/                      # Item definitions
│   ├── Quests/                     # Quest data
│   └── Recipes/                    # Crafting recipes
│
└── Sprites/                        # 2D textures & UI art
    ├── Bonuses/                    # Bonus icons
    ├── Items/                      # Item icons
    ├── mt2/                        # Metin2 related icons
    └── ReallyProfessionalProgressIcons/  # Progress bars/UI icons
```

---

## 🔍 **Unique Code Decisions**
1. 🔢 Item ID Indexing System
I used a deliberate offset between list indices (0-based) and enum values (1-based):

```csharp
public enum ItemsEnum {
    None = 0,          // 0 = No item
    IronOre = 1,   // First actual item
    GoldOre = 2,
    FireShard = 3,          // etc...
}
```
It prevents accidental default(enum) == valid item
Also, in project document item list starts with 1 so it matches.

To access items from inventory item list, it's neccessary to either use id: id-1 or itemEnum: ItemsEnum
for exaple:

```csharp
AddItem(10, itemEnum: ItemsEnum.IronOre);
AddItem(10, id: (int)ItemsEnum.IronOre - 1);
```
