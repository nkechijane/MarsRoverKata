using System;
using System.Linq;

namespace SimpleMarsKata
{
    class Program
    {
        static void Main()
        {

            var marsRover = new MarsRover();
            string commands = "RRMRM";
            marsRover.Execute(commands);
            Console.WriteLine(marsRover);
        }
    }

    internal class MarsRover
    {
        private int _ycoord;
        private char _direction = 'N';
        private int _xcoord;
        
        private void MoveDown()
        {
            if (_ycoord == 0)
            {
                _ycoord = 9;
            }
            else
            {
                _ycoord--;
            }
        }

        private void MoveLeft()
        {
            if (_xcoord == 0)
            {
                _xcoord = 9;
            }
            else
            {
                _xcoord--;
            }
        }

        private void SetDirectionToNorth()
        {
            _direction = 'N';
        }

        private void MoveUp()
        {
            _ycoord++;
        }

        private void MoveRight()
        {
            if (_xcoord == 9)
            {
                _xcoord = 0;
            }
            else
            {
                _xcoord++;
            }
            
        }
        
        

        private void SetDirectionToWest()
        {
            _direction = 'W';
        }

        private void SetDirectionToSouth()
        {
            _direction = 'S';
        }

        private void SetDirectionToEast()
        {
            _direction = 'E';
        }

        private bool FacingEast()
        {
            return _direction == 'E';
        }

        private bool FacingNorth()
        {
            return _direction == 'N';
        }

        private bool FacingSouth()
        {
            return _direction == 'S';
        }

        private bool FacingWest()
        {
            return _direction == 'W';
        }

        private static bool MovingForward(char command)
        {
            return command == 'M';
        }

        private static bool TurningLeft(char command)
        {
            return command == 'L';
        }

        private static bool TurningRight(char command)
        {
            return command == 'R';
        }

        public override string ToString()
        {
            return $"{_xcoord}:{_ycoord}:{_direction}";
        }

        public void Execute(string commands) => commands.ToList().ForEach(ExecuteCommand);

        private void ExecuteCommand(char command)
        {
            if (MovingForward(command)) Move();
            else if (TurningRight(command)) TurnRight();
            else if (TurningLeft(command)) TurnLeft();
        }

        private void TurnLeft()
        {
            if (FacingWest()) SetDirectionToSouth();
            else if (FacingSouth()) SetDirectionToEast();
            else if (FacingEast()) SetDirectionToNorth();
            else if (FacingNorth()) SetDirectionToWest();
        }

        private void TurnRight()
        {
            if (FacingNorth()) SetDirectionToEast();
            else if (FacingEast()) SetDirectionToSouth();
            else if (FacingSouth()) SetDirectionToWest();
            else if (FacingWest()) SetDirectionToNorth();
        }

        private void Move()
        {
            if (FacingSouth()) MoveDown();
            else if (FacingNorth()) MoveUp();
            else if (FacingWest()) MoveLeft();
            else MoveRight();
        }
    }
}