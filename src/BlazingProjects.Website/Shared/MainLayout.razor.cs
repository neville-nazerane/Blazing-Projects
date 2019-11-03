using BlazingProjects.Website.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Shared
{
    public class MainLayoutVM : LayoutComponentBase
    {

        public NavigationContext NavigationContext { get; set; }

        protected override void OnInitialized()
        {
            NavigationContext = new NavigationContext();
            base.OnInitialized();
        }

    }
}
