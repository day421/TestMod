using ModGenesia;
using RogueGenesia.Data;
using RogueGenesia.UI;
using System.Collections.Generic;
using UnityEngine;

public class TestMod : RogueGenesiaMod
{
    public static string ModFolder;

    public override void OnModLoaded(ModData modData)
    {
        ModFolder = modData.ModDirectory.FullName;

        Debug.Log("TestMod loaded");
    }

    public override void OnRegisterModdedContent()
    {
        AddTestModOption();
        AddTestCard();

        Debug.Log("TestMod loaded Success");
    }

    public void AddTestModOption()
    {
        LocalizationData englishLoc = new LocalizationData() { Key = "en", Value = "TestMod Option" };
        LocalizationDataList localization = new LocalizationDataList("TestMod Option") { localization = new List<LocalizationData>() { englishLoc } };

        LocalizationData englishLocTooltip = new LocalizationData() { Key = "en", Value = "TestMod On/Off" };
        LocalizationDataList localizationTooltip = new LocalizationDataList("TestMod Option") { localization = new List<LocalizationData>() { englishLocTooltip } };

        GameOptionData TestMod_option = ModOption.MakeToggleOption("On/Off", localization, false, localizationTooltip);

        var _option = ModOption.AddModOption(TestMod_option, "Accessibility Options", "TestMod");

        Debug.Log("TestMod Option loaded");
    }

    public override void OnAllContentLoaded()
    {
        Debug.Log("Game Finished Loading Mods Step");
    }

    public void AddTestCard()
    {
        //Soul Card information
        SoulCardCreationData soulCardCreationData = new SoulCardCreationData();

        //Tags of Soul Card
        soulCardCreationData.Tags = CardTag.Fire;

        //Set max level
        soulCardCreationData.MaxLevel = 3;

        //Sprite of Soul Card
        soulCardCreationData.Texture = ModGenesia.ModGenesia.LoadSprite(ModFolder + "/ExampleCard.png");

        //Set name of Soul Card
        soulCardCreationData.NameOverride = new List<LocalizationData>();
        soulCardCreationData.NameOverride.Add(new LocalizationData());
        soulCardCreationData.NameOverride[0].Key = "en";
        soulCardCreationData.NameOverride[0].Value = "Test Card";
        soulCardCreationData.NameOverride[1].Key = "ko";
        soulCardCreationData.NameOverride[1].Value = "Test 카드";

        //Description of Soul Card
        soulCardCreationData.DescriptionOverride = new List<LocalizationData>();
        soulCardCreationData.DescriptionOverride.Add(new LocalizationData());
        soulCardCreationData.DescriptionOverride[0].Key = "en";
        soulCardCreationData.DescriptionOverride[0].Value = "TestCard Description";
        soulCardCreationData.DescriptionOverride[1].Key = "ko";
        soulCardCreationData.DescriptionOverride[1].Value = "TestCard 설명";

        //Set the stats modifier of Soul Card
        soulCardCreationData.ModifyPlayerStat = true;
        soulCardCreationData.StatsModifier = new StatsModifier();

        soulCardCreationData.StatsModifier.ModifiersList.Add(new StatModifier());
        soulCardCreationData.StatsModifier.ModifiersList[0].Key = nameof(StatsType.Damage);
        soulCardCreationData.StatsModifier.ModifiersList[0].Value = new SingularModifier(0);
        soulCardCreationData.StatsModifier.ModifiersList[0].Value.ModifierType = ModifierType.Compound;
        soulCardCreationData.StatsModifier.ModifiersList[0].Value.Value = 2.5f;

        soulCardCreationData.StatsModifier.ModifiersList.Add(new StatModifier());
        soulCardCreationData.StatsModifier.ModifiersList[1].Key = nameof(StatsType.MaxHealth);
        soulCardCreationData.StatsModifier.ModifiersList[1].Value = new SingularModifier(0);
        soulCardCreationData.StatsModifier.ModifiersList[1].Value.ModifierType = ModifierType.Compound;
        soulCardCreationData.StatsModifier.ModifiersList[1].Value.Value = 0.25f;

        soulCardCreationData.StatsModifier.ModifiersList.Add(new StatModifier());
        soulCardCreationData.StatsModifier.ModifiersList[2].Key = nameof(StatsType.AttackCoolDown);
        soulCardCreationData.StatsModifier.ModifiersList[2].Value = new SingularModifier(0);
        soulCardCreationData.StatsModifier.ModifiersList[2].Value.ModifierType = ModifierType.Compound;
        soulCardCreationData.StatsModifier.ModifiersList[2].Value.Value = 0.9f;

        soulCardCreationData.StatsModifier.ModifiersList.Add(new StatModifier());
        soulCardCreationData.StatsModifier.ModifiersList[3].Key = nameof(StatsType.AttackDelay);
        soulCardCreationData.StatsModifier.ModifiersList[3].Value = new SingularModifier(0);
        soulCardCreationData.StatsModifier.ModifiersList[3].Value.ModifierType = ModifierType.Compound;
        soulCardCreationData.StatsModifier.ModifiersList[3].Value.Value = 0.9f;

        soulCardCreationData.StatsModifier.ModifiersList.Add(new StatModifier());
        soulCardCreationData.StatsModifier.ModifiersList[4].Key = nameof(StatsType.XPMultiplier);
        soulCardCreationData.StatsModifier.ModifiersList[4].Value = new SingularModifier(0);
        soulCardCreationData.StatsModifier.ModifiersList[4].Value.ModifierType = ModifierType.Compound;
        soulCardCreationData.StatsModifier.ModifiersList[4].Value.Value = 1.1f;

        //Weight from droping
        soulCardCreationData.DropWeight = 0.05f;
        soulCardCreationData.LevelUpWeight = 0.1f;

        //Soul Card rarity
        soulCardCreationData.Rarity = CardRarity.Ascended;

        //Set from which mod the card is from
        soulCardCreationData.ModSource = "TestMod";

        //AddCustomStatCard(string CardName, SoulCardCreationData SoulCardCreationData, bool unlockedByDefault = true)
        CardAPI.AddCustomStatCard("Stat_TestMod_1", soulCardCreationData, true);

        Debug.Log("TestMod Soul Card loaded");
    }
}