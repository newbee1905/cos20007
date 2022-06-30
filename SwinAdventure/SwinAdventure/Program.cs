﻿namespace SwinAdventure;
public static class Program
{
	private static string? ReadLineWithDesc(string desc)
	{
		Console.WriteLine(desc);
		return Console.ReadLine();
	}

	private static Player GetPlayer() =>
		new Player(
			ReadLineWithDesc("What is your name?") ?? "name",
			ReadLineWithDesc("Tell me a bit about yourself?") ?? "LMAO"
		);

	public static void Main(string[] args)
	{
		Player player = GetPlayer();
		Item starterWeapon = new(
			new string[] { "weapon", "starter", "sword" },
			"Starter Sword",
			"Free sword for people who just start"
		);
		Item starterArmour = new(
			new string[] { "armour", "starter", "chest plate" },
			"Starter Chest Plate",
			"Free chest plate for people who just start"
		);
		Bag fabricBag = new(
			new string[] { "bag", $"{player.Name}'s bag" },
			"Fabric Bag",
			"Free fabric bag for people who just start"
		);
		Item apple = new(
			new string[] { "food", "apple" },
			"Apple",
			"Apple"
		);
		Console.WriteLine($"Giving {player.Name} starter equipments...");
		player.Inventory.Put(starterWeapon);
		player.Inventory.Put(starterArmour);

		fabricBag.Inventory.Put(apple);
		player.Inventory.Put(fabricBag);

		Location wonderLand = new(
			new string[] { "Wonder", "Land" },
			"WonderLand",
			"A Wonderful Land"
		);
		Item banana = new(
			new string[] { "food", "banana" },
			"Banana",
			"Green Banana"
		);
		Item brokenSword = new(
			new string[] { "weapon", "broken", "sword" },
			"Broken Sword",
			"Old and Broken Sword in the middle of the land"
		);
		wonderLand.Items.Put(banana);
		wonderLand.Items.Put(brokenSword);

		player.CurLocation = wonderLand;

		LookCommand look = new(new string[] { "look" });
		string[] command;
		string? inp = "";
		
		Console.WriteLine("Type your command below. Or type quit to stop the program.");
		while (true)
		{
			Console.Write("> ");
			inp = Console.ReadLine();
			if (inp == null || inp == "quit")
				break;
			command = inp.Split(" ");
			Console.WriteLine($"= {look.Execute(player, command)}");
		}
	}
}
