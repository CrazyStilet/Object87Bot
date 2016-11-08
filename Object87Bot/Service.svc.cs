using System.Collections.Generic;
using System.Linq;


namespace Object87Bot
{
    public partial class Service1 : IService
    {
        private static readonly Telegram.Bot.TelegramBotClient bot = new Telegram.Bot.TelegramBotClient("299223893:AAF8ccSCQmE42WDvWABNrXsROhaNzAaIZ8I");

        Object87BotModelContainer context = new Object87BotModelContainer();

        private static Missions missions = null;

        public void GetUpdate(Update update)
        {
            var query = from p in context.PlayerSet
                        where p.UserID == update.message.@from.id
                        select p;

            List<Player> players = query.ToList();
            if (missions == null)
            {
                LoadMissions();
            }

            switch (update.message.text)
            {
                case "/start":
                    bot.SendChatActionAsync(update.message.chat.id, Telegram.Bot.Types.Enums.ChatAction.Typing);
                    bot.SendTextMessageAsync(update.message.chat.id, "Для начала игры наберите /start_game");
                    break;
                case "/start_game":
                    StartGame(update.message.chat.id, update.message.from.first_name, players);
                    break;
                case "На восток":
                    if (IsPlayer(players))
                    {
                        if (OnEast(update.message.chat.id, players[0]))
                        {
                            CorrectStep(update.message.chat.id, players[0]);
                        }
                    }
                    break;
                case "На север":
                    if (IsPlayer(players))
                    {
                        if (OnNorth(update.message.chat.id, players[0]))
                        {
                            CorrectStep(update.message.chat.id, players[0]);
                        }
                    }
                    break;
                case "На юг":
                    if (IsPlayer(players))
                    {
                        if (OnSouth(update.message.chat.id, players[0]))
                        {
                            CorrectStep(update.message.chat.id, players[0]);
                        }
                    }
                    break;
                case "На запад":
                    if (IsPlayer(players))
                    {
                        if (OnWest(update.message.chat.id, players[0]))
                        {
                            CorrectStep(update.message.chat.id, players[0]);
                        }
                    }
                    break;
                case "Взять ключ":
                    if (IsPlayer(players))
                    {
                        TakeKey(update.message.chat.id, players[0]);
                    }
                    break;
                case "Взять фонарик":
                    if (IsPlayer(players))
                    {
                        TakeFlashlight(update.message.chat.id, players[0]);
                    }
                    break;
                case "Открыть дверь":
                    if (IsPlayer(players))
                    {
                        OpenDoor(update.message.chat.id, players[0]);
                    }
                    break;
                default:
                    bot.SendTextMessageAsync(update.message.chat.id, "Неизвестная команда");
                    break;
            }
        }
    }
}
