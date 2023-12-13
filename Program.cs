using System;
using System.Collections.Generic;
using System.Linq;

namespace pbr_bottles_card_deck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up card ids, number of trials, and draw counts
            var cardIDs = Enumerable.Range(1, 52).ToArray();
            var trials = 10000;
            var drawCounts = new List<int>();

            // Enter experiment loop
            for (var i = 0; i < trials; i++)
            {
                var ourCards = new List<int>();
                var drawCount = 0;

                // Continue to draw cards until we have all cards to make a deck
                while (ourCards.Sum() != cardIDs.Sum())
                {
                    var random = new Random();
                    var index = random.Next(cardIDs.Count());
                    var cardIDDrawn = cardIDs[index];

                    if (!ourCards.Contains(cardIDDrawn))
                    {
                        ourCards.Add(cardIDDrawn);
                    }

                    drawCount++;
                }
                drawCounts.Add(drawCount);
                Console.WriteLine($"Done with experiment. Draw count needed was {drawCount}");
            }

            Console.WriteLine($"Average draw count needed over all experiments was {drawCounts.Average()}");
            Console.WriteLine($"Minimum draw count needed over all experiments was {drawCounts.Min()}");
            Console.WriteLine($"Maximum draw count needed over all experiments was {drawCounts.Max()}");
        }
    }
}
