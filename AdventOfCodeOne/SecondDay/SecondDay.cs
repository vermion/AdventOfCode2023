using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2023.SecondDay
{
    public static class SecondDay
    {
        private static readonly string _green = "green";
        private static readonly string _red = "red";
        private static readonly string _blue = "blue";

        private static readonly int _numberOfBlueCubes = 14;
        private static readonly int _numberOfRedCubes = 12;
        private static readonly int _numberOfGreenCubes = 13;

        public static void Execute()
        {
            var games = File.ReadAllLines(".\\SecondDay\\InputData.txt").ToList();
            var allGames = new List<Game>();

            foreach (var game in games)
            {
                var indexStart = game.IndexOf(':') + 1;
                var splitGame = game[indexStart..];

                var individualDraws = splitGame.Split(';');
                var gameDraws = new List<GameDraw>();
                var individualGame = new Game();

                foreach (var individualDraw in individualDraws)
                {
                    var individualCubes = individualDraw.Split(',');
                    var gameDraw = new GameDraw();
                    foreach (var individualCube in individualCubes)
                    {   
                        if (individualCube.Contains(_green))
                        {
                            gameDraw.NumberOfGreen = int.Parse(individualCube.Substring(0, individualCube.Length - _green.Length));
                        }
                        if (individualCube.Contains(_red))
                        {
                            gameDraw.NumberOfRed = int.Parse(individualCube.Substring(0, individualCube.Length - _red.Length));
                        }
                        if (individualCube.Contains(_blue))
                        {
                            gameDraw.NumberOfBlue = int.Parse(individualCube.Substring(0, individualCube.Length - _blue.Length));
                        }
                        
                    }
                    gameDraws.Add(gameDraw);
                }
                
                individualGame.GameDraws = gameDraws;

                allGames.Add(individualGame);
            }

            ProcessAllGamesPartOne(allGames);
            ProcessAllGamesPartTwo(allGames);
        }

        public static void ProcessAllGamesPartOne(List<Game> games)
        {
            int i = 1;
            int totalIDSum = 0;
            foreach (var game in games)
            {
                var valid = true;
                foreach (var draw in game.GameDraws)
                {
                    if (draw.NumberOfGreen > _numberOfGreenCubes)
                    {
                        valid = false;
                        break;
                    }

                    if (draw.NumberOfBlue > _numberOfBlueCubes)
                    {
                        valid = false;
                        break;
                    }

                    if (draw.NumberOfRed > _numberOfRedCubes)
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid == true)
                {
                    totalIDSum = totalIDSum + i;
                }
                i++;
            }
            Console.WriteLine(totalIDSum);
        }

        public static void ProcessAllGamesPartTwo(List<Game> games)
        {
            int i = 1;
            int totalPower = 0;
            foreach (var game in games)
            {

                var nrOfGreens = game.GameDraws.Max(x => x.NumberOfGreen);
                var nrOfReds = game.GameDraws.Max(x => x.NumberOfRed);
                var nrOfBlues = game.GameDraws.Max(x => x.NumberOfBlue);

                var total = nrOfGreens * nrOfReds * nrOfBlues;

                totalPower = totalPower + total;
            }
            Console.WriteLine(totalPower);
        }
    }
}