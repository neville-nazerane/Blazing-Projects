using BlazingProjects.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Models
{
    public class NavigationContext
    {

        public Func<ScopeControl, Task> OnMenuUpdatedAsync { get; set; }

    }
}
