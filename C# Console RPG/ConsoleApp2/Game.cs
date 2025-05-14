using System.Collections;
using System.Net.Http.Headers;

namespace ConsoleApp2
{
    internal class Game
    {
        private Dictionary<string, (int cost, int itemCount)> chests = new Dictionary<string, (int cost, int itemCount)>()
        {
            { "Basic Chest", (50, 1) },
            { "Normal Chest", (90, 2) },
            { "Big Chest", (130, 3) },
            { "Giga Chest", (400, 10) },
        };

        private List<Tuple<string, double, double, double>> classes = new List<Tuple<string, double, double, double>>()
        {
            Tuple.Create("berserker", 100.0, 10.0, 25.0),
            Tuple.Create("tank", 200.0, 50.0, 5.0),
        };

        private List<Player> saved_players = new();
        private List<string[]> rows = new();

        private Tuple<string, double, double, double> class_attributes;

        private Random random = new Random();

        private Item dropped_item;
        private Item chosen_item;

        private Player player;

        private string[] values;

        private int combat_progress;
        private int choice;
        private int action;
        private int counter;
        private int inventory_choice;
        private int difficulty_choice;
        private int i;
        private int delay;
        private int delay_piece;
        private int next_key;
        private int random_index;
        private int line_count;

        private double overheal;
        private double damage_dealt;

        private string dots;
        private string name;
        private string double_check;
        private string line;
        private string inventory_data;
        private string equipped_data;

        private string file_path = "PlayerData.csv";

        private bool is_first_line;
        private bool playerFound;

        public Game()
        {

        }

        public void loadPlayers()
        {
            using (StreamReader reader = new StreamReader(file_path))
            {
                is_first_line = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (is_first_line)
                    {
                        is_first_line = false;
                        continue;
                    }
                    values = line.Split(";");
                    rows.Add(values);
                }
            }

            foreach (var row in rows)
            {
                if (row.Length < 13) 
                {
                    continue;
                }

                string name = row[0];
                string player_class = row[1];
                double max_health = Convert.ToDouble(row[2]);
                double armor = Convert.ToDouble(row[3]);
                double damage = Convert.ToDouble(row[4]);
                int difficulty = Convert.ToInt32(row[5]);
                double current_health = Convert.ToDouble(row[6]);
                int round = Convert.ToInt32(row[7]);
                int level = Convert.ToInt32(row[8]);
                int xp = Convert.ToInt32(row[9]);
                int gold = Convert.ToInt32(row[10]);

                Dictionary<int, Item> inventory = new();
                if (!string.IsNullOrEmpty(row[11]))
                {
                    string[] items = row[11].Split(",");
                    int dynamicKey = 1;
                    foreach (var itemData in items)
                    {
                        string[] itemParts = itemData.Split("-").Select(part => part.Trim()).ToArray();
                        if (itemParts.Length != 4)
                        {
                            continue;
                        }

                        int key = dynamicKey++;
                        string itemName = itemParts[0];
                        int itemValue = int.Parse(itemParts[1]);
                        string itemType = itemParts[2];
                        string itemSlot = itemParts[3];

                        inventory.Add(key, new Item(itemName, itemValue, itemType, itemSlot));
                    }
                }

                Dictionary<int, Item> equipped_items = new();
                if (!string.IsNullOrEmpty(row[12]))
                {
                    string[] equipped = row[12].Split(",");
                    int slotKey = 1; 
                    foreach (var equipped_item_data in equipped)
                    {
                        string[] itemParts = equipped_item_data.Split("-").Select(part => part.Trim()).ToArray();
                        if (itemParts.Length != 4)
                        {
                            continue;
                        }

                        string itemName = itemParts[0];
                        int itemValue = int.Parse(itemParts[1]);
                        string itemType = itemParts[2];
                        string itemSlot = itemParts[3];

                        equipped_items[slotKey++] = new Item(itemName, itemValue, itemType, itemSlot);
                    }
                }

                var class_specifications = Tuple.Create(player_class, max_health, armor, damage);

                Player loaded_player = new Player(name, class_specifications, difficulty, current_health, round, level, xp, gold, inventory, equipped_items);

                saved_players.Add(loaded_player);
            }
        }

        public void addToInventory(Player player, Item item)
        {
            if (player.inventory.Count == 0)
            {
                next_key = 2;
            }
            else
            {
                next_key = 2;

                while (player.inventory.ContainsKey(next_key))
                {
                    next_key++;
                }
            }
            player.inventory.Add(next_key, item);
        }

