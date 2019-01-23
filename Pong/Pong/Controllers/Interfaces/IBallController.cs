using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pong.Graphics;

namespace Pong.Controllers.Interfaces
{
    interface IBallController
    {
        int GetMaxNumberOfBalls();
        Ball GetCurrentBall();
        Ball GenerateBallDirection();
    }
}
