using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarsRovers
{
    class MarsProject
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("C:\\Users\\gokberk.konuralp\\input.txt").ToList();

            List<Rover> rovers = new List<Rover>();

            for (int i = 0; i < input.Count(); i++)
            {
                if (i == 0)
                {
                    var plateauDimensions = input[i].Split(' ');

                    Plateau.Width = int.Parse(plateauDimensions[0]);
                    Plateau.Height = int.Parse(plateauDimensions[1]);
                }

                else if (i % 2 == 1)
                {
                    var initials = input[i].Split(' ');
                    rovers.Add(new Rover(int.Parse(initials[0]), int.Parse(initials[1]), char.Parse(initials[2])));
                }

                else if (i % 2 == 0)
                {
                    rovers.Last().Proceed(input[i]);
                }
            }

            File.WriteAllLines("C:\\Users\\gokberk.konuralp\\output.txt", rovers.Select(s=> string.Format("{0} {1} {2}", s.X, s.Y, s.Heading)));
        }
    }
}
