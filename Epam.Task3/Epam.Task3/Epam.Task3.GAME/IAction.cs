using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public interface IAction
    {
        void Algorithm();

        void Action();

        void Move();

        bool IsDeath();
    }
}
