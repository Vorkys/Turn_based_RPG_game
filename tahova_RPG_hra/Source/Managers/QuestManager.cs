using System.Collections.Generic;
using TurnBasedRPG.Source.Quests;
using TurnBasedRPG.Source.Quests.QuestObjectives;
using static TurnBasedRPG.Source.Quests.Quest;

namespace TurnBasedRPG.Source.Managers
{
    public class QuestManager
    {
        public static Quest StartQuest = new(
            status: Status.Open,
            prerequisities: null,
            name: "What should i do?",
            description: "I am so bored I dont know what I should do. Maybe killing a few Cute Slimes and go back to my Village East of my position will help me think.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.CuteSlime.Name,
                    requiredKills: 5
                )
            },
            rewards: new List<Reward>()
            {
                new Reward(ItemManager.SmallHealthPotion, 2)
            },
            rewardMoney: 5
        );

        #region T1_Quests
        public static Quest _001 = new(
            prerequisities: new List<Quest>() {
                StartQuest
            },
            name: "A new journey?",
            description: "I met a visitor. He told me that if I proved him I could handle a few Small Goblins he could use my help. Small Goblins can be found around my Village.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.SmallGoblin.Name,
                    requiredKills: 5
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.SmallHealthPotion, 5)
            },
            rewardMoney: 10
        );

        public static Quest _002 = new(
            prerequisities: new List<Quest>() {
                _001
            },
            name: "Get to Fanges",
            description: "The visitor told me I should go to Fanges. A City in the Plains in the South from my Village. I should talk to the local representation.",
            objectives: null,
            rewards: new List<Reward>() {
                new Reward(ItemManager.HealthPotion, 2)
            },
            rewardMoney: 10
        );

        public static Quest _003 = new(
            prerequisities: new List<Quest>() {
                _002
            },
            name: "Hunt Big Goblins!",
            description: "John from Fanges told me there is a reward for killing Big Goblins in the area and Wolf tusks. Wolf tusks have a chance to drop from Wolves. I can find Big Goblins and Wolves around Fanges.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.BigGoblin.Name,
                    requiredKills: 3
                ),
                new LootObjective(
                    itemName: ItemManager.WolfTusk.Name,
                    requiredAmount: 3
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.HealthPotion, 5)
            },
            rewardMoney: 20
        );
        #endregion

        #region T2_Quests
        public static Quest _004 = new(
            prerequisities: new List<Quest>() {
                _003
            },
            name: "Get to Enpolis",
            description: "John told me I have helped the city enough. He sent me to Enpolis, a small town hidden in the Forest East of Fanges.",
            objectives: null,
            rewards: null,
            rewardMoney: 50
        );

        public static Quest _005 = new(
            prerequisities: new List<Quest>() {
                _004
            },
            name: "Find some Magic Dust",
            description: "Filip, the bounty manager of Enpolis told me they need some Magic Dust. It is a rare Dust found on magical beings. He told me I can find magical beings around Enpolis and, if I feel strong enough, I can find more commonly in the Deep Forest.",
            objectives: new List<Objective>() {
                new LootObjective(
                    itemName: ItemManager.MagicDust.Name,
                    requiredAmount: 1
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.IronRing, 1)
            },
            rewardMoney: 50
        );

        public static Quest _006 = new(
            prerequisities: new List<Quest>() {
                _005
            },
            name: "Kill the Dungeon Master",
            description: "After I brought Magic dust to Filip he told me there is a Dungeon up North. The Dungeon Master is corrupting the Forest and needs to be put down! After I kill him I should get back to Filip.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.DungeonMaster.Name,
                    requiredKills: 1
                )
            },
            rewards: null,
            rewardMoney: 150
        );
        #endregion

        #region T3_Quests
        public static Quest _007 = new(
            prerequisities: new List<Quest>() {
                _006
            },
            name: "Get to Arrowing",
            description: "After I came back to Filip I was feeling sick. Filip told me the Dungeon Master managed to corrupt me. He told me some researchers on a Volcano Island are studying this sickness and could help me. He told me I should get to the desert town called Arrowing and get stronger there.",
            objectives: null,
            rewards: new List<Reward>() {
                new Reward(ItemManager.BigGrenade, 2)
            },
            rewardMoney: 80
        );

        public static Quest _008 = new(
            prerequisities: new List<Quest>() {
                _007
            },
            name: "Help the people of Arrowing",
            description: "After reaching Arrowing the local population told me they need help. They are overwhelmed by wild animals. They asked me to kill some to reduce the wild population.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.Lion.Name,
                    requiredKills: 5
                ),
                new KillObjective(
                    enemyName: EntityManager.Scorpion.Name,
                    requiredKills: 3
                ),
                new KillObjective(
                    enemyName: EntityManager.Worm.Name,
                    requiredKills: 2
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.BigHealthPotion, 5),
                new Reward(ItemManager.BigPinkPotion, 3)
            },
            rewardMoney: 100
        );

        public static Quest _009 = new(
            prerequisities: new List<Quest>() {
                _008
            },
            name: "Get to Savana Camp",
            description: "After I helped the local population they told me there is a Transporter in the Savana Camp that will take me to the Volcano Island.",
            objectives: null,
            rewards: null,
            rewardMoney: 100
        );
        #endregion

        #region T4_Quests
        public static Quest _010 = new(
            prerequisities: new List<Quest>() {
                _009
            },
            name: "Get to Ash Land Camp",
            description: "After I reached the Savana Camp the Transporter told me that he can take me to the Volcano Island if I feel strong enough.",
            objectives: null,
            rewards: null,
            rewardMoney: 85
        );

        public static Quest _011 = new(
            prerequisities: new List<Quest>() {
                _010
            },
            name: "In search of a cure",
            description: "I reached Ash Land Camp. I found Thomas, a scientist studying corruption. They told they need a sample to continue their work. I need to kill some enemies surrounding.",
            objectives: new List<Objective>() {
                new KillObjective(
                    enemyName: EntityManager.Skeleton.Name,
                    requiredKills: 4
                ),
                new KillObjective(
                    enemyName: EntityManager.Golem.Name,
                    requiredKills: 4
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.EnormousHealthPotion, 5)
            },
            rewardMoney: 250
        );

        public static Quest _012 = new(
            prerequisities: new List<Quest>() {
                _011
            },
            name: "Continue the research",
            description: "I didnt find anything usefull... They told me I will have to go deeper West... There are stronger enemies but I should be able to get a Corrupted Hearth which should help me...",
            objectives: new List<Objective>() {
                new LootObjective(
                    itemName: ItemManager.CorruptedHeart.Name,
                    requiredAmount: 1
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.HellishShield, 1),
                new Reward(ItemManager.HellishSword, 1)
            },
            rewardMoney: 350
        );

        public static Quest _013 = new(
            prerequisities: new List<Quest>() {
                _012
            },
            name: "Get back to Fanges",
            description: "After I brought the Corrupted Hearth back to the scientists I learned that I have to mix some mixture with another Heavenly mixture that can only be found in Heaven. They told me that Fanges has a way to get to Heaven.",
            objectives: null,
            rewards: null,
            rewardMoney: 200
        );
        #endregion

        #region T5_Quest
        public static Quest _014 = new(
            prerequisities: new List<Quest>() {
                _013
            },
            name: "Get to Heaven",
            description: "I am back in Fanges. I should talk with the Transporter to get to Heaven and Continue my journey.",
            objectives: null,
            rewards: new List<Reward>() {
                new Reward(ItemManager.GoldRingWithSaphire, 1),
                new Reward(ItemManager.TNT, 1)
            },
            rewardMoney: 250
        );

        public static Quest _015 = new(
            prerequisities: new List<Quest>() {
                _014
            },
            name: "Find a Holy Heart",
            description: "I reached an unexpected tavern in Heaven. People look at me in a strange way. I need to get a Holy Heart to create the mixture that can cure me.",
            objectives: new List<Objective>() {
                new LootObjective(
                    itemName: ItemManager.HolyHeart.Name,
                    requiredAmount: 1
                )
            },
            rewards: new List<Reward>() {
                new Reward(ItemManager.BottomlessPinkPotion, 1)
            },
            rewardMoney: 500
        );

        public static Quest _016 = new(
            prerequisities: new List<Quest>() {
                _015
            },
            name: "Get to the Abondoned Temple",
            description: "I have all I need to create the mixture that will cure me. From what the scientists told me I need to visit the Abondoned Temple and create the mixture and drink it there. It will soon be all over.",
            objectives: null,
            rewards: null,
            rewardMoney: 0
        );
        #endregion

        public static Quest _017 = new(
            prerequisities: new List<Quest>() {
                _016
            },
            name: "Cure myself!",
            description: "I should drink the mixture.",
            objectives: null,
            rewards: null,
            rewardMoney: 0
        );
    }
}
