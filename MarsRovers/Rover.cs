using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{
    public class Rover
    {
        public Rover(int initialX, int initialY, char initialHeading)
        {
            X = initialX;
            Y = initialY;
            Heading = initialHeading;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char Heading { get; set; }

        public void Proceed(string commands)
        {
            foreach (var command in commands.ToUpper())
            {
                if (command == 'L' || command == 'R')
                {
                    ChangeDirection(command);
                }

                else if (command == 'M')
                {
                    ChangePosition();
                }
            }
        }

        public void ChangeDirection(char direction)
        {
            if (direction == 'L')
            {
                switch (Heading)
                {
                    case 'N':
                        Heading = 'W';
                        break;

                    case 'E':
                        Heading = 'N';
                        break;

                    case 'W':
                        Heading = 'S';
                        break;

                    case 'S':
                        Heading = 'E';
                        break;

                    default:
                        break;
                }
            }

            else if (direction == 'R')
            {
                switch (Heading)
                {
                    case 'N':
                        Heading = 'E';
                        break;

                    case 'E':
                        Heading = 'S';
                        break;

                    case 'W':
                        Heading = 'N';
                        break;

                    case 'S':
                        Heading = 'W';
                        break;

                    default:
                        break;
                }
            }
        }

        public void ChangePosition()
        {
            switch (Heading)
            {
                case 'N':
                    Y = Y < Plateau.Height ? Y + 1 : Y;
                    break;

                case 'E':
                    X = X < Plateau.Width ? X + 1 : X;
                    break;

                case 'W':
                    X = X > 0 ? X - 1 : X;
                    break;

                case 'S':
                    Y = Y > 0 ? Y - 1 : Y;
                    break;

                default:
                    break;
            }
        }
    }
}
