using System;

namespace SimpleMarsKata
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new MarsRover("RRLM"));
        }
    }

    internal class MarsRover
    {
        private int _ycoord;
        private char _direction = 'N';
        private int _xcoord;

        public MarsRover(string commands)
        {
            foreach (var command in commands)
            {
                if (MovingForward(command))
                {
                    if (FacingSouth())
                    {
                        MoveDown();
                    }
                    else if (FacingNorth())
                    {
                        MoveUp();
                    }
                }
                else if (TurningRight(command))
                {
                    if (FacingNorth())
                    {
                        SetDirectionToEast();
                    }
                    else if (FacingEast())
                    {
                        SetDirectionToSouth();
                    }else if (FacingSouth())
                    {
                        SetDirectionToWest();
                    }
                    else if (FacingWest())
                    {
                        SetDirectionToNorth();
                    }
                }
                else if (TurningLeft(command))
                {
                    if (FacingWest())
                    {
                        SetDirectionToSouth();
                    }
                    else if(FacingSouth())
                    {
                        SetDirectionToEast();
                    }
                    else if (FacingEast())
                    {
                        SetDirectionToNorth();
                    }
                    else if (FacingNorth())
                    {
                        SetDirectionToWest();
                    }
                }
                
                if (MovingForward(command))
                {
                    if (FacingWest())
                    {
                        MoveLeft();
                    }
                    else
                    {
                        MoveRight();
                    }
                }
                else if (TurningRight(command))
                {
                    if (FacingWest())
                    {
                        SetDirectionToNorth();
                    }
                    else if (FacingNorth())
                    {
                        SetDirectionToEast();
                    }else if (FacingEast())
                    {
                        SetDirectionToSouth();
                    }
                    else if (FacingSouth())
                    {
                        SetDirectionToWest();
                    }
                }
                else if (TurningLeft(command))
                {
                    if (FacingSouth())
                    {
                        SetDirectionToEast();
                    }
                    else if(FacingEast())
                    {
                        SetDirectionToNorth();
                    }
                    else if (FacingNorth())
                    {
                        SetDirectionToWest();
                    }
                    else if (FacingWest())
                    {
                        SetDirectionToSouth();
                    }
                }
            }
        }

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
            _xcoord++;
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
        }private bool FacingSouth()
        {
            return _direction == 'S';
        }private bool FacingWest()
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
        
    }
}