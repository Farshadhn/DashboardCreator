using DashboardCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardCreator.Phases
{
    public interface IPhase
    {
        public void Create(string baseAdd, string modelPhysicalAdd, FoundClass foundClass);
    }
  
}
