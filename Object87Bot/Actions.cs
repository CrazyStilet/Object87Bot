using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Object87Bot
{
    public partial class Service1 : IService
    {
        public bool IsPlayer(List<Player> players)
        {
            if (players.Count != 0)
            {
                return true;
            }
            return false;
        }

        private void TakeFlashlight(long id, Player player)
        {
            bool nothing = true;

            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var flashlight in objects)
            {
                if (flashlight.GetType() == typeof(MissionsLocationPositionFlashlight))
                {
                    if (player.Items.Count != 0)
                    {
                        nothing = FindFlashlight(id, player);
                        break;
                    }
                    else
                    {
                        PickUpFlashlight(id, player);
                        nothing = false;
                    }
                }
            }
            if (nothing)
            {
                bot.SendTextMessageAsync(id, "Тут ничего нет");
            }
        }

        private bool FindFlashlight(long id, Player player)
        {
            foreach (var items in player.Items)
            {
                if (items.Flashlight == null && items.Keys.Count == 0)
                {
                    PickUpFlashlight(id, player);
                    return false;
                }
                else
                {
                    bot.SendTextMessageAsync(id, "У вас уже есть фонарик");
                    return false;
                }
            }
            return true;
        }

        private void PickUpFlashlight(long id, Player player)
        {
            Flashlight f = new Flashlight();
            Items i = new Items() { Flashlight = f };
            player.Items.Add(i);
            context.SaveChanges();
            bot.SendTextMessageAsync(id, "Фонарик был успешно поднят");
        }

        private void OpenDoor(long id, Player player)
        {
            bool nothing = true;

            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var openDoor in objects)
            {
                if (openDoor.GetType() == typeof(MissionsLocationPositionDoor))
                {
                    MissionsLocationPositionDoor tempDoor = (MissionsLocationPositionDoor)openDoor;
                    //Item tempItem = (Item)item;
                    //Item temp = new Item();

                    //if (true)
                    //{
                    //    bot.SendTextMessageAsync(update.message.chat.id, "1234");
                    //}
                    //bot.SendTextMessageAsync(update.message.chat.id, ",fkdfaskj;");

                    if (player.Items.Count!=0)
                    {
                        if (FindBlueKeyAtPlayer(player))
                        {
                            foreach (var items in player.Items)
                            {
                                if (items.Keys.Count != 0)
                                {
                                    foreach (var keys in items.Keys)
                                    {
                                        if (keys.BlueKey!=null)
                                        {
                                            //keys.BlueKey = null;
                                            BlueKey bk = new BlueKey();
                                            Keys k = new Keys() { BlueKey = bk };
                                            if (items.Keys.Remove(k))
                                            {
                                                context.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                            bot.SendTextMessageAsync(id, "Найден нужный ключ у игрока");

                        }
                        else
                        {
                            bot.SendTextMessageAsync(id, "Нужный предмет у игрока не был найден");
                        }
                    }

                    //string str = "Необходимо: " + tempDoor.need;
                    //bot.SendTextMessageAsync(id, str);

                    nothing = false;
                }
            }
            if (nothing)
            {
                bot.SendTextMessageAsync(id, "Тут нет двери");
            }
        }

        private void TakeKey(long id, Player player)
        {
            bool nothing = true;

            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var blueKey in objects)
            {
                if (blueKey.GetType() == typeof(MissionsLocationPositionBlueKey))
                {
                    if (player.Items.Count!=0)
                    {
                        nothing = FindKey(id, player);
                        break;
                    }
                    else
                    {
                        PickUpKey(id, player);
                        nothing = false;
                    }
                }
            }

            if (nothing)
            {
                bot.SendTextMessageAsync(id, "Тут ничего нет");
            }
        }

        private bool FindKey(long id, Player player)
        {
            foreach (var items in player.Items)
            {
                if (items.Keys.Count != 0)
                {
                    foreach (var key in items.Keys)
                    {
                        if (key.BlueKey == null)
                        {
                            PickUpKey(id, player);
                            return false;
                        }
                        else
                        {
                            bot.SendTextMessageAsync(id, "У вас уже есть этот ключ");
                            return false;
                        }
                        //if (key.GreenKey != null)
                        //{
                        //    bot.SendTextMessageAsync(id, "Find GreenKey");
                        //}
                        //else
                        //{
                        //    bot.SendTextMessageAsync(id, "Not Found GreenKey");
                        //}
                    }
                }
                else
                {
                    if (items.Flashlight == null)
                    {
                        PickUpKey(id, player);
                        return false;
                    }
                }
                //if (item.Flashlight != null)
                //{
                //    bot.SendTextMessageAsync(id, "Flashlight != null");
                //}
                //else
                //{
                //    bot.SendTextMessageAsync(id, "Flashlight == null");
                //}
            }
            PickUpKey(id, player);
            return false;
        }

        private void PickUpKey(long id, Player player)
        {
            BlueKey bk = new BlueKey();
            Keys k = new Keys();
            k.BlueKey = bk;
            Items i = new Items();
            i.Keys.Add(k);
            player.Items.Add(i);
            context.SaveChanges();
            bot.SendTextMessageAsync(id, "Ключ был успешно поднят");
        }

        private bool OnWest(long id, Player player)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var west in objects)
            {
                if (west.GetType() == typeof(MissionsLocationPositionWest))
                {
                    MissionsLocationPositionWest temp = (MissionsLocationPositionWest)west;
                    player.Position = temp.Value;
                    context.SaveChanges();
                    YouAreIn(id, player);
                    return false;
                }
            }
            return true;
        }

        private bool OnSouth(long id, Player player)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var south in objects)
            {
                if (south.GetType() == typeof(MissionsLocationPositionSouth))
                {
                    MissionsLocationPositionSouth temp = (MissionsLocationPositionSouth)south;
                    player.Position = temp.Value;
                    context.SaveChanges();
                    YouAreIn(id, player);
                    return false;
                }
            }
            return true;
        }

        private bool OnNorth(long id, Player player)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var north in objects)
            {
                if (north.GetType() == typeof(MissionsLocationPositionNorth))
                {
                    MissionsLocationPositionNorth temp = (MissionsLocationPositionNorth)north;
                    player.Position = temp.Value;
                    context.SaveChanges();
                    YouAreIn(id, player);
                    return false;
                }
            }
            return true;
        }

        private bool OnEast(long id, Player player)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            List<object> objects = missions.Location[player.Location].Position[player.Position].Items.ToList();
            foreach (var east in objects)
            {
                if (east.GetType() == typeof(MissionsLocationPositionEast))
                {
                    MissionsLocationPositionEast temp = (MissionsLocationPositionEast)east;
                    player.Position = temp.Value;
                    context.SaveChanges();
                    YouAreIn(id, player);
                    return false;
                }
            }
            return true;
        }

        private void CorrectStep(long id, Player player)
        {
            if (player.Health <= 5)
            {
                bot.SendTextMessageAsync(id, "Умер. Игре конец");
            }
            else
            {
                player.Health -= 5;
                context.SaveChanges();
                bot.SendTextMessageAsync(id, "Ваши хп: " + player.Health);
            }
        }

        private void StartGame(long id, string first_name, List<Player> players)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            bot.SendTextMessageAsync(id, "Привет, " + first_name);

            if (players.Count == 0)
            {
                bot.SendTextMessageAsync(id, "Создание нового профиля");
                context.PlayerSet.Add(new Player
                {
                    UserID = id
                });
                context.SaveChanges();
                var query = from p in context.PlayerSet
                            where p.UserID == id
                            select p;

                players = query.ToList();
            }
            else
            {
                bot.SendTextMessageAsync(id, "Загрузка текущего профиля");
            }
            YouAreIn(id, players[0]);
        }

        public void YouAreIn(long id, Player player)
        {
            bot.SendChatActionAsync(id, Telegram.Bot.Types.Enums.ChatAction.Typing);
            bot.SendTextMessageAsync(id, missions.Location[player.Location].Position[player.Position].description);
            ReplyKeyboardMarkup keyboard = null;

            //KeyboardButton[] eastButton, northButton, southButton, westButton = null;
            //bot.SendTextMessageAsync(update.message.chat.id, "You are: " + update.message.from.id
            //    + "\nLocation: " + player.Location
            //    + "\nPosition: " + player.Position);
            //string str = null;
            //foreach (var items in missions.Location)
            //{
            //    str += "\nLocation.Id: " + items.id;
            //    foreach (var item in items.Position)
            //    {
            //        str += "\nPosition.Id: " + item.id + "\nEast: " + item.East + "\nEastSpecified: " + item.EastSpecified
            //        + "\nNorth: " + item.North + "\nNorthSpecified: " + item.NorthSpecified + "\nSouth: " + item.South
            //        + "\nSouthSpecified: " + item.SouthSpecified + "\nWest: " + item.West + "\nWestSpecified: " + item.WestSpecified;
            //    }
            //}
            //bot.SendTextMessageAsync(update.message.chat.id, str);

            //#region MyRegion
            //List<string> nameButtons = new List<string>();
            //string go = null;
            //if (missions.Location[player.Location].Position[player.Position].EastSpecified)
            //{
            //    go += "\nна Восток";
            //    nameButtons.Add("На восток");
            //    //eastButton = new KeyboardButton[] { new KeyboardButton("На восток") };
            //    //keyboard = new ReplyKeyboardMarkup(keyboardRow: eastButton, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //if (missions.Location[player.Location].Position[player.Position].NorthSpecified)
            //{
            //    nameButtons.Add("На север");
            //    go += "\nна Север";
            //    //ReplyKeyboardMarkup newKeyboard = new ReplyKeyboardMarkup(new[] { new KeyboardButton("На север") }, true, true);

            //    //northButton = new KeyboardButton[] { new KeyboardButton("На север") };

            //    //keyboard = new ReplyKeyboardMarkup(keyboardRow: northButton, resizeKeyboard: true, oneTimeKeyboard: true);
            //    //newKeyboard = keyboard.Keyboard.Concat<KeyboardButton>(newKeyboard.Keyboard;
            //}
            //if (missions.Location[player.Location].Position[player.Position].SouthSpecified)
            //{
            //    nameButtons.Add("На юг");
            //    go += "\nна Юг";
            //    //southButton = new KeyboardButton[] { new KeyboardButton("На юг") };
            //    //keyboard = new ReplyKeyboardMarkup(keyboardRow: southButton, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //if (missions.Location[player.Location].Position[player.Position].WestSpecified)
            //{
            //    nameButtons.Add("На запад");
            //    go += "\nна Запад";
            //    //westButton = new KeyboardButton[] { new KeyboardButton("На запад") };
            //    //keyboard = new ReplyKeyboardMarkup(keyboardRow: westButton, resizeKeyboard: true, oneTimeKeyboard: true);
            //}

            //if (nameButtons.Count == 1)
            //{
            //    keyboard = new ReplyKeyboardMarkup(new[] { new KeyboardButton(nameButtons[0]) }, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //else if (nameButtons.Count == 2)
            //{
            //    keyboard = new ReplyKeyboardMarkup(new[] { new KeyboardButton(nameButtons[0]), new KeyboardButton(nameButtons[1]) }, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //else if (nameButtons.Count == 3)
            //{
            //    keyboard = new ReplyKeyboardMarkup(new[] { new KeyboardButton(nameButtons[0]), new KeyboardButton(nameButtons[1]), new KeyboardButton(nameButtons[2]) }, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //else if (nameButtons.Count == 4)
            //{
            //    keyboard = new ReplyKeyboardMarkup(new[] { new KeyboardButton(nameButtons[0]), new KeyboardButton(nameButtons[1]), new KeyboardButton(nameButtons[2]), new KeyboardButton(nameButtons[3]) }, resizeKeyboard: true, oneTimeKeyboard: true);
            //}
            //#endregion

            //keyboard = new ReplyKeyboardMarkup(keyboardRow: eastButton, keyboardRow: northButton, keyboardRow: southButton, keyboardRow: westButton, true, true);
            //bot.SendTextMessageAsync(update.message.chat.id, "Вы можете пойти:" + go);

            List<string> moveButton = new List<string>();
            List<string> actionButton = new List<string>();
            string move = null;
            string action = null;

            List<object> obj = missions.Location[player.Location].Position[player.Position].Items.ToList();

            foreach (var item in obj)
            {
                if (item.GetType() == typeof(MissionsLocationPositionEast))
                {
                    MissionsLocationPositionEast temp = (MissionsLocationPositionEast)item;
                    moveButton.Add(temp.description);
                    move += "\n" + temp.description;
                }
                if (item.GetType() == typeof(MissionsLocationPositionNorth))
                {
                    MissionsLocationPositionNorth temp = (MissionsLocationPositionNorth)item;
                    moveButton.Add(temp.description);
                    move += "\n" + temp.description;
                }
                if (item.GetType() == typeof(MissionsLocationPositionSouth))
                {
                    MissionsLocationPositionSouth temp = (MissionsLocationPositionSouth)item;
                    moveButton.Add(temp.description);
                    move += "\n" + temp.description;
                }
                if (item.GetType() == typeof(MissionsLocationPositionWest))
                {
                    MissionsLocationPositionWest temp = (MissionsLocationPositionWest)item;
                    moveButton.Add(temp.description);
                    move += "\n" + temp.description;
                }
                if (item.GetType() == typeof(MissionsLocationPositionBlueKey))
                {
                    if (!FindBlueKeyAtPlayer(player))
                    {
                        MissionsLocationPositionBlueKey temp = (MissionsLocationPositionBlueKey)item;
                        actionButton.Add(temp.description);
                        action += "\n" + temp.description;
                    }                    
                }
                if (item.GetType() == typeof(MissionsLocationPositionDoor))
                {
                    MissionsLocationPositionDoor temp = (MissionsLocationPositionDoor)item;
                    actionButton.Add(temp.description);
                    action += "\n" + temp.description;
                }
                if (item.GetType() == typeof(MissionsLocationPositionFlashlight))
                {
                    if (!FindFlashlightAtPlayer(player))
                    {
                        MissionsLocationPositionFlashlight temp = (MissionsLocationPositionFlashlight)item;
                        actionButton.Add(temp.description);
                        action += "\n" + temp.description;
                    }
                }
            }

            if (moveButton.Count == 1 && actionButton.Count == 0)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[] {
                        new KeyboardButton(moveButton[0])
                    }, true, true);
            }
            else if (moveButton.Count == 1 && actionButton.Count == 1)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[] {
                        new[]
                        {
                            new KeyboardButton(moveButton[0])
                        },
                        new []
                        {
                            new KeyboardButton(actionButton[0])
                        },
                    }, true, true);
            }
            else if (moveButton.Count == 2 && actionButton.Count == 0)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[] {
                        new KeyboardButton(moveButton[0]),
                        new KeyboardButton(moveButton[1])
                    }, true, true);
            }
            else if (moveButton.Count == 2 && actionButton.Count == 1)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton(moveButton[0]),
                            new KeyboardButton(moveButton[1])
                        },
                        new[] {
                            new KeyboardButton(actionButton[0])
                        }
                    }, true, true);
            }
            else if (moveButton.Count == 2 && actionButton.Count == 2)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton(moveButton[0]),
                            new KeyboardButton(moveButton[1])
                        },
                        new[] {
                            new KeyboardButton(actionButton[0]),
                            new KeyboardButton(actionButton[1])
                        }
                    }, true, true);
            }
            else if (moveButton.Count == 3 && actionButton.Count == 0)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton(moveButton[0]),
                            new KeyboardButton(moveButton[1]),
                            new KeyboardButton(moveButton[2])
                        },
                    }, true, true);
            }
            else if (moveButton.Count == 3 && actionButton.Count == 1)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton(moveButton[0]),
                            new KeyboardButton(moveButton[1]),
                            new KeyboardButton(moveButton[2])
                        },
                        new[] {
                            new KeyboardButton(actionButton[0])
                        }
                    }, true, true);
            }
            else if (moveButton.Count == 3 && actionButton.Count == 2)
            {
                keyboard = new ReplyKeyboardMarkup(
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton(moveButton[0]),
                            new KeyboardButton(moveButton[1]),
                            new KeyboardButton(moveButton[2])
                        },
                        new[] {
                            new KeyboardButton(actionButton[0]),
                            new KeyboardButton(actionButton[1])
                        }
                    }, true, true);
            }

            bot.SendTextMessageAsync(id, "Вы можете пойти:" + move + "\nВы можете сделать: " + action, replyMarkup: keyboard);
        }

        private bool FindFlashlightAtPlayer(Player player)
        {
            if (player.Items.Count!=0)
            {
                foreach (var items in player.Items)
                {
                    if (items.Flashlight != null && items.Keys.Count == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool FindBlueKeyAtPlayer(Player player)
        {
            if (player.Items.Count != 0)
            {
                foreach (var items in player.Items)
                {
                    if (items.Keys.Count != 0 && items.Flashlight == null)
                    {
                        foreach (var keys in items.Keys)
                        {
                            if (keys.BlueKey != null)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void LoadMissions()
        {
            using (FileStream fs = new FileStream(@"D:\Missions.xml", FileMode.Open))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Missions));
                    missions = (Missions)xml.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }
}