        public void openChest(Player player)
        {
            Console.WriteLine("Welcome to the Chest Shop, which chest would you like?: \n");

            counter = 0;
            foreach (var chest in chests)
            {
                if (counter == 0)
                {
                    Console.WriteLine("(0) - Exit shop\n");
                    counter++;
                }
     
                if (chest.Value.itemCount == 1)
                {
                    Console.WriteLine("(" + counter + ") - " + chest.Key + " - " + chest.Value.itemCount + " Item - " + chest.Value.cost + " Gold\n");
                }
                else
                {
                    Console.WriteLine("(" + counter + ") - " + chest.Key + " - " + chest.Value.itemCount + " Items - " + chest.Value.cost + " Gold\n");
                } 
                counter++;
            }

            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine("Exiting shop.\n");
                return;
            }
            else

            if (choice < 0 || choice > chests.Count)
            {
                Console.WriteLine("Please enter a valid number.\n");
                return;
            }

            var chosen_chest_key = chests.ElementAt(choice - 1).Key;
            var chosen_chest_value = chests.ElementAt(choice - 1).Value;
            
            if (player.gold >= chosen_chest_value.cost)
            {
                player.gold -= chosen_chest_value.cost;
                Console.WriteLine("You have bought a " + chosen_chest_key + " for " + chosen_chest_value.cost + " Gold.\n");

               for (i = 0; i < chosen_chest_value.itemCount; i++)
               {
                    var loot = dropLoot(player, new Enemy(player), chosen_chest_value.itemCount);
               }
            }
            else
            {
                Console.WriteLine("You do not have enough gold.\n");
            }
        }
        public void checkEquippedItems(Player player)
        {
            Console.WriteLine("Your equipped items are: \n");

            foreach (var item in player.equipped_items)
            {
                 Console.WriteLine(item.Value.name);
            }
            Console.WriteLine("\n");
        }
        public async Task mainLoop()
        {
            Console.WriteLine("Welcome to the game!\n" +
                              "You will be creating a character and then you will be thrown into the world.\n" +
                              "You will encounter enemies and loot.\n" +
                              "Good luck!\n");

            loadPlayers();

            if (saved_players.Count == 0)
            {
                player = characterCreation();
            }
            else
            {
                Console.WriteLine("Would you like to continue (0) or create a new character (1)? ");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                {
                    Console.WriteLine("Which character would you like to continue with?\n");

                    for (i = 1; i < saved_players.Count + 1; i++)
                    {
                        Console.WriteLine("(" + i + ") - " + saved_players[i - 1].name);
                    }

                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice > 0 && choice <= saved_players.Count)
                    {
                        player = saved_players[choice - 1];
                    }
                }
                else if (choice == 1)
                {
                    player = characterCreation();
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.\n");
                    return;
                }
            }
                do
                {
                    Console.WriteLine("(1) - Start looking for an Enemy\n" +
                                      "(2) - Open shop\n" +
                                      "(3) - Check Stats\n" +
                                      "(4) - Check Equipped Items\n" +
                                      "(5) - Check Inventory\n" +
                                      "(6) - Save & Exit game");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            delay = random.Next(3000, 10000);

                            delay_piece = delay / 9;

                            for (int i = 0; i < 9; i++)
                            {
                                dots = new string('.', i % 3 + 1); // crazy use of ai
                                Console.Write("\rLooking for enemy" + dots + "   ");
                                await Task.Delay(delay_piece);
                            }
                            Console.WriteLine("Enemy found! - Entering combat.\n");
                            enemyEncounter(player, new Enemy(player));
                            break;
                        case 2:
                            openChest(player);
                            break;
                        case 3:
                            checkPlayerStats(player);
                            break;
                        case 4:
                            checkEquippedItems(player);
                            break;
                        case 5:
                            checkInventory(player);
                            break;
                    case 6:
                        List<string> lines = File.ReadAllLines(file_path).ToList();

                        playerFound = false;
                        equipped_data = string.Join(",", player.equipped_items.Select(item => item.Value.name + " - " + item.Value.value + " - " + item.Value.type + " - " + item.Value.slot));

                        for (int j = 0; j < lines.Count; j++)
                        {
                            string[] lineParts = lines[j].Split(";");
                            if (lineParts[0] == player.name) 
                            {
                                inventory_data = string.Join(",", player.inventory.Select(item => item.Value.name + " - " + item.Value.value + " - " + item.Value.type + " - " + item.Value.slot));
                                lines[j] = player.name + ";" + player.player_class + ";" + player.max_health + ";" +
                                           player.armor + ";" + player.damage + ";" + player.difficulty + ";" +
                                           player.current_health + ";" + player.round + ";" + player.level + ";" +
                                           player.xp + ";" + player.gold + ";" + inventory_data + ";" + equipped_data;
                                playerFound = true;
                                break;
                            }
                        }

                        if (!playerFound)
                        {
                            inventory_data = string.Join(",", player.inventory.Select(item => item.Value.name + " - " + item.Value.value + " - " + item.Value.type + " - " + item.Value.slot));
                            lines.Add(player.name + ";" + player.player_class + ";" + player.max_health + ";" +
                                      player.armor + ";" + player.damage + ";" + player.difficulty + ";" +
                                      player.current_health + ";" + player.round + ";" + player.level + ";" +
                                      player.xp + ";" + player.gold + ";" + inventory_data + ";" + equipped_data);
                        }

                        File.WriteAllLines(file_path, lines);

                        Console.WriteLine("Game has been saved. Exiting game.\n");
                        break;
                    default:
                            Console.WriteLine("Please enter a valid number.\n");
                            break;

                    }
                } while (choice != 6 && player.alive);
        }

        public void checkPlayerStats(Player player)
        {
            Console.WriteLine("Your stats are: [Health]: " + player.current_health + "/" + player.max_health + 
                              " - [Armor]: " + player.armor + 
                              " - [Damage]: " + player.damage +
                              " - [Level]: " + player.level +
                              " - [XP]: " + player.xp + "/" + "100" + 
                              " - [Gold]: " + player.gold + "\n");
        }

        public void checkInventory(Player player)
        {
            if (player.inventory.Count > 0)
            {
                Console.WriteLine("Choose an item to equip or use:\n");

                Console.WriteLine("(0) to exit inventory\n(1) to sort inventory\n");

                foreach (var item in player.inventory)
                {
                    Console.WriteLine("(" + item.Key + ") - " + item.Value.name + " - " + item.Value.value + " - " + item.Value.type + " - " + item.Value.slot + "\n");
                }
                inventory_choice = Convert.ToInt32(Console.ReadLine());

                if (inventory_choice == 0)
                {
                    Console.WriteLine("Exiting inventory.\n");
                    return;
                }
                else if (inventory_choice == 1)
                {
                    player.inventory = player.inventory.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                    Console.WriteLine("Inventory sorted.\n");
                    return;
                }
                else if (!player.inventory.ContainsKey(inventory_choice))
                {
                    Console.WriteLine("Please enter a valid number.\n");
                    return;
                }
                else
                {
                    chosen_item = player.inventory[inventory_choice];

                    if (!player.equipped_items.ContainsValue(chosen_item))
                    {
                        if (chosen_item.type == "armor")
                        {
                            player.armor += chosen_item.value;

                            if (chosen_item.slot == "helmet")
                            {
                                if (player.equipped_items[1].value != 0)
                                {
                                    addToInventory(player, player.equipped_items[1]);
                                    player.armor -= player.equipped_items[1].value;
                                }
                                player.equipped_items[1] = chosen_item;
                            }
                            else if (chosen_item.slot == "chestplate")
                            {
                                if (player.equipped_items[2].value != 0)
                                {
                                    addToInventory(player, player.equipped_items[2]);
                                    player.armor -= player.equipped_items[2].value;
                                }
                                player.equipped_items[2] = chosen_item;
                            }
                            else if (chosen_item.slot == "legplate")
                            {
                                if (player.equipped_items[3].value != 0)
                                {
                                    addToInventory(player, player.equipped_items[3]);
                                    player.armor -= player.equipped_items[3].value;
                                }
                                player.equipped_items[3] = chosen_item;
                            }
                            else if (chosen_item.slot == "boot")
                            {
                                if (player.equipped_items[4].value != 0)
                                {
                                    addToInventory(player, player.equipped_items[4]);
                                    player.armor -= player.equipped_items[4].value;
                                }
                                player.equipped_items[4] = chosen_item;
                            }
                            Console.WriteLine(chosen_item.name + " has been equipped\n");
                            player.inventory.Remove(inventory_choice);
                        }
                        else if (chosen_item.slot == "sword")
                        {
                            player.damage += chosen_item.value;

                            if (player.equipped_items[5].value != 0)
                            {
                                addToInventory(player, player.equipped_items[5]);
                                player.armor -= player.equipped_items[5].value;
                            }
                            player.equipped_items[5] = chosen_item;

                            Console.WriteLine(chosen_item.name + " has been equpped\n");
                            player.inventory.Remove(inventory_choice);
                        }
                        else if (chosen_item.type == "heal")
                        {
                            if (player.current_health + chosen_item.value > player.max_health)
                            {
                                overheal = player.current_health + chosen_item.value - player.max_health;

                                Console.WriteLine("Are you sure you want to use: " + chosen_item.name + "? You will waste " + overheal + " HP\n" +
                                                  "(y/n)");
                                double_check = Console.ReadLine();

                                if (double_check == "y")
                                {
                                    player.current_health = player.max_health;

                                    Console.WriteLine(chosen_item.name + " has been used\n");
                                    player.inventory.Remove(inventory_choice);
                                }
                                else
                                {
                                    Console.WriteLine("You have chosen not to use the potion.\n");
                                    return;
                                }
                            }
                            else
                            {
                                player.current_health += chosen_item.value;

                                Console.WriteLine(chosen_item.name + " has been used\n");
                                player.inventory.Remove(inventory_choice);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You already have that item equipped.\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.\n");
                return;
            }
        }

        public void playerAttack(Player player, Enemy enemy)
        {

            if (enemy.armor > player.damage)
            {
                Console.WriteLine("Your damage is too low to damage this enemy. Better run\n");
            }
            else
            {
                damage_dealt = player.damage - enemy.armor;
            }

            enemy.health -= damage_dealt;

            Console.WriteLine("You attacked and dealt " + damage_dealt + " damage - " + enemy.name + " has " + enemy.health + " HP left.\n"); 

            if (enemy.health <= 0)
            {
                player.round++;

                dropped_item = dropLoot(player, enemy, 1);
                addToInventory(player, dropped_item);
                
                Console.WriteLine("You have defeated " + enemy.name + " and gained " + enemy.xp + " XP + " + enemy.gold + " Gold + " + dropped_item.name + "\n");
                player.xp += enemy.xp;
                player.gold += enemy.gold;
                combat_progress = 0;

                if (player.xp >= 100)
                {
                    player.levelUp();
                }
                return;
            }

            combat_progress++;

            if (combat_progress % 2 == 0)
            {
                Console.WriteLine("Enemy attacks and deals " + enemy.damage + " damage.\n");
                player.current_health -= enemy.damage;

                if (player.current_health <= 0)
                {
                    player.alive = false;
                }
            }
        }

        public Player characterCreation()
        {
            do
            {
                Console.WriteLine("Enter your Characters name: ");
                name = Console.ReadLine();

                if (saved_players.Any(player => player.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("This name is already taken. Please choose another name.\n");
                }
                else
                {
                    break;
                }
            } while (true);

            if (name == "GOD")
            {
                Player GOD = new Player(name, Tuple.Create("GOD", 999.0, 999.0, 999.0), 1, 999.0, 0, 999, 0, 9999);
                return GOD;
            }
            else
            {
                Console.WriteLine("\n" + name + " which class would you like to become?: \n" +
                                  "(1) - Berserker\n" +
                                  "(2) - Tank\n");

                choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(name + ", how difficult do you want your experience to be?: \n" +
                                         "(1) - Easy\n" +
                                         "(2) - Normal\n" +
                                         "(3) - Hard\n" + 
                                         "(4) - Extreme\n");

                difficulty_choice = Convert.ToInt32(Console.ReadLine());

                class_attributes = (classes.ElementAt(choice - 1));

                switch (choice)
                {
                    case 1:
                        Player berserker = new Player(name, class_attributes, difficulty_choice, 100, 0, 1, 0, 0);
                        return berserker;
                    case 2:
                        Player tank = new Player(name, class_attributes,difficulty_choice, 200, 0, 1, 0, 0);
                        return tank;
                    default:
                        Console.WriteLine("Please enter a valid number.\n");
                        break;
                }
                return null;
            }
        }
        public void enemyEncounter(Player player, Enemy enemy)
        {
            Console.WriteLine("You've encountered: " + 
                              enemy.name + " [Health]: " + 
                              enemy.health + " - [Armor]: " + 
                              enemy.armor + " - [Damage]: " + 
                              enemy.damage + "\n");

            while (enemy.health > 0 && player.current_health > 0)
            {
                if (player.current_health <= 0)
                {
                    player.alive = false;
                    Console.WriteLine("You have died.");
                    return;
                }

                Console.WriteLine("Choose your action against " + enemy.name + ", " + name + ".\n" +
                                  "(1) Attack\n" +
                                  "(2) Check Inventory\n" +
                                  "(3) Check Stats\n" +
                                  "(4) Run\n");

                action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        playerAttack(player, enemy);
                        break;
                    case 2:
                        checkInventory(player);
                        break;
                    case 3:
                        checkPlayerStats(player);
                        break;
                    case 4:
                        Console.WriteLine("You run to safety and survive another day.\n");
                        return;
                    default:
                        Console.WriteLine("Choose a correct action.\n");
                        break;
                }
            }         
        }
        public Item dropLoot(Player player, Enemy enemy, int amount_of_items)
        {
            Console.WriteLine("You found: \n");

            for (i = 0; i < amount_of_items; i++)
            {
                random_index = random.Next(0, enemy.loot_table.Count);
                dropped_item = enemy.loot_table.ElementAt(random_index);

                addToInventory(player, dropped_item);

                Console.WriteLine("(" + (i + 1) + ") - " + dropped_item.name + " - " + dropped_item.value + " - " + dropped_item.type + " - " + dropped_item.slot +"\n");
            }
            return dropped_item;
        }
    }
}