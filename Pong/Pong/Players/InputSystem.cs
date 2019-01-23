using System;
using Microsoft.Xna.Framework.Input;

namespace Pong.Players
{
    public class InputSystem
    {
        private char _upKey;
        private char _downKey;
        private char _leftKey;
        private char _rightKey;

        private GamePadButtons _upKeyConsole;
        private GamePadButtons _downKeyConsole;
        private GamePadButtons _leftKeyConsole;
        private GamePadButtons _rightKeyConsole;

        private KeyboardState _upKeyArrow;
        private KeyboardState _downKeyArrow;
        private KeyboardState _leftKeyArrow;
        private KeyboardState _rightKeyArrow;

        public InputSystem(char up, char down, char left, char right)
        {
            _upKey = up;
            _downKey = down;
            _leftKey = left;
            _rightKey = right;
        }

        public InputSystem(GamePadButtons up, GamePadButtons down, GamePadButtons left, GamePadButtons right)
        {
            _upKeyConsole = up;
            _downKeyConsole = down;
            _leftKeyConsole = left;
            _rightKeyConsole = right;
        }

        public InputSystem(KeyboardState up, KeyboardState down, KeyboardState left, KeyboardState right)
        {
            _upKeyArrow = up;
            _downKeyArrow = down;
            _leftKeyArrow = left;
            _rightKeyArrow = right;
        }

    }
}
